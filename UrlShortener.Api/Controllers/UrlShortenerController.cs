using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using UrlShortener.Application.Content.UrlShortener.Commands.CreateUrlShortener;
using UrlShortener.Application.Content.UrlShortener.Queries;

namespace UrlShortener.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlShortenerController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<UrlShortenerController> _logger;
        public UrlShortenerController(IMediator mediator, ILogger<UrlShortenerController> logger)
        {
            this.mediator = mediator;
            _logger = logger;
        }


        [HttpGet]
        public async Task<ActionResult<UrlShortenerItemResultQuery>> GetAll()
        {
            var result = await mediator.Send(new UrlShortenerItemRequestQuery());

            return base.Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateUrlShortener command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

    }
}
