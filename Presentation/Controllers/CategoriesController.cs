using Application.CQRS.Commands.Categories;
using Application.CQRS.Queries.Categories;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CategoryResponse>> CreateCategory([FromBody] CategoryDto dto)
    {
        var command = new CreateCategoryCommand(dto);
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetCategory), new
        {
            id = response.Id
        }, response);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<ActionResult<CategoryResponse>> GetCategory([FromRoute] Guid id)
    {
        var query = new GetCategoryByIdQuery(id);
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryResponse>>> GetAllCategories()
    {
        var query = new GetAllCategoriesQuery();
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<ActionResult> UpdateCategory([FromRoute] Guid id, [FromBody] CategoryDto dto)
    {
        var command = new UpdateCategoryCommand(id, dto);
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<ActionResult> DeleteCategory([FromRoute] Guid id)
    {
        var command = new DeleteCategoryCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}