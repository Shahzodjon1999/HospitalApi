using Hospital.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Domen.Model
{
	public class Salary
	{
        public ulong Id { get; set; }

		public double Amount { get; set; }

        public ulong WorkerId { get; set; }

		public double Bonus { get; set; }
    }
}
