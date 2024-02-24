using Hospital.Application.RequestModel;
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
			DepartmentId=doctor.DepartmentId,
			PhoneNumber=doctor.PhoneNumber,
			Positions=doctor.Positions,
		};
	}

	public static DoctorResponse MapToDoctorResponse(this Doctor doctor)
	{
		return new DoctorResponse()
		{
			Id=doctor.Id,
			DepartmentId= doctor.DepartmentId,
			DoctorPatients=doctor.DoctorPatients,
			Positions=doctor.Positions
		};
	}
}
