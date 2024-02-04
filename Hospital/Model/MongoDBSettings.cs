using Hospital.Api.Repositoryes;
using MongoDB.Driver;
using System.Xml;

namespace Hospital.Api.Model
{
	public class MongoDBSettings
	{
		public string ConnectionString { get; set; }

		public string DatabaseName { get; set; }

		public string TableName { get; set; }
	}
}
