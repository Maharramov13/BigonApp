using BigonApp.Data.Contexts;
using BigonApp.Data.Repositories;
using BigonApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Data
{
    public static class ServicesRegistiration
    {
        public static void DataServicesRegister(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.ConnectionString);
            });
            services.AddScoped<Infrastructure.Repositories.IColorRepository, Repositories.ColorRepository>();
        }
    }
}
