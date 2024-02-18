using Hospital.Api.Entity;
using Hospital.Api.Model;

namespace Hospital.Api.RequestModel
{
    public class DepartmentRequest : EntityBaseRequest
	{
		public string Name { get; set; } = string.Empty;

		public Guid BranchID { get; set; }
	}
}
