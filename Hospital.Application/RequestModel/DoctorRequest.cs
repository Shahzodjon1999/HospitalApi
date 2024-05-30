﻿using Hospital.Application.Entity;
using Microsoft.AspNetCore.Http;

namespace Hospital.Application.RequestModel;

public record DoctorRequest : EntityBaseRequest
{
	public string FirstName { get; set; } = string.Empty;

	public string LastName { get; set; } = string.Empty;

	public string PhoneNumber { get; set; } = string.Empty;

	public string Address { get; set; } = string.Empty;

    public string Image { get; set; }
    public string Information { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }

	public DateTime DateRegister { get; set; }

	public string Positions { get; set; } = string.Empty;

    public Guid DepartmentId { get; set; }
}
