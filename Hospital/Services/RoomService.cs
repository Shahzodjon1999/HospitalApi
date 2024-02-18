using Hospital.Api.InterfaceRepositoryes;
using Hospital.Api.InterfaceServices;
using Hospital.Api.Mapping;
using Hospital.Api.Model;
using Hospital.Api.RequestModel;
using Hospital.Api.ResponseModel;

namespace Hospital.Api.Services
{
	public class RoomService:IGenericService<RoomRequest,RoomResponse>
	{
		private readonly IHospitalDbRepository<Room> _repository;

		public RoomService(IHospitalDbRepository<Room> repository)
		{
			_repository = repository;
		}

		public string Create(RoomRequest item)
		{
			try
			{
				if (item != null)
				{
					var getMapRoom = item.MapToRoom();
					_repository.Create(getMapRoom);
					return $"Created new item with this ID: {getMapRoom.Id}";
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

		public RoomResponse GetById(Guid id)
		{
			try
			{
				var getRoom = _repository.GetById(id);
				if (getRoom != null)
					return getRoom.MapToRoomResponse();
				return null;
			}
			catch (Exception)
			{
				throw;
			}

		}

		public IEnumerable<RoomResponse> GetAll()
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

		public string Update(Guid guid, RoomRequest item)
		{
			try
			{
				var _item = _repository.GetById(guid);
				if (_item is null)
				{
					return "Doctor is not found";
				}
				var getMapRoom = item.MapToRoom();
				_repository.Update(guid, getMapRoom);
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
