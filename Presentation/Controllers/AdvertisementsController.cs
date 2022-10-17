using Application.CQRS.Commands.Advertisements;
using Application.CQRS.Queries.Advertisements;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdvertisementsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdvertisementsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<AdvertisementResponse>> CreateAdvertisement([FromBody] AdvertisementDto dto)
    {
        var command = new CreateAdvertisementCommand(dto);
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAdvertisement), new
        {
            id = response.Id,
        }, response);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<ActionResult<AdvertisementResponse>> GetAdvertisement([FromRoute] Guid id)
    {
        var query = new GetAdvertisementByIdQuery(id);
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<PagedResponse<AdvertisementShortResponse>>> GetAdvertisements(
        [FromQuery] PaginationFilter filter)
    {
        var route = Request.Path.Value!;
        var query = new GetAdvertisementsQuery(filter, route);
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<ActionResult> DeleteAdvertisement([FromRoute] Guid id)
    {
        var command = new DeleteAdvertisementCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<ActionResult> UpdateAdvertisement([FromRoute] Guid id, [FromBody] AdvertisementDto dto)
    {
        var command = new UpdateAdvertisementCommand(id, dto);
        await _mediator.Send(command);
        return NoContent();
    }
}