using BankGeeks_BackEnd.Dto;
using BankGeeks_BackEnd.Logic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankGeeks_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {

        private readonly ICalculate calculate;

        public CalculatorController(ICalculate calculate)
        {
            this.calculate = calculate;
        }
         
        [HttpPost]
        public ResponseCalculate Post([FromBody] RequestCalculate value)
        {
            try
            {
                var result = this.calculate.requestCalculate(value).Result;
                return result;
            }
            catch (System.Exception ex)
            {
                return new ResponseCalculate() { success = false , message = ex.Message , calculationRecord = null };
            }
        }

    }
}
