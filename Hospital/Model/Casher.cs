using Hospital.Abstract;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Hospital.Model;

public class Casher:EntityBase
{
	[BsonElement("worker_name")]
	public string WorkerName { get; set; } = string.Empty;

	[BsonElement("client_name")]
	public string ClientName { get; set; }=string.Empty;

	[BsonElement("disease_name")]
	public string DiseaseName { get; set; } = string.Empty;

	[BsonElement("price")]
	public double Price { get; set; }

	[BsonElement("client_pay")]
	public double ClientPay { get; set; }

	[BsonElement("remainder_amount")]
	public double RemainderAmount { get;set; }

	[BsonElement("data_transaction_number")]
	public ulong DataTransactionNumber { get; set; }

	[BsonElement("pay_time")]
	public DateTime PayTime { get; set; }
}
