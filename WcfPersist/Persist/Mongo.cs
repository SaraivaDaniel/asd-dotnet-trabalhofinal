using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;

namespace WcfPersist.Persist
{
	class Mongo
	{
		private static IMongoCollection<BsonDocument> colecao;

		public Mongo()
		{
			string mongoConnection = "mongodb+srv://trabalho:trabalho@cluster0-v62wu.gcp.mongodb.net/test?retryWrites=true";
			var mongoClient = new MongoClient(mongoConnection);
			colecao = mongoClient.GetDatabase("trabalhodotnet").GetCollection<BsonDocument>("mensagem");
		}

		public void Insert(string mensagem)
		{
			var doc = new BsonDocument();
			doc["mensagem"] = mensagem;

			colecao.InsertOne(doc);
		}

	}
}
