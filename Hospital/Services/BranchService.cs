using Hospital.Api.InterfaceRepositoryes;
using Hospital.Api.InterfaceServices;
using Hospital.Api.Mapping;
using Hospital.Api.Model;
using Hospital.Api.RequestModel;
using Hospital.Api.ResponseModel;

namespace Hospital.Api.Services
{
	public class BranchService : IGenericService<BranchRequest, BranchResponse>
	{
		private readonly IHospitalDbRepository<Branch> _repository;

		public BranchService(IHospitalDbRepository<Branch> repository)
        {
			_repository = repository;
		}

		public string Create(BranchRequest item)
		{
			try
			{
				if (item != null)
				{
					var getMapBranch = item.MapToBranch();
					_repository.Create(getMapBranch);
					return $"Created new item with this ID: {getMapBranch.Id}";
				}
				else
				{
					return "The name cannot be empty";
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public BranchResponse GetById(Guid id)
		{
			try
			{
				var getBranch = _repository.GetById(id);
				if (getBranch != null)
					return getBranch.MapToBranchResponse();
				return null;
			}
			catch (Exception)
			{
				throw;
			}

		}

		public IEnumerable<BranchResponse> GetAll()
		{
			try
			{
				//var getBranch = _repository.GetAll();
				//foreach (var item in getBranch)
				//{
				// var res2 = item.MapToAppointmentResponse();
				//	return IEnumerable<AppointmentResponse>(res2);
				//}

				// IEnumerable<AppointmentResponse>(getBranch);
				//if (getBranch != null)
				//	return getBranch.Ma;
				return null;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public string Update(Guid guid, BranchRequest item)
		{
			try
			{
				var _item = _repository.GetById(guid);
				if (_item is null)
				{
					return "Doctor is not found";
				}
				var getMapBranch = item.MapToBranch();
				_repository.Update(guid, getMapBranch);
				return "Doctor is updated";
			}
			catch (Exception)
			{
				throw;
			}
		}

		public string Delete(Guid id)
		{
			try
			{
				var _item = _repository.GetById(id);
				if (_item is null)
				{
					return "Doctor is not found";
				}
				_repository.Delete(id);

				return "Doctor is deleted";
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
