using davaleba_xml_ze_2.klasebi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace davaleba_xml_ze_2.servisebi
{
    public class SearchService
    {
        private readonly List<Location> _locations;
        private readonly List<Container> _containers;
        private readonly List<Courier> _couriers;
        private readonly List<Order> _orders;

        public SearchService(List<Location> locations,
                             List<Container> containers,
                             List<Courier> couriers,
                             List<Order> orders)
        {
            _locations = locations;
            _containers = containers;
            _couriers = couriers;
            _orders = orders;
        }

        // orders მოძებნე locationId-ით
        public List<Order> SearchOrdersByLocation(int locationId)
        {
            return _orders
                .Where(o => o.StartLocationId == locationId || o.EndLocationId == locationId)
                .ToList();
        }

        // orders მოძებნე containerId-ით
        public List<Order> SearchOrdersByContainer(int containerId)
        {
            return _orders
                .Where(o => o.ContainerId == containerId)
                .ToList();
        }

        // orders მოძებნე courierId-ით
        public List<Order> SearchOrdersByCourier(int courierId)
        {
            return _orders
                .Where(o => o.CourierId == courierId)
                .ToList();
        }

        // მოძებნე locations კურიერის სახელით + გვარით
        public List<Location> SearchLocationsByCourier(string courierFullName)
        {
            var parts = courierFullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2) return new List<Location>();

            string name = parts[0];
            string surname = parts[1];

            var courier = _couriers.FirstOrDefault(c =>
                c.Name.Equals(name, StringComparison.OrdinalIgnoreCase) &&
                c.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase));

            if (courier == null) return new List<Location>();

            var locIds = _orders
                .Where(o => o.CourierId == courier.Id)
                .SelectMany(o => new[] { o.StartLocationId, o.EndLocationId })
                .Distinct()
                .ToList();

            return _locations
                .Where(l => locIds.Contains(l.Id))
                .ToList();
        }
    }
}

