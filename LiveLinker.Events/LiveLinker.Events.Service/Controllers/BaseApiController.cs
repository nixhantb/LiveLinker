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


        protected BaseApiController(TRepository repository)
        {
            _repository = repository;
        }


        [HttpPost]

        public virtual async Task<IActionResult> CreateAsync([FromBody] TEntity entity)
        {
            try
            {

                if (entity == null)
                {
                    return BadRequest();
                }

                var result = await _repository.AddRecordsAsync(entity);
                return Ok(result);
            }
            catch(Exception ex){

                return StatusCode(400, "Something went wrong");
            }
        }

    }
}