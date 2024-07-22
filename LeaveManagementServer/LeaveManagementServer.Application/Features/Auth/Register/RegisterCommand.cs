﻿using MediatR;
using Nlabs.Result;

namespace LeaveManagementServer.Application.Features.Auth.Register;
public sealed record RegisterCommand
(
    string UserName,
    string Email,
    string FirstName,
    string LastName,
    string Password,
    string RePassword
) : IRequest<Result<string>>;
