using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Todo.Data
{
    public class Contexto : IDisposable
    {
        private IMongoClient mongoClient;
        private IMongoDatabase mongoDatabase;

        public Contexto(IConfiguration configuration)
        {
            mongoClient = new MongoClient(configuration.GetConnectionString("Mongo"));
            if(mongoClient != null){
                mongoDatabase = mongoClient.GetDatabase("Teste");
            }
        }

        public IMongoCollection<Entities.Todo> Todos
        {
            get
            {
                return mongoDatabase.GetCollection<Entities.Todo>("Todo");
            }
        }

        public void Dispose()
        {
            mongoClient = null;
            mongoDatabase = null;
        }
    }
}