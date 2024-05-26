using FluentValidation;
using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Hospital.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
public class PatientController : BaseController<PatientRequest,PatientUpdateRequest,PatientResponse>
{
    private readonly IGenericService<PatientRequest, PatientUpdateRequest, PatientResponse> _service;
    private readonly PatientService _patientService;
    public PatientController(PatientService patientService,IGenericService<PatientRequest, PatientUpdateRequest, PatientResponse> service) : base(service)
    {
        _patientService = patientService;
       _service = service;
    }

    [HttpGet("PatientInfo")]
    public ActionResult<IEnumerable<PatientInfoResponse>> GetAllPatientInfo()
    {
        try
        {
            var getAll = _patientService.GetAllInfoPatient();
            Log.Information("In the method GetAllPatientInfo() result=>{@getAll}", getAll);
            if (getAll is not null)
                return Ok(getAll);
            return Ok("You have not data");
        }
        catch (Exception ex)
        {
            Log.Error("You have Error In the method GetAllPatientInfo()=>{@ex}", ex.Message);
            throw new Exception($"You have exception:{ex.Message} in the Controller Method GetAll");
        }
    }
}
