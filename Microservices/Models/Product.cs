using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Microservices.Model
{
    public class Product
    {
        public Product()
        {
        }

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name
        {
            get;
            set;
        }
        public string Brand
        {
            get;
            set;
        }
        public string SellerCompany
        {
            get;
            set;
        }
        public string Price
        {
            get;
            set;
        }
        public long Created {
            get;
            set;
        }
        

    }
}
