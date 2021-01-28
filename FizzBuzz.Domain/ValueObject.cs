using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz.Domain
{
    public abstract class ValueObject<T> : IEquatable<T> where T : ValueObject<T>
    {
        public override string ToString()
        {
            return string.Join(",", GetValues().Where(v => v != null).Select(v => v.ToString()));
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as T);
        }

        public bool Equals(T other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            var theseValues = GetValues();
            var otherValues = other.GetValues();

            if (theseValues.Count != otherValues.Count)
                return false;

            bool equal = true;
            int idx = 0;

            while (equal && idx < theseValues.Count)
            {
                equal = Equals(theseValues[idx], otherValues[idx]);
                idx++;
            }
            return equal;
        }

        public override int GetHashCode()
        {
            var values = GetValues();

            int hashCode = values[0]?.GetHashCode() ?? 0;
            if (values.Count == 1)
                return hashCode;

            for (int idx = 1; idx < values.Count; idx++)
            {
                hashCode = (hashCode * 397) ^ values[idx]?.GetHashCode() ?? 0;
            }
            return hashCode;
        }

        protected abstract List<object> GetValues();
    }
}