using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikadocs.Domain
{
    public abstract class ValueObject<TValue> : IEquatable<ValueObject<TValue>>
    {
        protected ValueObject(TValue value)
        {            
            Value = value;
        }

        public TValue Value { get; private set; }

        public bool Equals(ValueObject<TValue> other)
        {
            if (other.GetType() != this.GetType()) return false;
            return EqualityComparer<TValue>.Default.Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ValueObject<TValue>) obj);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<TValue>.Default.GetHashCode(Value);
        }
    }
}
