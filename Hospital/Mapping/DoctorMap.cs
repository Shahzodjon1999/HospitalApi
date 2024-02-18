using Hospital.Api.Model;
using Hospital.Api.RequestModel;
using Hospital.Api.ResponseModel;

namespace Hospital.Api.Mapping
{
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
}
