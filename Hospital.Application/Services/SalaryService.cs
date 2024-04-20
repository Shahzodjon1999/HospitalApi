using AutoMapper;
using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.InterfaceServices;
using Hospital.Application.Mapping;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;

namespace Hospital.Application.Services;

public class SalaryService : IGenericService<SalaryRequest, SalaryUpdateRequest, SalaryResponse>
{
    private readonly ISalaryRepository _repository;
    private readonly IMapper _mapper;

    public SalaryService(ISalaryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public string Create(SalaryRequest item)
    {
        try
        {
            if (item != null)
            {
                var getSalary = item.MapToSalary();
                _repository.Create(getSalary);
                return $"Created new item with this ID: {getSalary.Id}";
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

    public string Delete(Guid id)
    {
        try
        {
            var _item = _repository.GetById(id);
            if (_item is null)
            {
                return "Salary is not found";
            }
            _repository.Delete(id);

            return "Salary is deleted";
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IEnumerable<SalaryResponse> GetAll()
    {
        try
        {
            var getSalarys = _repository.GetAll();
            if (getSalarys != null)
                return _mapper.Map<IEnumerable<SalaryResponse>>(getSalarys);
            return null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public SalaryResponse GetById(Guid id)
    {
        try
        {
            var getSalaryById = _repository.GetById(id);
            if (getSalaryById != null)
                return getSalaryById.MapToSalaryResponse();
            return null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public string Update(SalaryUpdateRequest item)
    {
        try
        {
            var _item = _repository.GetById(item.Id);
            if (_item is null)
            {
                return "Appointment is not found";
            }
            var mapSalary = item.MapToSalaryUpdate();
            _repository.Update(mapSalary);
            return "Appointment is updated";
        }
        catch (Exception)
        {
            throw;
        }
    }
}
