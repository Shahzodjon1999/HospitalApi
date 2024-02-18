using Hospital.Api.Entity;
using Hospital.Api.Model;
using System.Text.Json.Serialization;

namespace Hospital.Api.ResponseModel
{
	public class HospitalResponse:EntityBaseResponse
	{
		public string Name { get; set; } = string.Empty;

		public string Location { get; set; } = string.Empty;

		[JsonIgnore]
		public List<Branch>? Branches { get; set; }
	}
}
