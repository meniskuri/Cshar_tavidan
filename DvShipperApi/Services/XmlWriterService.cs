using DvShipperApi.Models;
using DvShipperApi.Interfaces;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DvShipperApi.Services
{
    public class XmlWriterService : IWriterService
    {
        private readonly List<Location> _locations;
        private readonly List<Container> _containers;
        private readonly List<Courier> _couriers;
        private readonly List<Order> _orders;

        public XmlWriterService(
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

        public XDocument BuildXml()
        {
            return new XDocument(
                new XElement("dvshipper",
                    new XElement("locations",
                        _locations.Select(loc =>
                            new XElement("location",
                                new XAttribute("id", loc.Id),
                                new XAttribute("name", loc.Name ?? ""),
                                new XAttribute("adress", loc.Address ?? "")
                            ))),
                    new XElement("containers",
                        _containers.Select(cont =>
                            new XElement("container",
                                new XAttribute("id", cont.Id),
                                new XAttribute("name", cont.Name ?? ""),
                                new XAttribute("barcode", cont.Barcode ?? "")
                            ))),
                    new XElement("couriers",
                        _couriers.Select(cour =>
                            new XElement("courier",
                                new XAttribute("id", cour.Id),
                                new XAttribute("name", cour.Name ?? ""),
                                new XAttribute("surname", cour.Surname ?? ""),
                                new XAttribute("phonenumber", cour.PhoneNumber ?? "")
                            ))),
                    new XElement("orders",
                        _orders.Select(ord =>
                            new XElement("order",
                                new XAttribute("id", ord.Id),
                                new XAttribute("start_location_id", ord.StartLocationId),
                                new XAttribute("end_location_id", ord.EndLocationId),
                                new XAttribute("container_id", ord.ContainerId),
                                new XAttribute("courier_id", ord.CourierId),
                                new XAttribute("start_date_time", ord.StartDateTime.ToString("dd/MM/yyyy HH:mm")),
                                new XAttribute("end_date_time", ord.EndDateTime.ToString("dd/MM/yyyy HH:mm"))
                            )))));
        }

        public void SaveToFile(string filePath)
        {
            BuildXml().Save(filePath);
        }
    }
}
