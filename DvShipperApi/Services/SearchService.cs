using DvShipperApi.Models;
using DvShipperApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DvShipperApi.Services
{
    public class SearchService : ISearchService
    {
        private readonly List<Location> _locations;
        private readonly List<Container> _containers;
        private readonly List<Courier> _couriers;
        private readonly List<Order> _orders;

        public SearchService(
            List<Location> locations,
            List<Container> containers,
            List<Courier> couriers,
            List<Order> orders)
        {
            _locations = locations;
            _containers = containers;
            _couriers = couriers;
            _orders = orders;
        }

        public List<Order> SearchOrdersByLocation(int locationId) =>
            _orders.Where(o => o.StartLocationId == locationId || o.EndLocationId == locationId).ToList();

        public List<Order> SearchOrdersByContainer(int containerId) =>
            _orders.Where(o => o.ContainerId == containerId).ToList();

        public List<Order> SearchOrdersByCourier(int courierId) =>
            _orders.Where(o => o.CourierId == courierId).ToList();

        public List<Location> SearchLocationsByCourier(string courierFullName)
        {
            var parts = courierFullName.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2) return new List<Location>();
            var name = parts[0];
            var surname = parts[1];

            var courier = _couriers.FirstOrDefault(c =>
                c.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase) &&
                c.Surname.Equals(surname, System.StringComparison.OrdinalIgnoreCase));

            if (courier == null) return new List<Location>();

            var locIds = _orders
                .Where(o => o.CourierId == courier.Id)
                .SelectMany(o => new[] { o.StartLocationId, o.EndLocationId })
                .Distinct()
                .ToList();

            return _locations.Where(l => locIds.Contains(l.Id)).ToList();
        }
    }
}
