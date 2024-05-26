using Hospital.Application.Entity;

namespace Hospital.Application.ResponseModel;

public record PatientInfoResponse: EntityBaseResponse
{
    public string FullName { get; set; }=string.Empty;

    public int RoomNumber { get; set; }

    public int FloorNumber { get; set; }

    public string DepartmentName { get; set; } = string.Empty;

    public string BranchName { get; set; } = string.Empty;

    public string HospitalName { get; set; }= string.Empty;
}
