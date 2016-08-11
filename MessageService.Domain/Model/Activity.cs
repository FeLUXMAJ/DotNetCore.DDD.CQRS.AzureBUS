using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Domain.Model
{
    [Serializable]
    public class Activity
    {
        // Dados da atividade
        public ActivityId Id { get; private set; }
        public string Message { get; private set; }
        public WebSite ActionUrl { get; private set; }
        public DateTime DueDate { get; private set; }
        public bool IsCompleted { get; private set; } = false;

        // Dados da aplição que solicitou a atividade
        public Application ApplicationEntity { get; private set; }
        
        // Identificador do destinatário.
        public Peaple AssignedTo { get; private set; }

        // Dados de criação da atividade
        public Peaple CreateBy { get; private set; }
        public DateTime CreatedDate { get; private set; }

        // Dados da modificação da atividade
        public Peaple ModifiedBy { get; private set; }
        
        // Dados da empresa solicitante.
        public Company Tenant { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Activity"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="message">The message.</param>
        /// <param name="createdBy">The created by.</param>
        /// <param name="assignedTo">The assigned to.</param>
        /// <param name="tenant">The tenant.</param>
        public Activity(ActivityId id, string message, Peaple createdBy, Peaple assignedTo, Company tenant)
        {
            this.Id = id;
            this.CreateBy = createdBy;
            this.Message = message;
            this.CreatedDate = DateTime.UtcNow;
            this.AssignedTo = assignedTo;
            this.Tenant = tenant;
        }

        public void AddCompleted()
        {
            this.IsCompleted = true;
        }

        public void AddNotCompleted()
        {
            this.IsCompleted = false;
        }

        public void AddAplication(Application application)
        {
            this.ApplicationEntity = application;
        }

        public void AddUrl(WebSite url)
        {
            this.ActionUrl = url;
        }

        public void AddDueDate(DateTime dueDate)
        {
            this.DueDate = dueDate;
        }
    }
}
