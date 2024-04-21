using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Mapping;

public static class WorkerMap
{
	public static Worker MapToWorker(this WorkerRequest worker)
	{
		return new Worker
		{
			Id=Guid.NewGuid(),
			DateOfBirth=worker.DateOfBirth,
			DateRegister=worker.DateRegister,
			Address=worker.Address,
			FirstName=worker.FirstName,
			LastName=worker.LastName,
			PhoneNumber=worker.PhoneNumber,
		};
	}
    public static Worker MapToWorkerUpdate(this WorkerUpdateRequest worker)
    {
        return new Worker
        {
            Id = Guid.NewGuid(),
            DateOfBirth = worker.DateOfBirth,
            Address = worker.Address,
            FirstName = worker.FirstName,
            LastName = worker.LastName,
            PhoneNumber = worker.PhoneNumber,
        };
    }

    public static WorkerResponse MapToWorkerResponse(this Worker worker)
	{
		return new WorkerResponse
		{
			Id=worker.Id,
			DateOfBirth=worker.DateOfBirth,
			DateRegister=worker.DateRegister,
			Address=worker.Address,
			FirstName=worker.FirstName,
			LastName=worker.LastName,
			PhoneNumber=worker.PhoneNumber,
        };
	}

	public static IEnumerable<WorkerResponse> MapToWorkerResponsList(this IQueryable<Worker> workers)
	{
		List<WorkerResponse> workersList = new List<WorkerResponse>();
		foreach (var item in workers)
		{
           var result = new WorkerResponse
            {
                Id = item.Id,
                DateOfBirth = item.DateOfBirth,
                DateRegister = item.DateRegister,
                Address = item.Address,
                FirstName = item.FirstName,
                LastName = item.LastName,
                PhoneNumber = item.PhoneNumber,
           };
			workersList.Add(result);
        }
		return workersList;
	}

}
