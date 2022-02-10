using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCR_4AL2_GR1
{
    public static class JsonAccessor
    {
        public static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
               .AddJsonFile($"appsettings.json", true, true);
            IConfiguration config = builder.Build();
            return config;
        }
    }
}
