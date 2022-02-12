using BankGeeks_BackEnd.Dto;
using System.Threading.Tasks;

namespace BankGeeks_BackEnd.Logic
{
    public interface ICalculate
    {
        public Task<ResponseCalculate> requestCalculate(RequestCalculate requestCalculate);
    }
}
