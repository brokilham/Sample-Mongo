using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Mongo
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase("myNewDB”");
            Author author = new Author
            {
                Id = 1,
                FirstName = "Joydip",
                LastName = "Kanjilal"
            };
            var collection = db.GetCollection<Author>("authors");
            collection.InsertOne(author);
            Console.Read();
        }

        
    }
}
