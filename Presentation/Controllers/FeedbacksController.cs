using Application.CQRS.Commands.Feedbacks;
using Application.CQRS.Queries.Feedbacks;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeedbacksController : ControllerBase
{
    private readonly IMediator _mediator;

    public FeedbacksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<FeedbackResponse>> CreateFeedback([FromBody] FeedbackDto dto)
    {
        var command = new CreateFeedbackCommand(dto);
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetFeedback), new
        {
            id = response.Id
        }, response);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<ActionResult<FeedbackResponse>> GetFeedback([FromRoute] Guid id)
    {
        var query = new GetFeedbackByIdQuery(id);
        var response = await _mediator.Send(query);
        return response;
    }
}