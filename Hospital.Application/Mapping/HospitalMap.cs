using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;

namespace Hospital.Application.Mapping;

public static class HospitalMap
{
	public static Domen.Model.Hospital MapToHospital(this HospitalRequest request)
	{
		return new Domen.Model.Hospital
		{
			Id=Guid.NewGuid(),
			Location=request.Location,
			Name=request.Name,
		};
	}

	public static HospitalResponse MapToHospitalResponse(this Domen.Model.Hospital hospital)
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
