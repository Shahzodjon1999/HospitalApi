using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Hospital.Application.UpdateRequestModel;
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
    public static Appointment MapToAppointmentUpdate(this AppointmentUpdateRequest request)
    {
        return new Appointment()
        {
            Id = request.Id,
            AppointmentDate = request.AppointmentDate,
            DoctorId = request.DoctorId
        };
    }

    public static AppointmentResponse MapToAppointmentResponse(this Appointment appointment)
	{
		return new AppointmentResponse()
		{
            //DoctorId=appointment.DoctorId,
			Name=appointment.Name,
			AppointmentDate = appointment.AppointmentDate,
			Id=appointment.Id
		};
	}

    public static IEnumerable<AppointmentResponse> MapToAppointmentResponsList(this List<Appointment> appointments)
    {
        List<AppointmentResponse> appointmentlist = new List<AppointmentResponse>();
        foreach (var item in appointments)
        {
            var result = new AppointmentResponse
            {
                Id = item.Id,
				Name= item.Name,
                DoctorName=item.Doctor.FirstName,
                AppointmentDate=item.AppointmentDate,
            };
            appointmentlist.Add(result);
        }
        return appointmentlist;
    }
}
