using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microservices.DbContextModels;
using Microservices.Model;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Microservices.ViewModel
{
    public class ProductRepository : IProductRepository 
    {
        //private readonly ConnectionConfiguration _connectionConfiguration = null;
        private readonly ObjectContext _objectContext = null;
        public ProductRepository(IOptions<Settings> settings)
        {
            //_connectionConfiguration = new ConnectionConfiguration(settings);
            _objectContext = new ObjectContext(settings);
        }

        public async Task Add(Product product)
        {
            await _objectContext.Products.InsertOneAsync(product);
        }

        public async Task<long> GetCount()
        {
            return await _objectContext.Products.Find(x => true).CountAsync();
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _objectContext.Products.Find(x => true).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByName(string name)
        {
            string[] arrItemsPlanner = name.Split(" ");
            string query = string.Empty + "{ $and: [";

            foreach (var i in arrItemsPlanner)
            {
                var trim  = i.Substring(0,i.Length-1);
                query += "{ Name: /.*"+ trim + ".*/i },";
            }
            query += "]}";
            // filter = Builders<Product>.Filter.Or(
            //    Builders<Product>.Filter.Where(p => p.Name.Contains(name))
            //    //Builders<Product>.Filter.Regex("Name", new BsonRegularExpression(name.Split(" ")[0], "i")),
            //    //Builders<Product>.Filter.Regex("Name", new BsonRegularExpression(name.Split(" ")[1], "i"))
            //    );
            var result = _objectContext.Products.Find(query).ToListAsync();
          
            return await result;
        }

        public async Task<Product> Get(string id)
        {
            var product = Builders<Product>.Filter.Eq("id", id);
            return await _objectContext.Products.Find(product).FirstOrDefaultAsync();
        }

        public async Task<DeleteResult> Remove(string id)
        {
            var product = Builders<Product>.Filter.Eq("id", id);
            return await _objectContext.Products.DeleteOneAsync(product);

        }

        public async Task<DeleteResult> RemoveAll()
        {
            return await _objectContext.Products.DeleteManyAsync(new BsonDocument());
        }

        public async Task<string> Update(string id, Product product)
        {
            await _objectContext.Products.ReplaceOneAsync(zz => zz.Id == id,product);
            return string.Empty;
        }

    }
}
