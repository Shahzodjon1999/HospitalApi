using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.InterfaceServices;
using Hospital.Application.Mapping;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Services
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
				var getBranchs = _repository.GetAll();
				if (getBranchs != null)
					return getBranchs.MapToBranchResponsList();
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
