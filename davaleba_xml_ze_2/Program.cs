using davaleba_xml_ze_2.klasebi;
using davaleba_xml_ze_2.servisebi;
using System;
using System.IO;
using System.Linq;

// Paths
string projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
string xmlPath = Path.Combine(projectRoot, "XML", "XMLForKapanasTask.xml");
string newXmlPath = Path.Combine(projectRoot, "XML", "NewDVShipper.xml");

// 1. Reader and data
IReaderService reader = new XmlReaderService(xmlPath);
var locations = reader.ReadLocations();
var containers = reader.ReadContainers();
var couriers = reader.ReadCouriers();
var orders = reader.ReadOrders();

// 2. Services
ISearchService search = new SearchService(locations, containers, couriers, orders);
IWriterService writer = new XmlWriterService(locations, containers, couriers, orders);

// 3. Menu loop with try-catch
while (true)
{
    Console.WriteLine("Choose action:");
    Console.WriteLine("1 - Search orders by location");
    Console.WriteLine("2 - Search orders by container");
    Console.WriteLine("3 - Search orders by courierId");
    Console.WriteLine("4 - Search locations by courier full name");
    Console.WriteLine("5 - Save new XML");
    Console.WriteLine("0 - Exit");
    Console.Write(">> ");
    string? choice = Console.ReadLine();
    Console.Clear();

    try
    {
        switch (choice)
        {
            case "1":
                Console.Write("Enter location id: ");
                int locId = int.Parse(Console.ReadLine()!);
                var locOrders = search.SearchOrdersByLocation(locId);

                if (locOrders.Any())
                {
                    Console.WriteLine("Orders found:");
                    foreach (var o in locOrders)
                    {
                        Console.WriteLine($"OrderId: {o.Id}, ContainerId: {o.ContainerId}, CourierId: {o.CourierId}, StartLoc: {o.StartLocationId}, EndLoc: {o.EndLocationId}");
                    }
                }
                else
                {
                    Console.WriteLine("No orders found for this location.");
                }
                break;

            case "2":
                Console.Write("Enter container id: ");
                int contId = int.Parse(Console.ReadLine()!);
                var contOrders = search.SearchOrdersByContainer(contId);

                if (contOrders.Any())
                {
                    Console.WriteLine("Orders found:");
                    foreach (var o in contOrders)
                    {
                        Console.WriteLine($"OrderId: {o.Id}, ContainerId: {o.ContainerId}, CourierId: {o.CourierId}, StartLoc: {o.StartLocationId}, EndLoc: {o.EndLocationId}");
                    }
                }
                else
                {
                    Console.WriteLine("No orders found for this container.");
                }
                break;

            case "3":
                Console.Write("Enter courier id: ");
                int courierId = int.Parse(Console.ReadLine()!);
                var courierOrders = search.SearchOrdersByCourier(courierId);

                if (courierOrders.Any())
                {
                    Console.WriteLine("Orders found:");
                    foreach (var o in courierOrders)
                    {
                        Console.WriteLine($"OrderId: {o.Id}, ContainerId: {o.ContainerId}, CourierId: {o.CourierId}, StartLoc: {o.StartLocationId}, EndLoc: {o.EndLocationId}");
                    }
                }
                else
                {
                    Console.WriteLine("No orders found for this courier.");
                }
                break;

            case "4":
                Console.Write("Enter courier full name (Name Surname): ");
                string fullname = Console.ReadLine()!;
                var locs = search.SearchLocationsByCourier(fullname);

                if (locs.Any())
                {
                    Console.WriteLine("Locations found:");
                    foreach (var l in locs)
                    {
                        Console.WriteLine($"LocationId: {l.Id}, Name: {l.Name}, Address: {l.Address}");
                    }
                }
                else
                {
                    Console.WriteLine("No locations found for this courier.");
                }
                break;

            case "5":
                writer.SaveToFile(newXmlPath);
                Console.WriteLine("XML saved!");
                break;

            case "0":
                return;

            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    Console.WriteLine("\nPress Enter to continue...");
    Console.ReadLine();
    Console.Clear();
}
