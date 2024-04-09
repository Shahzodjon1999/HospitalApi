using Hospital.Domen.Enam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Domen.Model
{
	public class Casher
	{
		public ulong Id { get; set; }

		public string WorkerName { get; set; } = string.Empty;

		public string ClientName { get; set; }=string.Empty;

		public string DiseaseName { get; set; } = string.Empty;

		public string NumberPhone { get; set; } = string.Empty;

		public double Price { get; set; }

		public double ClientPay { get; set; }

		public double RemainderAmount { get;set; }

		public ulong DataTransactionNumber { get; set; }

		public DateTime PayTime { get; set; }
		
	}
}
