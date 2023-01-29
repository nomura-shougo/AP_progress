namespace Domain.ValueObjects
{
    public sealed class Score :ValueObject<Score>
    {
        public Score(int value)
        {
            if(value < 0
               || value > 100)
            {
                throw new ArgumentException();

            }

            Value = value;
        }

        public int Value { get; }

        protected override bool EqualsCore(Score other)
        {
            return Value == other.Value;
        }
    }
}
