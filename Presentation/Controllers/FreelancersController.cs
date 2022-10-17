using Application.CQRS.Commands.Freelancers;
using Application.CQRS.Queries.Feedbacks;
using Application.CQRS.Queries.Freelancers;
using Application.CQRS.Queries.Orders;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FreelancersController : ControllerBase
{
    private readonly IMediator _mediator;

    public FreelancersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<FreelancerResponse>> CreateFreelancer([FromBody] FreelancerDto dto)
    {
        var command = new CreateFreelancerCommand(dto);
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetFreelancer), new
        {
            id = response.Id
        }, response);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<ActionResult<FreelancerResponse>> GetFreelancer([FromRoute] Guid id)
    {
        var query = new GetFreelancerByIdQuery(id);
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet]
    [Route("{id:guid}/orders")]
    public async Task<ActionResult<IEnumerable<OrderResponse>>> GetFreelancerOrders([FromRoute] Guid id)
    {
        var query = new GetAllOrdersOfFreelancerQuery(id);
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet]
    [Route("{id:guid}/feedbacks")]
    public async Task<ActionResult<IEnumerable<FeedbackResponse>>> GetFeedbackResponse([FromRoute] Guid id)
    {
        var query = new GetAllFeedbacksOfFreelancerQuery(id);
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<PagedResponse<FreelancerResponse>>> GetFreelancers([FromQuery] PaginationFilter filter)
    {
        var route = Request.Path.Value!;
        var query = new GetFreelancersQuery(filter, route);
        var response = await _mediator.Send(query);
        return Ok(response);
    }
}