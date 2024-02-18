using Hospital.Abstract;
using Hospital.Models;

namespace Hospital.Api.Model
{
	public class DepartmentPatient:EntityBase
	{
		public Department? Department { get; set; }
		public Guid DepartmentId { get; set; }

		public Patient? Patient { get; set; }
		public Guid PatientId { get; set; }
	}
}
