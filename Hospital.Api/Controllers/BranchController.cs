﻿using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
public class BranchController : BaseController<BranchRequest,BranchResponse>
{
	public BranchController(IGenericService<BranchRequest,BranchResponse> service):base(service)
	{

	}
}
