namespace Domain.ValueObjects
{
    public sealed class Haruaki:ValueObject<Haruaki>
    {
        /// <summary>
        /// 春
        /// </summary>
        public static readonly Haruaki Haru = new Haruaki(1);

        /// <summary>
        /// 秋
        /// </summary>
        public static readonly Haruaki Aki = new Haruaki(2);

        public Haruaki(int value)
        {
            Value = value;
        }


        public int Value { get; }

        public string DisplayValue
        {
            get
            {
                if (this == Haru)
                {
                    return "春";
                }

                if (this == Aki)
                {
                    return "秋";
                }

                return "不明";
            }
        }
        protected override bool EqualsCore(Haruaki other)
        {
            return this.Value == other.Value;
        }

        public static List<Haruaki> GetAll()
        {
            return new List<Haruaki>
            {
                Haru,
                Aki,
            };
        }

    }
}
