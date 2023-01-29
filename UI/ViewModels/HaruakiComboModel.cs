namespace UI.ViewModels
{
    public class HaruakiComboModel
    {
        public HaruakiComboModel(int value, string displayValue)
        {
            Value = value;
            DisplayValue = displayValue;
        }

        public int Value { get; }
        public string DisplayValue { get; }
    }
}
