using Microsoft.Extensions.Configuration;

namespace OCR_4AL2_GR1
{
    public static class JsonAccessor
    {
        public static IConfiguration GetConfiguration()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
               .AddJsonFile($"appsettings.json", true, true);
            return builder.Build();
        }
    }
}
