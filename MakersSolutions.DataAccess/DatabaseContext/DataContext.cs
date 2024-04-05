using MakersSolutions.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MakersSolutions.DataAccess.DatabaseContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Factura> Facturas { get; set; }
    }
}
