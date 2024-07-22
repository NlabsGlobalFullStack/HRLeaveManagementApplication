using LeaveManagementServer.Application.Features.Periods.CreatePeriod;
using LeaveManagementServer.Application.Features.Periods.DeleteByIdPeriod;
using LeaveManagementServer.Application.Features.Periods.GetAll;
using LeaveManagementServer.Application.Features.Periods.GetByIdPeriod;
using LeaveManagementServer.Application.Features.Periods.UpdatePeriod;
using LeaveManagementServer.Domain.Dtos;
using LeaveManagementServer.WebAPI.Abstractions;
using LeaveManagementServer.WebAPI.AOP;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace LeaveManagementServer.WebAPI.Controllers;
[AllowAnonymous]
public sealed class PeriodsController : ApiController
{
    public PeriodsController(IMediator mediator) : base(mediator) { }

    [EnableQueryWithMetadata]
    [HttpPost]
    public async Task<IActionResult> GetAll(ODataQueryOptions<PeriodResponse> queryOptions, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllPeriodsQuery(), cancellationToken);

        var queryResults = queryOptions.ApplyTo(response.AsQueryable());

        if (response.Count <= 0)
        {
            return BadRequest("List not found");
        }

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePeriodCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdatePeriodCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> GetById(Guid Id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetByIdPeriodQuery(Id), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new DeleteByIdPeriodCommand(Id), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}