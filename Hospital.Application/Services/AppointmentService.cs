using AutoMapper;
using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.InterfaceServices;
using Hospital.Application.Mapping;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Hospital.Application.UpdateRequestModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Services
{
    public class AppointmentService : IGenericService<AppointmentRequest, AppointmentUpdateRequest, AppointmentResponse>
	{
		private readonly IAppointmentRepository _repository;
		private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
					return _mapper.Map<IEnumerable<AppointmentResponse>>(getAppointments);

                return null;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public string Update(AppointmentUpdateRequest updateRequest)
		{
			try
			{
				var _item = _repository.GetById(updateRequest.Id);
				if (_item is null)
				{
					return "Doctor is not found";
				}
				var mapToAppointment = updateRequest.MapToAppointmentUpdate();
				_repository.Update(mapToAppointment);
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
