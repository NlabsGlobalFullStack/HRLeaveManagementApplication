﻿using LeaveManagementServer.Application.Features.Auth.Login;
using LeaveManagementServer.Application.Features.Auth.Register;
using LeaveManagementServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementServer.WebAPI.Controllers;
[AllowAnonymous]
public sealed class AuthController : ApiController
{
    public AuthController(IMediator mediator) : base(mediator) { }

    [HttpPost]
    public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
