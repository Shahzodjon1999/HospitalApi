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
    private readonly IWebHostEnvironment _env;
    public DoctorController(IGenericService<DoctorRequest, DoctorUpdateRequest, DoctorResponse> service) : base(service)
    {
        _service = service;
    }

    
 
    [HttpPost("create")]
    public async Task<ActionResult<string>> Create([FromForm] DoctorRequest request, [FromForm] IFormFile Image)
    {
        try
        {
            if (request == null || Image == null || Image.Length == 0)
            {
                return BadRequest("Invalid doctor data or no image provided");
            }

            var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var filePath = Path.Combine(uploadsFolder, Image.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await Image.CopyToAsync(stream);
            }

            request.Image = $"uploads/{Image.FileName}";

            // Save doctorRequest to the database here using the service
            Log.Information("In the method Create request=>{@request}", request);
            return Ok(_service.Create(request));
        }
        catch (SqlException)
        {
            return BadRequest($"Didn't save data {request}");
        }
        catch (Exception ex)
        {
            Log.Error("You have Error In the method Create()=>{@ex}", ex.Message);
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
