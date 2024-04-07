using MakersSolutions.Application.Services.Customer;
using MakersSolutions.Application.Services.Invoice;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MakersSolutions.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServicesRegistration(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IInvoiceService, InvoiceService>();

            return services;
        }
    }
}
