using MakersSolutions.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MakersSolutions.DataAccess.DatabaseContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }
}
