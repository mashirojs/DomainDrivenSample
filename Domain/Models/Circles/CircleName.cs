using System;

namespace Domain.Models.Circles
{
    public class CircleName : IEquatable<CircleName>
    {
        public string Value { get; }

        public CircleName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            var trimmed = value.TrimStart().TrimEnd();
            if (trimmed.Length == 0)
            {
                throw new ArgumentException("スペースはサークル名として使用することができません。");
            }
            Value = trimmed;
        }

        public bool Equals(CircleName other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CircleName) obj);
        }

        public override int GetHashCode()
        {
            return (Value != null ? Value.GetHashCode() : 0);
        }
    }
}