using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;

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
		};
	}
    public static IEnumerable<HospitalResponse> MapToHospitalResponsList(this IQueryable<Domen.Model.Hospital> hospital)
    {
        List<HospitalResponse> appointmentlist = new List<HospitalResponse>();
        foreach (var item in hospital)
        {
            var result = new HospitalResponse
            {
                Id = item.Id,
                Location = item.Location,
                Name = item.Name,
            };
            appointmentlist.Add(result);
        }
        return appointmentlist;
    }
}
