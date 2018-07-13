using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Sample_Mongo
{
    class Program
    {

        static conDb conn = new conDb();
        static void Main(string[] args)
        {
            getData().Wait();

            //Console.WriteLine("ini adalah sample aplikasi crud menggunakan mongo db !!!");
            //Console.WriteLine("1: tambah data baru");
            //Console.WriteLine("2: lihat semua data");
            //Console.WriteLine("3: hapus data berdasarkan id");
            //Console.WriteLine("4: update data berdasrkan id");

            //var param = Console.ReadLine();
            //if (param == "1")
            //{
            //    InsertData().Wait();
            //}
            //else if (param == "2")
            //{
            //    getData().Wait();
            //}
            //else if (param == "3")
            //{
            //}
            //else if (param == "3")
            //{

            //}
            //else
            //{
            //    Console.WriteLine("Inputan tidak dikenali");
            //}

            //GetListDb().Wait();
        }
        
        static async Task InsertData() {



            var client = new MongoClient(conn.MongoCon());
            IMongoDatabase db = client.GetDatabase("IDG");
            Author author = new Author
            {
                Id = 3,
                FirstName = "tes1",
                LastName = "tes1"
            };
            var collection = db.GetCollection<Author>("authors");
            collection.InsertOne(author);
            Console.Read();


            //var connectionString = "mongodb://localhost:27017";
            //var client = new MongoClient(connectionString);
            //IMongoDatabase db = client.GetDatabase("IDG");
            //var collection = db.GetCollection<BsonDocument>("IDGAuthors");
            //var author1 = new BsonDocument
            //{
            //    {"id", 1},
            //    {"firstname", "Joydip"},
            //    {"lastname", "Kanjilal"}
            //};
            //var author2 = new BsonDocument
            //{
            //    {"id", 2},
            //    {"firstname", "Steve"},
            //    {"lastname", "Smith"}
            //};
            //var author3 = new BsonDocument
            //{
            //    {"id", 3},
            //    {"firstname", "Gary"},
            //    {"lastname", "Stevens"}
            //};
            //var authors = new List<BsonDocument>();
            //authors.Add(author1);
            //authors.Add(author2);
            //authors.Add(author3);
            //collection.InsertMany(authors);
            //Console.Read();

           
        }

     

        static async Task GetListDb() {
            var client = new MongoClient(conn.MongoCon());
            using (var cursor = client.ListDatabases())
            {
                var databaseDocuments = cursor.ToList();
                foreach (var db in databaseDocuments)
                {
                    Console.WriteLine(db["name"].ToString());
                }
            }
            Console.ReadLine();
        }

        static async Task getData() {

            var client = new MongoClient(conn.MongoCon());
            IMongoDatabase db = client.GetDatabase("IDG");
            //var collection =  db.GetCollection<Author>("authors");
            var collection = db.GetCollection<BsonDocument>("authors");

            using (IAsyncCursor<BsonDocument> cursor = await collection.FindAsync(new BsonDocument()))
            {
                while (await cursor.MoveNextAsync())
                {
                    IEnumerable<BsonDocument> batch = cursor.Current;
                    foreach (BsonDocument document in batch)
                    {
                        Console.WriteLine(document);
                        Console.WriteLine();
                    }
                }
            }
            Console.ReadLine();
        }

        
    }
}
