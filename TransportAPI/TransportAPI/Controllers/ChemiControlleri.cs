using Microsoft.AspNetCore.Mvc;
using TransportAPI.Interfaces;

namespace TransportAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChemiControlleri : ControllerBase
{
    private readonly IDateTimeService _dateTimeService;

    public ChemiControlleri(IDateTimeService dateTimeService)
    {
        _dateTimeService = dateTimeService;
    }

    [HttpGet]
    [Route("GetDateTime")]
    public async Task<ActionResult> GetDateTime()
    {
        var now = _dateTimeService.GetDateTimeNow();
        return Ok(now);
    }

    [HttpGet]
    [Route("SumTwoNumbers")]
    public async Task<ActionResult> SumTwoNumbers(double? a, double? b)
    {
        if (a == null || b == null)
            return BadRequest("მონაცეწმები არგადაეცა სწორად");

        var c = a + b;
        return Ok(c.ToString());
    }
}
