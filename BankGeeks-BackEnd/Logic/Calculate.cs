using BankGeeks_BackEnd.Dto;
using BankGeeks_BackEnd.Models;
using System.Threading.Tasks;

namespace BankGeeks_BackEnd.Logic
{
    public class Calculate : ICalculate
    {
        private readonly GeeksContext _geeksContext;

        public Calculate(GeeksContext geeksContext)
        {

            _geeksContext = geeksContext;
        }

        public async Task<ResponseCalculate>  requestCalculate(RequestCalculate requestCalculate)
        {

            try
            {
                if (requestCalculate == null)
                {
                    return new ResponseCalculate() { success = false, message = "Es requerido los valores a sumar" };
                }

                if (requestCalculate.firstValue <= 0)
                {
                    return new ResponseCalculate() { success = false, message = "Primer valor debe ser superior a 0" };
                }

                if (requestCalculate.secondValue <= 0)
                {
                    return new ResponseCalculate() { success = false, message = "Segundo valor debe ser superior a 0" };
                }

                ResponseCalculate response = new ResponseCalculate()
                {
                    success = false,
                    message = "",
                    calculationRecord = new CalculationRecord()
                    {
                        FirstValue = requestCalculate.firstValue,
                        SecondValue = requestCalculate.secondValue,
                        Result = requestCalculate.firstValue + requestCalculate.secondValue,
                        IsFibonacci = false
                    }
                };

                response.calculationRecord.IsFibonacci = Fibonacci.listFibonacci
                    .Contains(response.calculationRecord.Result);

                _geeksContext.CalculationRecords.Add(response.calculationRecord);
                int onchange = await _geeksContext.SaveChangesAsync();
                response.success = onchange > 0; 

                return response;
            }
            catch (System.Exception e)
            {
                return new ResponseCalculate() { success = false, calculationRecord = null, message = e.Message }; 
            } 
            
        }
    }
}
