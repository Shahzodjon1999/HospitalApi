using FluentValidation;
using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers
{
    [Route("api/[controller]")]
    public class SalaryController : BaseController<SalaryRequest, SalaryUpdateRequest, SalaryResponse>
    {
        public SalaryController(IGenericService<SalaryRequest, SalaryUpdateRequest, SalaryResponse> Service) : base(Service)
        {
        }
    }
}
