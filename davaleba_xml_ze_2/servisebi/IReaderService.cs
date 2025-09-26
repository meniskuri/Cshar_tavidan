using davaleba_xml_ze_2.klasebi;
using System.Collections.Generic;

namespace davaleba_xml_ze_2.servisebi
{
    public interface IReaderService
    {
        List<Location> ReadLocations();
        List<Container> ReadContainers();
        List<Courier> ReadCouriers();
        List<Order> ReadOrders();
    }
}
