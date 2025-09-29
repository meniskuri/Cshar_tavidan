using Microsoft.AspNetCore.Mvc;
using TransportAPI.Interfaces;

namespace TransportAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MathController : ControllerBase
{
    private readonly IDateTimeService _dateTimeService;

    public MathController(IDateTimeService dateTimeService)
    {
        _dateTimeService = dateTimeService;
    }

    [HttpGet]
    [Route("MultiplyTwoNumbers")]
    public async Task<ActionResult> MultiplyTwoNumbers(double? a, double? b)
    {
        if (a == null || b == null)
            return BadRequest($"Error [{_dateTimeService.GetDateTimeNow()}] : მონაცეწმები არგადაეცა სწორად");

        var c = a * b;
        return Ok(c);
    }
}
