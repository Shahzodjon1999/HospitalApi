using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.InterfaceServices;
using Hospital.Application.Mapping;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Services
{
	public class DepartmentService:IGenericService<DepartmentRequest, DepartmentResponse>
	{
		private readonly IHospitalDbRepository<Department> _repository;

		public DepartmentService(IHospitalDbRepository<Department> repository)
        {
			_repository = repository;
		}

        public string Create(DepartmentRequest item)
		{
			try
			{
				if (item != null)
				{
					var getMapDepartment = item.MapToDepartment();
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
					return getDepartment.MapToDepartmentResponse();
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
				//var getAppointment = _repository.GetAll();
				//foreach (var item in getAppointment)
				//{
				// var res2 = item.MapToAppointmentResponse();
				//	return IEnumerable<AppointmentResponse>(res2);
				//}

				// IEnumerable<AppointmentResponse>(getAppointment);
				//if (getAppointment != null)
				//	return getAppointment.Ma;
				return null;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public string Update(Guid guid, DepartmentRequest item)
		{
			try
			{
				var _item = _repository.GetById(guid);
				if (_item is null)
				{
					return "Doctor is not found";
				}
				var getMapDepartment = item.MapToDepartment();
				_repository.Update(guid, getMapDepartment);
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
