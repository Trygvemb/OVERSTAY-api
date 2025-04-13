using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Overstay.API.Controllers;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MediatorControllerBase(ISender mediator) : ControllerBase
{
    protected ISender Mediator { get; } = mediator;
}
