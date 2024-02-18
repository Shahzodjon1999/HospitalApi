using Hospital.Api.Entity;

namespace Hospital.Api.RequestModel
{
    public class BranchRequest: EntityBaseRequest
	{
		public string Location { get; set; } = string.Empty;

		public Guid HospitalID { get; set; }
	}
}
