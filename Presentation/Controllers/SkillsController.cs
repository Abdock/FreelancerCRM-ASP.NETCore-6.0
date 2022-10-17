using Application.CQRS.Commands.Skills;
using Application.CQRS.Queries.Skills;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SkillsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SkillsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<SkillResponse>> CreateSkill([FromBody] NewSkillDto dto)
    {
        var command = new CreateSkillCommand(dto);
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetSkill), new
        {
            id = response.Id
        }, response);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<ActionResult<SkillResponse>> GetSkill([FromRoute] Guid id)
    {
        var query = new GetSkillByIdQuery(id);
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SkillResponse>>> GetAllSkills()
    {
        var query = new GetAllSkillsQuery();
        var response = await _mediator.Send(query);
        return Ok(response);
    }
}