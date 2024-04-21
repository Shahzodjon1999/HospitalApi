using AutoMapper;
using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Services
{
    public class DepartmentService:IGenericService<DepartmentRequest,DepartmentUpdateRequest, DepartmentResponse>
	{
		private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository repository, IMapper mapper)
        {
			_repository = repository;
            _mapper = mapper;
        }

        public string Create(DepartmentRequest item)
		{
			try
			{
				if (item != null)
				{
					var getMapDepartment = _mapper.Map<Department>(item);
					_repository.Create(getMapDepartment);
					return $"Created new item with this ID: {getMapDepartment.Id}";
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

		public DepartmentResponse GetById(Guid id)
		{
			try
			{
				var getDepartment = _repository.GetById(id);
				if (getDepartment != null)
					return _mapper.Map<DepartmentResponse>(getDepartment);
				return null;
			}
			catch (Exception)
			{
				throw;
			}

		}

		public IEnumerable<DepartmentResponse> GetAll()
		{
			try
			{
				var getDepartments = _repository.GetAll();
				if (getDepartments != null)
					return _mapper.Map<IEnumerable<DepartmentResponse>>(getDepartments);
				return null;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public string Update(DepartmentUpdateRequest updateRequest)
		{
			try
			{
				var _item = _repository.GetById(updateRequest.Id);
				if (_item is null)
				{
					return "Doctor is not found";
				}
				var getMapDepartment =_mapper.Map<Department>(updateRequest);
				_repository.Update(getMapDepartment);
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
