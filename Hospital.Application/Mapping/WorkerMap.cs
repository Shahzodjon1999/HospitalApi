using Hospital.Application.RequestModel;
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
			Role=worker.Role,
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
			Role=worker.Role,
		};
	}
}
