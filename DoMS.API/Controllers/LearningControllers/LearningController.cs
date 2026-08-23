using DoMS.API.DTOs.Learning;
using DoMS.Modules.Learning.Application.Features.EnrollCourse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoMS.API.Controllers.LearningControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearningController : DoMS.API.Controllers.BaseApiController
    {
        // enroll endpoint ( expected data input DTO + global exception handling middleware)
        [HttpPost("enroll")]
        public async Task<IActionResult> EnrollAsync([FromBody] CourseEnrollRequest request, CancellationToken cancellationToken)
        {
            // technical debt: learner ID is a claimed token and should be retrieved from JWT middleware soon:
            var learnerID = Guid.Parse("00000000-0000-0000-0000-000000000001");
            // send the request to the application layer:
            var command = new EnrollCommand(learnerID, request.CourseID);
            // return the result:
            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
    }
}
