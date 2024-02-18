using Hospital.Api.Model;
using Hospital.Api.RequestModel;
using Hospital.Api.ResponseModel;

namespace Hospital.Api.Mapping
{
	public static class AppointmentMap
	{
		public static Appointment MapToAppointment(this AppointmentRequest request)
		{
			return new Appointment()
			{
				Id=Guid.NewGuid(),
				AppointmentDate=request.AppointmentDate,
				DoctorId=request.DoctorId
			};
		}

		public static AppointmentResponse MapToAppointmentResponse(this Appointment appointment)
		{
			return new AppointmentResponse()
			{
				AppointmentDate = appointment.AppointmentDate,
				DoctorId=appointment.DoctorId,
				Id=appointment.Id
			};
		}
	}
}
