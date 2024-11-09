using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Swashbuckle.AspNetCore.Annotations;
using upcsi730pc2veterinarycampaign.API.Crm.Domain.Model.Commands;
using upcsi730pc2veterinarycampaign.API.Crm.Domain.Services;
using upcsi730pc2veterinarycampaign.API.Crm.Interfaces.REST.Resources;
using upcsi730pc2veterinarycampaign.API.Crm.Interfaces.REST.Transform;

namespace upcsi730pc2veterinarycampaign.API.Crm.Interfaces.REST;

[ApiController]
[Route("api/v1/managers")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Managers")]
public class ManagersController: ControllerBase
{
    private readonly IManagerCommandService _managerCommandService;
    
    public ManagersController(IManagerCommandService managerCommandService)
    {
        _managerCommandService = managerCommandService;
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new manager",
        Description = "Create a new manager",
        OperationId = "CreateManager")]
    [SwaggerResponse(StatusCodes.Status201Created, "The manager was created", 
        typeof(ManagerResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The manager could not be created")]
    public async Task<ActionResult> CreateManager([FromBody] CreateManagerResource resource)
    {
        var createManagerCommand = CreateManagerCommandFromResourceAssembler.ToCommandFromResource(resource);

        var result = await _managerCommandService.Handle(createManagerCommand);
        
        if (result is null)
            return BadRequest();
        
        return Created(string.Empty, ManagerResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
}