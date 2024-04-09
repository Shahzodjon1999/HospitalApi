using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Domen.Models
{
	public class Services
	{
		public ulong Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public double Amount { get; set; }
	}
}
