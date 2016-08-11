using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Domain.Model
{
    [Serializable]
    public class ActivityId
    {
        private readonly string _value;

        private ActivityId(string value)
        {
            _value = value;
        }

        public static implicit operator string(ActivityId source)
        {
            return source._value;
        }

        public static implicit operator ActivityId(string source)
        {
            return new ActivityId(source);
        }

        public override string ToString()
        {
            return _value;
        }

        public override bool Equals(object obj)
        {
            var other = obj as ActivityId;
            if (other == null) return false;
            return (other._value == _value);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}
