namespace Domain.ValueObjects
{
    public sealed class SolvedDate : ValueObject<SolvedDate>
    {
        public SolvedDate(DateTime value)
        {
            Value = value;
        }

        public DateTime Value { get; }

        protected override bool EqualsCore(SolvedDate other)
        {
            return Value== other.Value; 
        }
    }
}
