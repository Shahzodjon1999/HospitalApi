using Hospital.Abstract;
using Hospital.Api.InterfaceRepositoryes;
using Hospital.Api.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Hospital.Api.Repositoryes
{
	public class MongoRepository<T> : IMongoDbRepository<T> where T : EntityBase
	{
		private readonly IMongoCollection<T> _items;

		public MongoRepository(IOptions<MongoDBSettings> settings)
		{
			var client = new MongoClient(settings.Value.ConnectionString);

			var database = client.GetDatabase(settings.Value.DatabaseName);

			_items = database.GetCollection<T>(settings.Value.TableName);
		}

		public IEnumerable<T> GetAll()
		{
			return _items.Find(_ => true).ToList();
		}

		public T GetById(Guid id)
		{
			var filter = Builders<T>.Filter.Eq("_id", id.ToString());
			return _items.Find(filter).FirstOrDefault();
		}

		public T Create(T item)
		{
			_items.InsertOne(item);
			return item;
		}

		public bool Update(Guid id, T item)
		{
			var filter = Builders<T>.Filter.Eq("_id", id.ToString());
			var result = _items.ReplaceOne(filter, item);
			return result.IsAcknowledged;
		}

		public bool Delete(Guid id)
		{
			var filter = Builders<T>.Filter.Eq("_id", id.ToString());
			var result = _items.DeleteOne(filter);
			return result.IsAcknowledged;
		}
	}
}
