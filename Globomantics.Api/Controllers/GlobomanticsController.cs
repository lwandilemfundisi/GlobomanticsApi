using Globomantics.Api.Models;
using Globomantics.Domain.Applications;
using Globomantics.Domain.DomainModel.GlobomanticsModel;
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
        private readonly IGlobomanticsService _globomanticsService;

        public GlobomanticsController(
            IGlobomanticsService globomanticsService)
        {
            _globomanticsService = globomanticsService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateConferenceModelRequest request)
        {
            var result = await _globomanticsService.
                CreateConferences(
                request.ConferenceName, 
                request.Start, 
                request.Location, 
                request.AttendeeCount, 
                CancellationToken.None);

            return Ok(result);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(string conferenceId)
        {
            var result = await _globomanticsService
                .GetConference(new ConferenceId(conferenceId), CancellationToken.None);

            if(result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
