using ConferenceRooms.Services;
using ConferenceRooms.Services.Results;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceRooms.Controllers;

/// <summary>
/// Provides reporting endpoints for business analytics.
/// </summary>
[ApiController]
[Route("api/reports")]
public class ReportsController(IConferenceRoomService service) : ControllerBase
{
    /// <summary>
    /// Returns conference room utilization report for a selected period.
    /// </summary>
    /// <param name="from">Report start date and time.</param>
    /// <param name="to">Report end date and time.</param>
    /// <returns>Room utilization metrics.</returns>
    [HttpGet("room-utilization")]
    public IActionResult GetRoomUtilization([FromQuery] DateTime from, [FromQuery] DateTime to)
    {
        var result = service.GetRoomUtilizationReport(from, to);
        if (!result.Success)
        {
            return result.ErrorCode switch
            {
                OperationErrorCode.NotFound => NotFound(new { Message = result.Error }),
                OperationErrorCode.Conflict => Conflict(new { Message = result.Error }),
                OperationErrorCode.ValidationFailed => BadRequest(new { Message = result.Error }),
                _ => StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An internal server error occurred." })
            };
        }

        return Ok(result.Value);
    }
}
