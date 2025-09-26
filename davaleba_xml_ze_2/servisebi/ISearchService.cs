using davaleba_xml_ze_2.klasebi;
using System.Collections.Generic;

namespace davaleba_xml_ze_2.servisebi
{
    public interface ISearchService
    {
        List<Order> SearchOrdersByLocation(int locationId);
        List<Order> SearchOrdersByContainer(int containerId);
        List<Order> SearchOrdersByCourier(int courierId);
        List<Location> SearchLocationsByCourier(string courierFullName);
    }
}
