using FluentValidation;
using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
public class BranchController : BaseController<BranchRequest,BranchUpdateRequest,BranchResponse>
{
	public BranchController(IGenericService<BranchRequest,BranchUpdateRequest,BranchResponse> service) :base(service)
	{

	}
}
