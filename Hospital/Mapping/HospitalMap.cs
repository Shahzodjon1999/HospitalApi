using Hospital.Api.RequestModel;
using Hospital.Api.ResponseModel;

namespace Hospital.Api.Mapping
{
	public static class HospitalMap
	{
		public static Model.Hospital MapToHospital(this HospitalRequest request)
		{
			return new Model.Hospital
			{
				Id=Guid.NewGuid(),
				Location=request.Location,
				Name=request.Name,
			};
		}

		public static HospitalResponse MapToHospitalResponse(this Model.Hospital hospital)
		{
			return new HospitalResponse
			{
				Id=hospital.Id,
				Location=hospital.Location,
				Name=hospital.Name,
				Branches=hospital.Branches,
			};
		}
	}
}
