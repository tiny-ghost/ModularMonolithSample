using ETS.Module.BIT.Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ETS.Module.BIT.Controllers
{
    [ApiController]
    [Route("api/bit/[controller]")]
    internal class FiltersController:ControllerBase
    {
        private readonly IMediator _mediator;
        public FiltersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var filters = await _mediator.Send(new GetAllFilters());
            return Ok(filters);
        }
    }
}
