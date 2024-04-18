using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Mapping;

public static class PatientMap
{
	public static Patient MapToPatient(this PatientRequest request)
	{
		return new Patient
		{
			Id=Guid.NewGuid(),
			Address=request.Address,
			DateOfBirth=request.DateOfBirth,
			DateRegister=request.DateRegister,
			Disease=request.Disease,
			RoomID=request.RoomId,
			FirstName=request.FirstName,
			LastName=request.LastName,
			PhoneNumber=request.PhoneNumber,
			State=request.State,
		};
	}

    public static Patient MapToPatientUpdate(this PatientUpdateRequest request)
    {
        return new Patient
        {
            Id = request.Id,
            Address = request.Address,
            DateOfBirth = request.DateOfBirth,
            DateRegister = request.DateRegister,
            Disease = request.Disease,
            RoomID = request.RoomId,
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber,
            State = request.State,
        };
    }

    public static PatientResponse MapToPatinetResponse(this Patient patient)
	{
		return new PatientResponse
		{
			Id=patient.Id,
			Disease = patient.Disease,
			State=patient.State,
			LastName=patient.LastName,
			Address=patient.Address,
			DateOfBirth=patient.DateOfBirth,
			DateRegister=patient.DateRegister,
			FirstName=patient.FirstName,
			PhoneNumber = patient.PhoneNumber,
            RoomNumber = patient.Room.RoomNumber
        };
	}

    public static IEnumerable<PatientResponse> MapToPatientResponsList(this IQueryable<Patient> patients)
    {
        List<PatientResponse> patientlist = new List<PatientResponse>();
        foreach (var patient in patients)
        {
            var result = new PatientResponse
            {
                Id = patient.Id,
                Disease = patient.Disease,
                State = patient.State,
                LastName = patient.LastName,
                Address = patient.Address,
                DateOfBirth = patient.DateOfBirth,
                DateRegister = patient.DateRegister,
                FirstName = patient.FirstName,
                PhoneNumber = patient.PhoneNumber,
                RoomNumber = patient.Room.RoomNumber
            };
            patientlist.Add(result);
        }
        return patientlist;
    }
}
