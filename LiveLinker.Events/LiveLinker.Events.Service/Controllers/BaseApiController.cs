using FluentValidation;
using LiveLinker.Events.LiveLinker.Events.Core.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LiveLinker.Events.LiveLinker.Events.Service.Controller
{

    [Route("api/v1/[controller]")]
    [ApiController]

    public abstract class BaseApiController<TEntity, TModel, TRepository> : ControllerBase
    where TEntity : class
    where TModel : class
    where TRepository : IRepository<TEntity, TModel>
    {

        protected readonly TRepository _repository;
        protected readonly IValidator<TEntity> _validator;

        protected BaseApiController(TRepository repository, IValidator<TEntity> validator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> CreateAsync([FromBody] TEntity entity)
        {
            try
            {

                if (entity == null)
                {
                    return BadRequest();
                }

                var validationResult = _validator.Validate(entity);
                if (!validationResult.IsValid)
                {
                    return BadRequest(new
                    {
                        Message = "Validation failed.",
                        Errors = validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage })
                    });
                }
                var result = await _repository.AddRecordsAsync(entity);
                return Ok(result);
            }
            catch(Exception ex){

                return StatusCode(500, new
                {
                    Message = "An unexpected error occurred.",
                    Details = ex.Message
                });
            }
        }

    }
}