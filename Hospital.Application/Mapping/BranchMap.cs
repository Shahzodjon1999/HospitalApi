using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
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
    public static Branch MapToBranchUpdate(this BranchUpdateRequest request)
    {
        return new Branch
        {
            Id = request.Id,
            Location = request.Location,
        };
    }

    public static BranchResponse MapToBranchResponse(this Branch branch)
	{
		return new BranchResponse
        {
			Id= branch.Id,
			Name= branch.Name,
			Location= branch.Location,
		};
	}

    public static IEnumerable<BranchResponse> MapToBranchResponsList(this IQueryable<Branch> branches)
    {
        List<BranchResponse> branchlist = new List<BranchResponse>();
        foreach (var item in branches)
        {
            var result = new BranchResponse
            {
                Id = item.Id,
				Name= item.Name,
				Location=item.Location,
            };
            branchlist.Add(result);
        }
        return branchlist;
    }
}
