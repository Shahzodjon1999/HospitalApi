using Hospital.Api.Entity;

namespace Hospital.Api.RequestModel
{
    public class FloorRequest : EntityBaseRequest
	{
		public string Name { get; set; } = string.Empty;

		public int FloorNumber { get; set; }
	}
}
