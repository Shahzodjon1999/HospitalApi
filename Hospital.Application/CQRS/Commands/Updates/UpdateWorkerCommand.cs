﻿using MediatR;

namespace Hospital.Application.CQRS.Commands.Updates;
public class UpdateWorkerCommand:IRequest<string>
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }
}
 