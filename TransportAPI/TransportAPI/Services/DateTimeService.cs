using TransportAPI.Interfaces;

namespace TransportAPI.Services;

public class DateTimeService : IDateTimeService
{
    public string GetDateTimeNow()
    {
        var now = DateTime.Now.ToString("d MMM yyyy HH:mm:ss");
        return now;
    }
}
