using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Hospital.Abstract;

public abstract class EntityBase
{
	[BsonId]
	[BsonRepresentation(BsonType.String)]
	public Guid Id { get;} = Guid.NewGuid();
}
