using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BankGeeks_BackEnd.Models
{
    public class GeeksContext : DbContext
    {
        public GeeksContext(DbContextOptions<GeeksContext> options) : base(options) { }

        public DbSet<CalculationRecord> CalculationRecords { get; set; }

    }
}
