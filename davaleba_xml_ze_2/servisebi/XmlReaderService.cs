using davaleba_xml_ze_2.klasebi;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.XPath;

namespace davaleba_xml_ze_2.servisebi
{
    public class XmlReaderService : IReaderService
    {
        private readonly XDocument _doc;

        public XmlReaderService(string xmlFilePath)
        {
            _doc = XDocument.Load(xmlFilePath);
        }

        public List<Location> ReadLocations()
        {
            var items = _doc.XPathSelectElements("/dvshipper/locations/location");
            var locations = new List<Location>();
            foreach (var item in items)
            {
                locations.Add(new Location
                {
                    Id = (int?)item.Attribute("id") ?? 0,
                    Name = (string?)item.Attribute("name"),
                    Address = (string?)item.Attribute("adress")
                });
            }
            return locations;
        }

        public List<Container> ReadContainers()
        {
            var items = _doc.XPathSelectElements("/dvshipper/containers/container");
            var containers = new List<Container>();
            foreach (var item in items)
            {
                containers.Add(new Container
                {
                    Id = (int?)item.Attribute("id") ?? 0,
                    Name = (string?)item.Attribute("name"),
                    Barcode = (string?)item.Attribute("barcode")
                });
            }
            return containers;
        }

        public List<Courier> ReadCouriers()
        {
            var items = _doc.XPathSelectElements("/dvshipper/couriers/courier");
            var couriers = new List<Courier>();
            foreach (var item in items)
            {
                couriers.Add(new Courier
                {
                    Id = (int?)item.Attribute("id") ?? 0,
                    Name = (string?)item.Attribute("name"),
                    Surname = (string?)item.Attribute("surname"),
                    PhoneNumber = (string?)item.Attribute("phonenumber")
                });
            }
            return couriers;
        }

        public List<Order> ReadOrders()
        {
            var items = _doc.XPathSelectElements("/dvshipper/orders/order");
            var orders = new List<Order>();
            foreach (var item in items)
            {
                orders.Add(new Order
                {
                    Id = (int?)item.Attribute("id") ?? 0,
                    StartLocationId = (int?)item.Attribute("start_location_id") ?? 0,
                    EndLocationId = (int?)item.Attribute("end_location_id") ?? 0,
                    ContainerId = (int?)item.Attribute("container_id") ?? 0,
                    CourierId = (int?)item.Attribute("courier_id") ?? 0,
                    StartDateTime = DateTime.ParseExact((string)item.Attribute("start_date_time")!, "dd/MM/yyyy HH:mm", null),
                    EndDateTime = DateTime.ParseExact((string)item.Attribute("end_date_time")!, "dd/MM/yyyy HH:mm", null)
                });
            }
            return orders;
        }
    }
}
