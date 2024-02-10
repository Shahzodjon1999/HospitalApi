using Hospital.Abstract;
using Hospital.Api.InterfaceRepositoryes;
using Hospital.Api.Model;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Hospital.Api.Repositoryes
{
	public class MongoRepository<T> : IMongoDbRepository<T> where T : EntityBase
	{
		private readonly IMongoCollection<T> _items;

		public MongoRepository(IOptions<> settings)
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

		public async Task<bool> Update(Guid id, T item)
		{
			var filter = Builders<T>.Filter.Eq("_id", id.ToString());
			var result = await _items.Find(filter).FirstOrDefaultAsync() ?? default;

			if (result == null)
			{
				throw new NullReferenceException();
			}

			if (result is not null)
			{
			  var s = await _items.ReplaceOneAsync(filter,   cancellationToken:CancellationToken.None);
			}

			return true;
		}

		public bool Delete(Guid id)
		{
			var filter = Builders<T>.Filter.Eq("_id", id.ToString());
			var result = _items.DeleteOne(filter);
			return result.IsAcknowledged;
		}
	}
}
