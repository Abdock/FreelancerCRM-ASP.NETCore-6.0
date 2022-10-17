using Application.CQRS.Commands.Clients;
using Application.CQRS.Queries.Clients;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClientsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<ClientResponse>> CreateClient([FromBody] ClientDto dto)
    {
        var command = new CreateClientCommand(dto);
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetClient), new
        {
            id = response.Id
        }, response);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<ActionResult<ClientResponse>> GetClient([FromRoute] Guid id)
    {
        var query = new GetClientByIdQuery(id);
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<PagedResponse<ClientResponse>>> GetClients([FromQuery] PaginationFilter filter)
    {
        var route = Request.Path.Value!;
        var query = new GetClientsQuery(filter, route);
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<ActionResult> DeleteClient([FromRoute] Guid id)
    {
        var command = new DeleteClientCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}