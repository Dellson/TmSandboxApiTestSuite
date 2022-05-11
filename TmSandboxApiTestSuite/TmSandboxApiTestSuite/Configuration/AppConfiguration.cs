using Microsoft.Extensions.Configuration;

namespace TmSandboxApiTestSuite.Configuration
{
    internal class AppConfiguration
    {
        private readonly IConfiguration _config;

        public string BaseUrl
        {
            get
            {
                return _config.GetSection("AppSettings").GetSection("BaseUrl").Value;
            }
        }

        public AppConfiguration()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.local.json")
                .Build();
        }
    }
}
