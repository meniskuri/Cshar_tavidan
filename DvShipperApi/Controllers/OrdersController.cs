using DvShipperApi.Interfaces;
using DvShipperApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DvShipperApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ISearchService _search;
        private readonly IWriterService _writer;

        public OrdersController(ISearchService search, IWriterService writer)
        {
            _search = search;
            _writer = writer;
        }

        [HttpGet("search/location/{id}")]
        public ActionResult<List<Order>> SearchByLocation(int id)
        {
            var result = _search.SearchOrdersByLocation(id);
            return result.Any() ? Ok(result) : NotFound("No orders found for this location.");
        }

        [HttpGet("search/container/{id}")]
        public ActionResult<List<Order>> SearchByContainer(int id)
        {
            var result = _search.SearchOrdersByContainer(id);
            return result.Any() ? Ok(result) : NotFound("No orders found for this container.");
        }

        [HttpGet("search/courier/{id}")]
        public ActionResult<List<Order>> SearchByCourier(int id)
        {
            var result = _search.SearchOrdersByCourier(id);
            return result.Any() ? Ok(result) : NotFound("No orders found for this courier.");
        }

        [HttpGet("search/locations/bycourier")]
        public ActionResult<List<Location>> SearchLocationsByCourier([FromQuery] string fullname)
        {
            var result = _search.SearchLocationsByCourier(fullname);
            return result.Any() ? Ok(result) : NotFound("No locations found for this courier.");
        }

        [HttpPost("save")]
        public ActionResult SaveXml([FromQuery] string? path = null)
        {
            string savePath = path ?? Path.Combine(Directory.GetCurrentDirectory(), "Data", "NewDVShipper.xml");
            _writer.SaveToFile(savePath);
            return Ok($"XML saved to {savePath}");
        }
    }
}
