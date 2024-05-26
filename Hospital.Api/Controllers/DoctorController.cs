using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Serilog;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
public class DoctorController : BaseController<DoctorRequest,DoctorUpdateRequest,DoctorResponse>
{
    private readonly IGenericService<DoctorRequest, DoctorUpdateRequest, DoctorResponse> _service;

    public DoctorController(IGenericService<DoctorRequest, DoctorUpdateRequest, DoctorResponse> service) : base(service)
    {
        _service = service;
    }

    [HttpPost("Create")]
    public override ActionResult<string> Create([FromBody] DoctorRequest request)
    {
        try
        {
            if (request == null || request.Image == null || request.Image.Length == 0)
            {
                return BadRequest("Invalid doctor data or no image provided");
            }
            Log.Information("In the method Create request=>{@request}", request);
            return _service.Create(request);
        }
        catch (SqlException)
        {
            return $"Didn't save data {request}";
        }
        catch (Exception ex)
        {
            Log.Error("You have Error In the method Create()=>{@ex}", ex.Message);
            throw new Exception($"You have exception:{ex.Message} in the Method Create");
        }
    }
}
