using Hospital.Api.InterfaceRepositoryes;
using Hospital.Api.InterfaceServices;
using Hospital.Api.Mapping;
using Hospital.Api.Model;
using Hospital.Api.Repositories;
using Hospital.Api.RequestModel;
using Hospital.Api.ResponseModel;

namespace Hospital.Api.Services
{
	public class AppointmentService : IGenericService<AppointmentRequest,AppointmentResponse>
	{
		private readonly HospitalDbRepository<Appointment> _repository;

		public AppointmentService(IHospitalDbRepository<Appointment> repository)
		{
			_repository = (HospitalDbRepository<Appointment>?)repository;
		}

		public string Create(AppointmentRequest item)
		{
			try
			{
				if (item != null)
				{
					var getMapAppointment = item.MapToAppointment();
					_repository.Create(getMapAppointment);
					return $"Created new item with this ID: {getMapAppointment.Id}";
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

		public AppointmentResponse GetById(Guid id)
		{
			try
			{
				var getAppointment = _repository.GetById(id);
				if (getAppointment != null)
				   return getAppointment.MapToAppointmentResponse();
				return null;
			}
			catch (Exception)
			{
				throw;
			}
		
		}

		public IEnumerable<AppointmentResponse> GetAll()
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

		public string Update(Guid guid, AppointmentRequest item)
		{
			try
			{
				var _item = _repository.GetById(guid);
				if (_item is null)
				{
					return "Doctor is not found";
				}
				var mapToAppointment = item.MapToAppointment();
				_repository.Update(guid, mapToAppointment);
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
