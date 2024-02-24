using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Mapping;

public static class DepartmentMap
{
	public static Department MapToDepartment(this DepartmentRequest request)
	{
		return new Department
		{
			Id = Guid.NewGuid(),
			BranchID= request.BranchID,
			Name = request.Name,
		};
	}

	public static DepartmentResponse MapToDepartmentResponse(this Department item)
	{
		return new DepartmentResponse
		{
			Id = item.Id,
			BranchID= item.BranchID,
			DepartmentPatients= item.DepartmentPatients,
			Doctors= item.Doctors,
			Name= item.Name,
		};
	}
}
