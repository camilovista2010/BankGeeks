using BankGeeks_BackEnd.Dto;
using BankGeeks_BackEnd.Logic;
using Microsoft.AspNetCore.Mvc;

namespace BankGeeks_BackEnd.Controllers
{

    [ApiController]
    [Route("calculate")]
    public class CalculateController : ControllerBase
    {
        private readonly ICalculate calculate;

        public CalculateController(ICalculate calculate)
        {
            this.calculate = calculate;
        }


        [ProducesResponseType(typeof(ResponseCalculate) , 200)]
        [HttpPost]
        public IActionResult requestCalculate([FromBody]RequestCalculate requestCalculate)
        {
            try
            { 
                return Ok(this.calculate.requestCalculate(requestCalculate).Result);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Error en el servidor : {ex.Message}");
            }
        }
    }
}
