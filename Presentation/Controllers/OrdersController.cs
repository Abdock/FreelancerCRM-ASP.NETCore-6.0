using Application.CQRS.Commands.Orders;
using Application.CQRS.Queries.Orders;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<OrderResponse>> CreateOrder([FromBody] OrderDto dto)
    {
        var command = new CreateOrderCommand(dto);
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetOrder), new
        {
            id = response.Id
        }, response);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<ActionResult<OrderResponse>> GetOrder([FromRoute] Guid id)
    {
        var query = new GetOrderByIdQuery(id);
        var response = await _mediator.Send(query);
        return Ok(response);
    }
}