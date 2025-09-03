using System;
using davaleba_xml_ze_2;
using davaleba_xml_ze_2.klasebi;

// 1️ XML ფაილის გზა და 2️ XmlReaderService ობიექტის შექმნა
string xmlPath = "C:\\Users\\Gio\\Desktop\\Programireba\\Cshar_tavidan\\davaleba_xml_ze_2\\XML\\XMLForKapanasTask.xml";
 
var reader = new XmlReaderService(xmlPath);

// 3️ XML-ის წაკითხვა და ობიექტების მიღება
var locations = reader.ReadLocations();
var containers = reader.ReadContainers();
var couriers = reader.ReadCouriers();
var orders = reader.ReadOrders();

// 4 ახალი xml ის შექმნა 
// XmlWriterService–ის შექმნა
var writer = new XmlWriterService(locations, containers, couriers, orders);

// ახალი XML დოკუმენტის შექმნა
var newDoc = writer.BuildXml();
// Console.WriteLine(newDoc);

// შენახვა ფაილში
writer.SaveToFile("C:\\Users\\Gio\\Desktop\\Programireba\\Cshar_tavidan\\davaleba_xml_ze_2\\XML\\NewDVShipper.xml");


// 5 მონაცემების კონსოლზე გამოჩენა
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
