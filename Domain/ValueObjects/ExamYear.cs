namespace Domain.ValueObjects
{
    public sealed class ExamYear : ValueObject<ExamYear>
    {
        public ExamYear(int value)
        {
            if(value < 0)
            {
                throw new ArgumentException();
            }

            Value = value;
        }

        public int Value { get; }

        protected override bool EqualsCore(ExamYear other)
        {
            return Value == other.Value;
        }
    }
}
