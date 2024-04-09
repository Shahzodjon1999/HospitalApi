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
			Name= item.Name,
		};
	}
    public static IEnumerable<DepartmentResponse> MapToDepartmentResponsList(this IQueryable<Department> branches)
    {
        List<DepartmentResponse> departmentlist = new List<DepartmentResponse>();
        foreach (var item in branches)
        {
            var result = new DepartmentResponse
            {
                Id = item.Id,
                BranchID=item.BranchID,
				Name= item.Name,
            };
            departmentlist.Add(result);
        }
        return departmentlist;
    }
}
