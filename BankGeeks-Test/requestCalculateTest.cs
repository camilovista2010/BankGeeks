using BankGeeks_BackEnd;
using BankGeeks_BackEnd.Dto;
using BankGeeks_BackEnd.Logic;
using BankGeeks_BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using Xunit;

namespace BankGeeks_Test
{
    public class requestCalculateTest
    {
        Calculate calculate;
        IConfiguration Configuration { get; set; }

        public requestCalculateTest()
        {
            Fibonacci.InstanceFibonacci();
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<requestCalculateTest>();

            Configuration = builder.Build();

            var password = Configuration["PasswordTest"];

            var options = new DbContextOptionsBuilder<GeeksContext>()
               .UseSqlServer(String.Format("Server=tcp:servergeek.database.windows.net,1433;Initial Catalog=ServerGeek;Persist Security Info=False;User ID=administrador;Password={0};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;", password))
               .Options;
            var databaseContext = new GeeksContext(options);

            this.calculate = new Calculate(databaseContext);
        }

        [Fact]
        public void PrimerValorMayor0()
        {
            var request = new RequestCalculate() { firstValue = 0, secondValue = 0 };

            var result = this.calculate.requestCalculate( request );

            Assert.Equal("Primer valor debe ser superior a 0", result.Result.message);
        }

        [Fact]
        public void SegundoValorMayor0()
        {
            var request = new RequestCalculate() { firstValue = 5, secondValue = 0 };

            var result = this.calculate.requestCalculate(request);

            Assert.Equal("Segundo valor debe ser superior a 0", result.Result.message);
        }


        [Fact]
        public void Sumar()
        {
            var request = new RequestCalculate() { firstValue = 20, secondValue = 40 };

            var result = this.calculate.requestCalculate(request);

            Assert.Equal(60, result.Result.calculationRecord.Result);
        }


        [Fact]
        public void PerteneceFibonacci()
        {
            var request = new RequestCalculate() { firstValue = 4, secondValue = 4 };

            var result = this.calculate.requestCalculate(request);

            Assert.True(result.Result.calculationRecord.IsFibonacci);
        }


        [Fact]
        public void CuerpoNull()
        {

            var result = this.calculate.requestCalculate(null);

            Assert.Contains("requerido los valores a sumar", result.Result.message);
        }


        [Fact]
        public void GuardarCalculo()
        {
            var request = new RequestCalculate() { firstValue = 2, secondValue = 2 };

            var result = this.calculate.requestCalculate(request);

            Assert.True(result.Result.success == true);
        }
    }
}
