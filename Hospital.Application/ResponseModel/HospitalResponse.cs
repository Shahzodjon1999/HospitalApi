using Hospital.Application.Entity;
using Hospital.Domen.Model;
using System.Text.Json.Serialization;

namespace Hospital.Application.ResponseModel
{
	public class HospitalResponse:EntityBaseResponse
	{
		public string Name { get; set; } = string.Empty;

		public string Location { get; set; } = string.Empty;

		[JsonIgnore]
		public List<Branch>? Branches { get; set; }
	}
}
