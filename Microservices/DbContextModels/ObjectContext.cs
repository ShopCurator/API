using System;
using Microservices.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Microservices.DbContextModels
{
    public class ObjectContext : ConnectionConfiguration
    {

        public ObjectContext(IOptions<Settings> settings) : base(settings)
        {
        }

        public IMongoCollection<Product> Products
        {
            get
            {

                return database.GetCollection<Product>("Products");
            }

        }
    }
}
