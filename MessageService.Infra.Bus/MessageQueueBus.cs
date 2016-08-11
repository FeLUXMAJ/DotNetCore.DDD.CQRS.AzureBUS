using MessageService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Extensions.OptionsModel;

namespace MessageService.Infra.Bus
{
    /// <summary>
    /// Create BUS with Message Queue Microsoft Azure
    /// </summary>
    /// <see cref="https://azure.microsoft.com/pt-br/documentation/articles/storage-dotnet-how-to-use-queues/"/>
    /// <seealso cref="MessageService.Domain.IBus" />
    public class MessageQueueBus : IBus
    {
        private readonly IDictionary<Type, object> _handlers = new Dictionary<Type, object>();
        private readonly IServiceProvider _service;
        private static string QUEUE_REFERENCE = "messageservice";
        private readonly CloudStorageAccount _cloudStorageAccount;
        private readonly CloudQueueClient _cloudQueueClient;
        private readonly BUSSettings _busSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageQueueBus"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public MessageQueueBus(IServiceProvider service, IOptions<BUSSettings> busSettings)
        {
            // Recupera as configurações.
            _busSettings = busSettings.Value;

            // Define a conta no azure;
            _cloudStorageAccount = CloudStorageAccount.Parse($"DefaultEndpointsProtocol=https;AccountName={_busSettings.AccountName};AccountKey={_busSettings.AccountKey}");
            // Define o cliente para o message queue azure.
            _cloudQueueClient = _cloudStorageAccount.CreateCloudQueueClient();
            _service = service;
        }

        /// <summary>
        /// Raises the event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="theEvent">The event.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RaiseEvent<T>(T theEvent) where T : Event
        {
            throw new NotImplementedException();
        }

        public async Task RaiseEventAsync<T>(T theEvent) where T : Event
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Registers the handler.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void RegisterHandler<T>()
        {
            _handlers.Add(typeof(T), null);
        }

        /// <summary>
        /// Sends the command.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="theCommand">The command.</param>
        public void SendCommand<T>(T theCommand) where T : Command
        {
            //AddMessage("Teste com string").Wait();
        }

        /// <summary>
        /// Sends the command asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="theCommand">The command.</param>
        /// <returns></returns>
        public async Task SendCommandAsync<T>(T theCommand) where T : Command
        {
            await AddMessage<T>(theCommand);
        }

        /// <summary>
        /// Adds the message.
        /// </summary>
        /// <param name="message">The message.</param>
        private async Task AddMessage<T>(T message) where T: Command
        {
            // Define o nome da fila.
            CloudQueue cloudQueue = _cloudQueueClient.GetQueueReference(QUEUE_REFERENCE);
            // Cria uma fila se não existe.
            cloudQueue.CreateIfNotExistsAsync().Wait();
            // Cria a mensagem.
            CloudQueueMessage queueMessage = new CloudQueueMessage(Serialize<T>(message));
            // Adiciona a mensagem na fila.
            await cloudQueue.AddMessageAsync(queueMessage);
            // Lista as mensagens da fila.
            await Send();
        }

        /// <summary>
        /// Sends this instance.
        /// </summary>
        /// <returns></returns>
        private async Task Send()
        {
            // Define o nome da fila.
            CloudQueue cloudQueue = _cloudQueueClient.GetQueueReference(QUEUE_REFERENCE);
            // Lista as mensagens da fila. Atualmente 5...
            foreach (CloudQueueMessage message in cloudQueue.GetMessages(5, TimeSpan.FromMinutes(1))) {

                try
                {
                    var command = Deserialize<Command>(message.AsBytes);
                    var constructedType = typeof(IMessageHandler<>).MakeGenericType(command.GetType());
                    var handlersToNotify = _handlers.Keys.Where(h => constructedType.IsAssignableFrom(h));
                    foreach (var handler in handlersToNotify)
                    {
                        var instance = _service.GetService(handler);
                        var method = constructedType.GetMethod("Handle", new[] { command.GetType() });
                        method.Invoke(instance, new object[] { command });
                    }
                }
                finally
                {
                    await cloudQueue.DeleteMessageAsync(message);
                }
            }
            
        }

        /// <summary>
        /// Serializes the specified m.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="m">The m.</param>
        /// <returns></returns>
        private byte[] Serialize<T>(T m) where T : Command
        {
            var ms = new MemoryStream();
            try
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, m);
                return ms.ToArray();
            }
            finally
            {
                ms.Close();
            }
        }

        /// <summary>
        /// Deserializes the specified byte array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="byteArray">The byte array.</param>
        /// <returns></returns>
        private T Deserialize<T>(byte[] byteArray) where T : Command
        {
            var ms = new MemoryStream(byteArray);
            try
            {
                var formatter = new BinaryFormatter();
                return (T)formatter.Deserialize(ms);
            }
            finally
            {
                ms.Close();
            }
        }
    }
}
