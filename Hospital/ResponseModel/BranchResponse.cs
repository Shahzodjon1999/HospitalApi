using Hospital.Api.Entity;
using Hospital.Api.Model;
using System.Text.Json.Serialization;

namespace Hospital.Api.ResponseModel
{
	public class BranchResponse:EntityBaseResponse
	{
		public string Location { get; set; } = string.Empty;

		public Guid HospitalID { get; set; }

		[JsonIgnore]
		public List<Department>? Departments { get; set; }
	}
}
