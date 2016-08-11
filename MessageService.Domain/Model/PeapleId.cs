using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Domain.Model
{
    [Serializable]
    public class PeapleId
    {
        protected readonly string _value;

        private PeapleId(string value)
        {
            // TODO: Incluir validação.
            //Throw.IfArgumentIsNullOrEmpty(value, nameof(value));
            _value = value;
        }

        public static implicit operator string(PeapleId source)
        {
            return source._value;
        }

        public static implicit operator PeapleId(string source)
        {
            return new PeapleId(source);
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        public override bool Equals(object obj)
        {
            var other = obj as PeapleId;
            if (other == null) return false;
            return (other._value == _value);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

    }
}
