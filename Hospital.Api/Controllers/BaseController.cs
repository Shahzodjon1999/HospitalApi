using Hospital.Application.Entity;
using Hospital.Application.InterfaceServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Serilog;

namespace Hospital.Api.Controllers;
[Authorize]
[ApiController]
public abstract class BaseController<TRequest,TUpdateRequest,TResponse> : ControllerBase where TRequest:EntityBaseRequest where  TUpdateRequest:EntityBaseUpdateRequest where TResponse:EntityBaseResponse
{
    protected readonly IGenericService<TRequest, TUpdateRequest, TResponse> _doctorService;

    public BaseController(IGenericService<TRequest, TUpdateRequest, TResponse> doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TResponse>> GetAll()
    {
        try
        {
            var getAll = _doctorService.GetAll();
            Log.Information("In the method GetAll() result=>{@getAll}", getAll);
            if (getAll is not null)
                return Ok(getAll);
            return Ok("You have not data");
        }
        catch (Exception ex)
        {
            Log.Error("You have Error In the method GetAll()=>{@ex}", ex.Message);
            throw new Exception($"You have exception:{ex.Message} in the Controller Method GetAll");
        }
    }

    [HttpGet("Id")]
    public ActionResult<TResponse> GetById(Guid id)
    {
        try
        {
            var getById = _doctorService.GetById(id);
            if (getById is null)
                return Ok("You have not data");
            Log.Information("In the method GetById result=>{@getById}", getById);
            return Ok(getById);
        }
        catch (Exception ex)
        {
            Log.Error("You have Error In the  method GetById()=>{@ex}", ex.Message);
            throw new Exception($"You have exception:{ex.Message} in the Method GetById");
        }
    }

    [HttpPost]
    public ActionResult<string> Create([FromBody] TRequest request)
    {
        try
        {
           

            Log.Information("In the method Create request=>{@request}", request);
            return _doctorService.Create(request);
        }
        catch (SqlException es)
        {
            return $"Didn't save data {request}";
        }
        catch (Exception ex)
        {
            Log.Error("You have Error In the method Create()=>{@ex}", ex.Message);
            throw new Exception($"You have exception:{ex.Message} in the Method Create");
        }
    }

    [HttpPut]
    public ActionResult<string> Update(TUpdateRequest updateRequest)
    {
        try
        {
            Log.Information("In the method Update request=>{@request} and Id=>{@id}", updateRequest);
            return _doctorService.Update(updateRequest);
        }
        catch (Exception ex)
        {
            Log.Error("You have Error In the method Update()=>{@ex}", ex.Message);
            throw new Exception($"You have exception:{ex.Message} in the  Method Update");
        }
    }

    [HttpDelete]
    public ActionResult<string> Delete(Guid id)
    {
        try
        {
            Log.Information("In the method Delete Id=>{@id}", id);
            return _doctorService.Delete(id);
        }
        catch (Exception ex)
        {
            Log.Error("You have Error In the method Delete()=>{@ex}", ex.Message);
            throw new Exception($"You have exception:{ex.Message} in the Method Delete");
        }
    }
}
