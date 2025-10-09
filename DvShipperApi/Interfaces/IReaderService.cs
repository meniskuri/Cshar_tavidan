using DvShipperApi.Models;
using System.Collections.Generic;

namespace DvShipperApi.Interfaces;

public interface IReaderService
{
    List<Location> ReadLocations();
    List<Container> ReadContainers();
    List<Courier> ReadCouriers();
    List<Order> ReadOrders();
}
