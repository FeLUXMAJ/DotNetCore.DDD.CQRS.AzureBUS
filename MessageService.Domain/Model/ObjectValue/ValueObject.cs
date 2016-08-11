using System;
using System.Collections.Generic;
using System.Linq;

namespace MessageService.Domain.Model
{
    [Serializable]
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public abstract IEnumerable<object> GetEqualityComponents();
        
        public bool Equals(ValueObject other)
        {

            if (object.ReferenceEquals(this, other)) return true;
            if (object.ReferenceEquals(null, other)) return false;
            if (this.GetType() != other.GetType()) return false;

            var vo = other as ValueObject;
            return this.GetEqualityComponents().SequenceEqual(vo.GetEqualityComponents());
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ValueObject);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return this.GetHashCode() * 123;
            }
        }
    }
}
