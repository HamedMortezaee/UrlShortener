using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using UrlShortener.Application.Content.UrlShortenerHistory.Commands.CreateUrlShortenerAccessHistory;
using UrlShortener.Application.UrlShortenerHistory.Queries;

namespace UrlShortener.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlShortenerHistoryController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<UrlShortenerHistoryController> _logger;
        public UrlShortenerHistoryController(IMediator mediator, ILogger<UrlShortenerHistoryController> logger)
        {
            this.mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<UrlShortenerHistoryListResultQuery>> GetUrlShortenerAccessHistory([FromBody] UrlShortenerHistoryListRequestQuery command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

    }
}
