using Hospital.Abstract;
using MongoDB.Driver;

namespace Hospital.Api.Repositoryes
{
	public class MongoDbContextForGeneric<T> where T : EntityBase
	{
		private readonly IMongoDatabase _database;

		public MongoDbContextForGeneric(string connectionString, string databaseName)
		{
			var client = new MongoClient(connectionString);
			_database = client.GetDatabase(databaseName);
		}

		public IMongoCollection<T> Collection => _database.GetCollection<T>(typeof(T).Name);
	}
	
}
