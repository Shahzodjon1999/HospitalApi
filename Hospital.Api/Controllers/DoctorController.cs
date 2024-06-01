using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Serilog;

namespace Hospital.Api.Controllers;
[Authorize]
[Route("api/[controller]")]
public class DoctorController : BaseController<DoctorRequest,DoctorUpdateRequest,DoctorResponse>
{
    private readonly IGenericService<DoctorRequest, DoctorUpdateRequest, DoctorResponse> _service;
    private readonly IWebHostEnvironment _env;
    public DoctorController(IGenericService<DoctorRequest, DoctorUpdateRequest, DoctorResponse> service) : base(service)
    {
        _service = service;
    }

    [HttpPost]
    public override ActionResult<string> Create([FromForm] DoctorRequest userRequest)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Handle the image upload
            var files = Request.Form.Files;
            if (files.Any())
            {
                var file = files.First();
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

                // Ensure the uploads folder exists
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                // Generate a unique file name
                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                // Full path to save the file
                var filePath = Path.Combine(uploadsFolderPath, uniqueFileName);

                // Save the file to the server
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                     file.CopyToAsync(fileStream);
                }

                // Save only the file name to the userRequest object
                userRequest.Image = uniqueFileName;
            }
            Log.Information("In the method Create request=>{@request}", userRequest);
            return _service.Create(userRequest);
        }
        catch (SqlException)
        {
            return $"Didn't save data {userRequest}";
        }
        catch (Exception ex)
        {
            Log.Error("You have Error In the method Create()=>{@ex}", ex.Message);
            throw new Exception($"You have exception:{ex.Message} in the Method Create");
        }
    }


    [HttpGet]
    public override ActionResult<IEnumerable<DoctorResponse>> GetAll()
    {
        DoctorResponse doctorResponse = null;
        try
        {
            var doctors = _doctorService.GetAll();
            var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";

            var doctorResponses = doctors.Select(doctor => new DoctorResponse
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Address = doctor.Address,
                DateOfBirth = doctor.DateOfBirth,
                DateRegister = doctor.DateRegister,
                Information = doctor.Information,
                Position = doctor.Position,
                PhoneNumber = doctor.PhoneNumber,
                Image = !string.IsNullOrEmpty(doctor.Image)
                            ? $"{baseUrl}/uploads/{doctor.Image}"
                            : null
            });

            return Ok(doctorResponses);
        }
        catch (Exception ex)
        {
            Log.Error("Error occurred while fetching doctors: {@ex}", ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }

    //[HttpGet("getall")]
    //public async Task<ActionResult<IEnumerable<DoctorResponse>>> GetAllDoctors()
    //{
    //    DoctorResponse doctorResponse = null;
    //    try
    //    {
    //        var doctors =  _doctorService.GetAll();
    //        var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";

    //        var doctorResponses = doctors.Select(doctor => new DoctorResponse
    //        {
    //            Id = doctor.Id,
    //            FirstName= doctor.FirstName,
    //            LastName= doctor.LastName,
    //            Address=doctor.Address,
    //            DateOfBirth=doctor.DateOfBirth,
    //            DateRegister=doctor.DateRegister,
    //            Information=doctor.Information,
    //            Position=doctor.Position,
    //            PhoneNumber=doctor.PhoneNumber,
    //            Image = !string.IsNullOrEmpty(doctor.Image)
    //                        ? $"{baseUrl}/uploads/{doctor.Image}"
    //                        : null
    //        });

    //        return Ok(doctorResponses);
    //    }
    //    catch (Exception ex)
    //    {
    //        Log.Error("Error occurred while fetching doctors: {@ex}", ex.Message);
    //        return StatusCode(500, "Internal server error");
    //    }
    //}

    //[HttpPost("create")]
    //public async Task<ActionResult<string>> Create([FromForm] UserRequest request, [FromForm] IFormFile Image)
    //{
    //    try
    //    {
    //        if (request == null || Image == null || Image.Length == 0)
    //        {
    //            return BadRequest("Invalid doctor data or no image provided");
    //        }

    //        var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
    //        if (!Directory.Exists(uploadsFolder))
    //        {
    //            Directory.CreateDirectory(uploadsFolder);
    //        }

    //        var filePath = Path.Combine(uploadsFolder, Image.FileName);
    //        using (var stream = new FileStream(filePath, FileMode.Create))
    //        {
    //            await Image.CopyToAsync(stream);
    //        }

    //        request.Image = $"uploads/{Image.FileName}";

    //        // Save doctorRequest to the database here using the service
    //        Log.Information("In the method Create request=>{@request}", request);
    //        // return Ok(_service.Create(request));
    //        return Ok("thamthink");
    //    }
    //    catch (SqlException)
    //    {
    //        return BadRequest($"Didn't save data {request}");
    //    }
    //    catch (Exception ex)
    //    {
    //        Log.Error("You have Error In the method Create()=>{@ex}", ex.Message);
    //        return StatusCode(500, $"Internal server error: {ex.Message}");
    //    }
    //}
}
