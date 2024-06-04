using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Data
{
    public class Configuration
    {
        public static string ConnectionString 
        {
            get
            {
                ConfigurationManager configurationManager = new ConfigurationManager();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../BigonApp.MVC"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("msSql");

            }


        }
    }
}
