using Hospital.Application.Entity;
using Hospital.Domen.Model;
using System.Text.Json.Serialization;

namespace Hospital.Application.ResponseModel
{
	public class BranchResponse : EntityBaseResponse
	{
		public string Location { get; set; } = string.Empty;

		public Guid HospitalID { get; set; }

		[JsonIgnore]
		public List<Department>? Departments { get; set; }
	}
}
