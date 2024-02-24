using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Mapping;

public static class BranchMap
{
	public static Branch MapToBranch(this BranchRequest request)
	{
		return new Branch
		{
			Id=Guid.NewGuid(),
			HospitalID=request.HospitalID,
			Location=request.Location,
		};
	}

	public static BranchResponse MapToBranchResponse(this Branch branch)
	{
		return new BranchResponse
		{
			Id= branch.Id,
			Departments=branch.Departments,
			HospitalID=branch.HospitalID,
			Location= branch.Location,
		};
	}
}
