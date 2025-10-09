using DvShipperApi.Models;
using System.Collections.Generic;

namespace DvShipperApi.Interfaces
{
    public interface ISearchService
    {
        List<Order> SearchOrdersByLocation(int locationId);
        List<Order> SearchOrdersByContainer(int containerId);
        List<Order> SearchOrdersByCourier(int courierId);
        List<Location> SearchLocationsByCourier(string courierFullName);
    }
}
