using MakersSolutions.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MakersSolutions.DataAccess.DatabaseContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }
}
