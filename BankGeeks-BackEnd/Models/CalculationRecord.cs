namespace BankGeeks_BackEnd.Models
{
    public class CalculationRecord
    {
        public long Id { get; set; }
        public int FirstValue { get; set; }
        public int SecondValue { get; set; }
        public int Result { get; set; }
        public bool IsFibonacci { get; set; }
    }
}
