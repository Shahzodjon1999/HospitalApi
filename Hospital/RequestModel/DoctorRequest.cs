using Hospital.Api.Entity;
using Hospital.Api.Model;

namespace Hospital.Api.RequestModel
{
    public class DoctorRequest : EntityBaseRequest
	{
		public string FirstName { get; set; } = string.Empty;

		public string LastName { get; set; } = string.Empty;

		public string PhoneNumber { get; set; } = string.Empty;

		public string Address { get; set; } = string.Empty;

		public DateTime DateOfBirth { get; set; }

		public DateTime DateRegister { get; set; }

		public string Positions { get; set; } = string.Empty;

		public Guid DepartmentId { get; set; }
	}
}
