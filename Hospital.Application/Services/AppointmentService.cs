using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.InterfaceServices;
using Hospital.Application.Mapping;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Services
{
    public class AppointmentService : IGenericService<AppointmentRequest, AppointmentResponse>
	{
		private readonly IHospitalDbRepository<Appointment> _repository;

		public AppointmentService(IHospitalDbRepository<Appointment> repository)
		{
			_repository = repository;
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
				var getAppointments = _repository.GetAll();
				if (getAppointments != null)
					return getAppointments.MapToAppointmentResponsList();
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
					return "Appointment is not found";
				}
				_repository.Delete(id);

				return "Appointment is deleted";
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
