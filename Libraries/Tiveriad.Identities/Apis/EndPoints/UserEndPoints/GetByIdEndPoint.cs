
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Apis.Contracts.UserContracts;
using Tiveriad.Identities.Applications.Queries.UserQueries;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.Identities.Apis.Contracts.MembershipContracts;
using Tiveriad.Identities.Apis.Contracts.PolicyContracts;
using Tiveriad.Identities.Applications.Queries.MembershipQueries;
using Tiveriad.Identities.Applications.Queries.PolicyQueries;

namespace Tiveriad.Identities.Apis.EndPoints.UserEndPoints;

public class GetByIdEndPoint : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService<string> _currentUserService;
    private readonly ITenantService<string> _tenantService;
    
    public GetByIdEndPoint(IMediator mediator, IMapper mapper, ICurrentUserService<string> currentUserService, ITenantService<string> tenantService)
    {
        _mediator = mediator;
        _mapper = mapper;
        _currentUserService = currentUserService;
        _tenantService = tenantService;
    }

    [HttpGet("/users/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<UserReaderModelContract>> HandleAsync([FromRoute][Required] string id, CancellationToken cancellationToken)
    {
        var user = await _mediator.Send(new UserGetByIdQueryHandlerRequest(id), cancellationToken);
        var membership = await _mediator.Send(new MembershipGetAllQueryHandlerRequest(UserId: id), cancellationToken);
        //var policies = await _mediator.Send(new PolicyGetAllQueryHandlerRequest(UserId: id), cancellationToken);
        
        if (user == null) return NoContent();
        var data = _mapper.Map<User, UserReaderModelContract>(user);
        return Ok(data);
    }
    
    [HttpGet("/userInfos/current")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<UserInfoReaderModelContract>> HandleAsync( CancellationToken cancellationToken)
    {
        var memberships = await _mediator.Send(new MembershipGetAllQueryHandlerRequest(UserId: _currentUserService.GetUserId(), OrganizationId: _tenantService.GetTenantId()), cancellationToken);
        if (memberships.RowCount == 0) return NoContent();
        var user = memberships.Items[0].User;
        var userInfo = _mapper.Map<User, UserInfoReaderModelContract>(user);
        userInfo.Memberships = _mapper.Map<List<Membership>, List<MembershipInfoReaderModelContract>>(memberships.Items);
        userInfo.Memberships.SelectMany(x=>x.Roles).ToList().ForEach( x =>
        {
            var policies =  _mediator.Send(new PolicyGetAllQueryHandlerRequest(RoleId: x.Id), cancellationToken).Result;
            x.Policies = _mapper.Map<List<Policy>, List<PolicyReaderModelContract>>(policies.Items);    
        });
        return Ok(userInfo);
    }
    
}

