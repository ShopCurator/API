using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Driver;

namespace Microservices.Model
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> Get(string id);
        Task<IEnumerable<Product>> GetByName(string name);
        Task Add(Product product);
        Task<string> Update(string id , Product product);
        Task<DeleteResult> Remove(string id);
        Task<DeleteResult> RemoveAll();
    }
}
