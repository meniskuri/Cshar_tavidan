using davaleba_xml_ze_2.klasebi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace davaleba_xml_ze_2
{
    public class XmlWriterService
    {
        private readonly List<Location> _locations;
        private readonly List<Container> _containers;
        private readonly List<Courier> _couriers;
        private readonly List<Order> _orders;

        // კონსტრუქტორი – ლისტების მიღება
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

        // ახალი XML-ის შექმნა
        public XDocument BuildXml()
        {
            var newDoc = new XDocument(
                new XElement("dvshipper",
                    new XElement("locations",
                        from loc in _locations
                        select new XElement("location",
                            new XAttribute("id", loc.Id),
                            new XAttribute("name", loc.Name ?? ""),
                            new XAttribute("adress", loc.Address ?? "")
                        )
                    ),
                    new XElement("containers",
                        from cont in _containers
                        select new XElement("container",
                            new XAttribute("id", cont.Id),
                            new XAttribute("name", cont.Name ?? ""),
                            new XAttribute("barcode", cont.Barcode ?? "")
                        )
                    ),
                    new XElement("couriers",
                        from cour in _couriers
                        select new XElement("courier",
                            new XAttribute("id", cour.Id),
                            new XAttribute("name", cour.Name ?? ""),
                            new XAttribute("surname", cour.Surname ?? ""),
                            new XAttribute("phonenumber", cour.PhoneNumber ?? "")
                        )
                    ),
                    new XElement("orders",
                        from ord in _orders
                        select new XElement("order",
                            new XAttribute("id", ord.Id),
                            new XAttribute("start_location_id", ord.StartLocationId),
                            new XAttribute("end_location_id", ord.EndLocationId),
                            new XAttribute("container_id", ord.ContainerId),
                            new XAttribute("courier_id", ord.CourierId),
                            new XAttribute("start_date_time", ord.StartDateTime.ToString("dd/MM/yyyy HH:mm")),
                            new XAttribute("end_date_time", ord.EndDateTime.ToString("dd/MM/yyyy HH:mm"))
                        )
                    )
                )
            );

            return newDoc;
        }

        // XML-ის შენახვა ფაილში
        public void SaveToFile(string filePath)
        {
            var newDoc = BuildXml();
            newDoc.Save(filePath);
        }
    }
}
