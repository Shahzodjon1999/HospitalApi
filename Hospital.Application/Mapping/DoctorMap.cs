using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Mapping;

public static class DoctorMap
{
	public static Doctor MapToDoctor(this DoctorRequest doctor)
	{
		return new Doctor()
		{
			Id = Guid.NewGuid(),
			FirstName = doctor.FirstName,
			LastName = doctor.LastName,
			Address=doctor.Address,
			DateOfBirth=doctor.DateOfBirth,
			DateRegister=doctor.DateRegister,
			PhoneNumber=doctor.PhoneNumber,
            DepartmentId=doctor.DepartmentId,
		};
	}
   
    public static Doctor MapToDoctorUpdate(this DoctorUpdateRequest doctor)
    {
        return new Doctor()
        {
            Id = doctor.Id,
            FirstName = doctor.FirstName,
            LastName = doctor.LastName,
            Address = doctor.Address,
            DateOfBirth = doctor.DateOfBirth,
            DateRegister = doctor.DateRegister,
            PhoneNumber = doctor.PhoneNumber,
            DepartmentId= doctor.DepartmentId,
        };
    }
    public static DoctorResponse MapToDoctorResponse(this Doctor doctor)
	{
		return new DoctorResponse()
		{
			Id=doctor.Id,
            FirstName = doctor.FirstName,
            LastName = doctor.LastName,
            Address = doctor.Address,
            DateOfBirth = doctor.DateOfBirth,
            DateRegister = doctor.DateRegister,
            PhoneNumber = doctor.PhoneNumber,
		};
	}
    public static IEnumerable<DoctorResponse> MapToDoctorResponsList(this IQueryable<Doctor> branches)
    {
        List<DoctorResponse> departmentlist = new List<DoctorResponse>();
        foreach (var item in branches)
        {
            var result = new DoctorResponse
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Address = item.Address,
                DateOfBirth = item.DateOfBirth,
                DateRegister = item.DateRegister,
                PhoneNumber = item.PhoneNumber,
            };
            departmentlist.Add(result);
        }
        return departmentlist;
    }
}
