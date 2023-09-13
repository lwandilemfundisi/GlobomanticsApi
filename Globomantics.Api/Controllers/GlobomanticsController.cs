using Globomantics.Api.Models;
using Globomantics.Domain.DomainModel.GlobomanticsModel.Commands;
using Microsoft.AspNetCore.Mvc;
using XFrame.Aggregates.Commands;
using XFrame.Aggregates.Queries;

namespace Globomantics.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GlobomanticsController : ControllerBase
    {
        private readonly ICommandBus _commandBus;

        public GlobomanticsController(
            ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateConferenceModelRequest request)
        {
            var result = await _commandBus
                .PublishAsync(
                    request.ToCommand(), 
                    CancellationToken.None);

            return Ok(result);
        }
    }
}
