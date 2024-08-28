using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Hospital.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Serilog;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController : BaseController<ClientRequest, ClientUpdateRequest, ClientResponse>
{
    private readonly IGenericService<ClientRequest, ClientUpdateRequest, ClientResponse> _clientService;

    public ClientController(IGenericService<ClientRequest, ClientUpdateRequest, ClientResponse> service) : base(service)
    {
        _clientService = service;
    }
    [AllowAnonymous]
    [HttpPost]
    public override ActionResult<string> Create([FromBody] ClientRequest request)
    {
        try
        {
            Log.Information("In the method Create request=>{@request}", request);
            return _clientService.Create(request);
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
}
