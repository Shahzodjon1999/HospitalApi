using Hospital.Abstract;
using System;

namespace Hospital.Model;

public class Casher:EntityBase
{
	public string WorkerName { get; set; } = string.Empty;

	public string ClientName { get; set; }=string.Empty;

	public string DiseaseName { get; set; } = string.Empty;

	public double Price { get; set; }

	public double ClientPay { get; set; }

	public double RemainderAmount { get;set; }

	public ulong DataTransactionNumber { get; set; }

	public DateTime PayTime { get; set; }
}
