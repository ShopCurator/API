using System;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microservices.Model;

namespace Microservices.DbContextModels
{
    public class ConnectionConfiguration
    {
        public IConfigurationRoot IConfigurationRoot { get; }
        public IMongoDatabase database = null;

        public ConnectionConfiguration(IOptions<Settings> settings)
        {
            IConfigurationRoot = settings.Value.IConfigurationRoot;
            //
            settings.Value.ConnectionString = IConfigurationRoot.GetSection("MongoConnection:ConnectionString").Value;
            settings.Value.Database = IConfigurationRoot.GetSection("MongoConnection:Database").Value;

            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
            {
                database = client.GetDatabase(settings.Value.Database);
            }
        }
       
    }
}
