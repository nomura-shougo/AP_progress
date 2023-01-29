namespace Domain.ValueObjects
{ 
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        public override bool Equals(object? obj)
        {
            if (obj == null) { return false; }
            T vo = (T) obj;

            return EqualsCore(vo);
        }

        public static bool operator ==(ValueObject<T> vo1,
            ValueObject<T> vo2)
        {
            return Equals(vo1, vo2);
        }

        public static bool operator !=(ValueObject<T> vo1,
           ValueObject<T> vo2)
        {
            return !Equals(vo1, vo2);
        }

        protected abstract bool EqualsCore(T other);

        public override string ToString()
        {
            string str = base.ToString() ?? string.Empty;
            return str;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
