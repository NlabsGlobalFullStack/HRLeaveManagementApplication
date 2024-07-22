using LeaveManagementServer.Application.Features.LeaveRequests.CreateLeaveRequest;
using LeaveManagementServer.Application.Features.LeaveRequests.DeleteByIdLeaveRequest;
using LeaveManagementServer.Application.Features.LeaveRequests.GetAll;
using LeaveManagementServer.Application.Features.LeaveRequests.GetbyIdLeaveRequest;
using LeaveManagementServer.Application.Features.LeaveRequests.UpdateLeaveRequest;
using LeaveManagementServer.Domain.Dtos;
using LeaveManagementServer.WebAPI.Abstractions;
using LeaveManagementServer.WebAPI.AOP;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace LeaveManagementServer.WebAPI.Controllers;

public sealed class LeaveRequestsController : ApiController
{
    public LeaveRequestsController(IMediator mediator) : base(mediator) { }

    [EnableQueryWithMetadata]
    [HttpPost]
    public async Task<IActionResult> GetAll(ODataQueryOptions<LeaveRequestResponse> queryOptions, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllLeaveRequestsQuery(), cancellationToken);

        var queryResults = queryOptions.ApplyTo(response.AsQueryable());

        if (response.Count <= 0)
        {
            return BadRequest("List not found");
        }

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> GetById(Guid Id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetbyIdLeaveRequestQuery(Id), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new DeleteByIdLeaveRequestCommand(Id), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
