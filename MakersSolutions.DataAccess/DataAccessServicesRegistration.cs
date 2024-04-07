using MakersSolutions.Application.Contracts;
using MakersSolutions.DataAccess.DatabaseContext;
using MakersSolutions.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakersSolutions.DataAccess
{
    public static class DataAccessServicesRegistration
    {
        public static IServiceCollection AddDataAccessServicesRegistration (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();

            return services;
        }
    }
}
