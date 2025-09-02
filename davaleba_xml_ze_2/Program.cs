using System;
using davaleba_xml_ze_2;
using davaleba_xml_ze_2.klasebi;

// 1️⃣ XML ფაილის გზა
string xmlPath = "C:\\Users\\Gio\\Desktop\\Programireba\\Cshar_tavidan\\davaleba_xml_ze_2\\XML\\XMLForKapanasTask.xml";

// 2️⃣ XmlReaderService ობიექტის შექმნა
var reader = new XmlReaderService(xmlPath);

// 3️⃣ XML-ის წაკითხვა და ობიექტების მიღება
var locations = reader.ReadLocations();
var containers = reader.ReadContainers();
var couriers = reader.ReadCouriers();
var orders = reader.ReadOrders();

// 4️⃣ მონაცემების კონსოლზე გამოჩენა
Console.WriteLine("=== Locations ===");
foreach (var loc in locations)
    Console.WriteLine($"{loc.Id} - {loc.Name} - {loc.Address}");

Console.WriteLine("\n=== Containers ===");
foreach (var cont in containers)
    Console.WriteLine($"{cont.Id} - {cont.Name} - {cont.Barcode}");

Console.WriteLine("\n=== Couriers ===");
foreach (var c in couriers)
    Console.WriteLine($"{c.Id} - {c.Name} {c.Surname} - {c.PhoneNumber}");

Console.WriteLine("\n=== Orders ===");
foreach (var o in orders)
    Console.WriteLine($"Order {o.Id}: Location {o.StartLocationId}->{o.EndLocationId}, Container {o.ContainerId}, Courier {o.CourierId}, {o.StartDateTime} - {o.EndDateTime}");
