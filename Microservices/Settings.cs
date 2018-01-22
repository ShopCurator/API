using System;
using Microsoft.Extensions.Configuration;

namespace Microservices
{
    public class Settings
    {
        public Settings()
        {
        }

        public string ConnectionString { get; set; }

        public string Database { get; set; }

        public IConfigurationRoot IConfigurationRoot { get; set; }
    }
}
