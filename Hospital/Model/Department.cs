using Hospital.Abstract;
using Hospital.Models;

namespace Hospital.Api.Model
{
	public class Department:EntityBase
	{
		public string Name { get; set; }=string.Empty;

		public Branch? Branch { get; set; }

		public Guid BranchID { get; set; }

		public List<Doctor>? Doctors { get; set; }
	}
}
