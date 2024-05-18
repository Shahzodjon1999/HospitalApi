using AutoMapper;
using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Services
{
    public class DoctorService : IGenericService<DoctorRequest,DoctorUpdateRequest, DoctorResponse>
	{
		private readonly IDoctorRepository _repository;

		private readonly IMapper _mapper;
        public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _repository = doctorRepository;
            _mapper = mapper;
        }

        public string Create(DoctorRequest doctor)
		{
			if (string.IsNullOrEmpty(doctor.FirstName))
			{
				return "The name cannot be empty";
			}
			else
			{
				var mapDoctor = _mapper.Map<Doctor>(doctor);
				_repository.Create(mapDoctor);
							
                return $"Created new item with this ID: {mapDoctor.Id}";
			}
		}

		public string Delete(Guid id)
		{
			var _item = _repository.GetById(id);
			if (_item is null)
			{
				return "Doctor is not found";
			}
			_repository.Delete(id);

			return "Doctor is deleted";
		}

		public DoctorResponse GetById(Guid id)
		{
			try
			{
				var mapDoctorResponse = _repository.GetById(id);
				if (mapDoctorResponse is null)
				{
					return null;
				}
				return _mapper.Map<DoctorResponse>(mapDoctorResponse);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public IEnumerable<DoctorResponse> GetAll()
		{
            try
            {
                var getDoctors = _repository.GetAll();
                if (getDoctors != null)
					return _mapper.Map<IEnumerable<DoctorResponse>>(getDoctors);
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

		public string Update(DoctorUpdateRequest doctor)
		{
			var _item = _repository.GetById(doctor.Id);
			if (_item is null)
			{
				return "Doctor is not found";
			}
			var mapDoctor = _mapper.Map<Doctor>(doctor);
			mapDoctor.DepartmentId = _item.DepartmentId;
			_repository.Update(mapDoctor);
			return "Doctor is updated";
		}
	}
}
