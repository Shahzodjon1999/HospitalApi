using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Mapping;

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

    public static IEnumerable<AppointmentResponse> MapToAppointmentResponsList(this IQueryable<Appointment> appointments)
    {
        List<AppointmentResponse> appointmentlist = new List<AppointmentResponse>();
        foreach (var item in appointments)
        {
            var result = new AppointmentResponse
            {
                Id = item.Id,
                AppointmentDate=item.AppointmentDate,
				DoctorId=item.DoctorId,
            };
            appointmentlist.Add(result);
        }
        return appointmentlist;
    }
}
