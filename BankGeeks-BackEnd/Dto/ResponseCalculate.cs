using BankGeeks_BackEnd.Models;

namespace BankGeeks_BackEnd.Dto
{
    public class ResponseCalculate
    {
        public bool success { get; set; }
        public string message { get; set; }
        public CalculationRecord calculationRecord { get; set; }
    }
}
