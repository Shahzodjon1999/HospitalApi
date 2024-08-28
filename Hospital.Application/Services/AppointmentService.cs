using AutoMapper;
using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Hospital.Application.Sms;
using Hospital.Application.UpdateRequestModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Services;

public class AppointmentService : IGenericService<AppointmentRequest, AppointmentUpdateRequest, AppointmentResponse>
{
    private readonly IAppointmentRepository _repository;
	private readonly IMapper _mapper;
	private readonly QueueEntryService _queueEntryService;
    public AppointmentService(IAppointmentRepository repository, IMapper mapper, QueueEntryService queueEntryService)
    {
        _repository = repository;
        _mapper = mapper;
        _queueEntryService = queueEntryService;
    }

    public string Create(AppointmentRequest item)
	{
		try
		{
			if (item != null)
			{
				var getMapAppointment = _mapper.Map<Appointment>(item);
                _repository.Create(getMapAppointment);
				QueueEntryRequest queueEntryRequest = new QueueEntryRequest()
				{
					AppointmentId = getMapAppointment.Id
				};
			   _queueEntryService.EnqueueAppointmentAsync(queueEntryRequest).Wait();
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
			   return _mapper.Map<AppointmentResponse>(getAppointment);
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
				return "Appointment is not found";
			}
			var mapToAppointment = _mapper.Map<Appointment>(updateRequest);
			mapToAppointment.DoctorId = _item.DoctorId;
			_repository.Update(mapToAppointment);
			return "Appointment is updated";
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

    public void SendSms()
    {
		var getClients = _repository.GetAll();

		foreach (var item in getClients)
		{
            if (DateTime.Now > item.AppointmentDate.AddMinutes(30))
            {
				SmsSender.SendEmail(item.Email, "Доктор шумоя интизор аст", $"Шумо саоти {item.AppointmentDate} ба пеши духтур хозир шавед");
            }
        }
    }
    public async Task<bool> CheckAppointment(Guid doctorId, DateTime appointmentDate)
    {
        return await _repository.CheckAppointmentExistsAsync(doctorId, appointmentDate);
    }
}
