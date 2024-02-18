using Hospital.Api.InterfaceRepositoryes;
using Hospital.Api.InterfaceServices;
using Hospital.Api.Mapping;
using Hospital.Api.Model;
using Hospital.Api.RequestModel;
using Hospital.Api.ResponseModel;

namespace Hospital.Api.Services
{
	public class FloorService:IGenericService<FloorRequest,FloorResponse>
	{
		private readonly IHospitalDbRepository<Floor> _repository;

		public FloorService(IHospitalDbRepository<Floor> repository)
		{
			_repository = repository;
		}

		public string Create(FloorRequest item)
		{
			try
			{
				if (item != null)
				{
					var getMapFloor = item.MapToFloor();
					_repository.Create(getMapFloor);
					return $"Created new item with this ID: {getMapFloor.Id}";
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

		public FloorResponse GetById(Guid id)
		{
			try
			{
				var getFloor = _repository.GetById(id);
				if (getFloor != null)
					return getFloor.MapToFloorResponse();
				return null;
			}
			catch (Exception)
			{
				throw;
			}

		}

		public IEnumerable<FloorResponse> GetAll()
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

		public string Update(Guid guid, FloorRequest item)
		{
			try
			{
				var _item = _repository.GetById(guid);
				if (_item is null)
				{
					return "Doctor is not found";
				}
				var getMapFloor = item.MapToFloor();
				_repository.Update(guid, getMapFloor);
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
