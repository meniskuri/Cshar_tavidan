using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DvShipperApi.Interfaces;
using DvShipperApi.Services;
using System.IO;


var builder = WebApplication.CreateBuilder(args);

string projectRoot = AppContext.BaseDirectory;
string xmlPath = Path.Combine(projectRoot, "..", "..", "..", "Data", "XMLForKapanasTask.xml");
xmlPath = Path.GetFullPath(xmlPath);

// DI registration
builder.Services.AddSingleton<IReaderService>(sp => new XmlReaderService(xmlPath));
builder.Services.AddSingleton<ISearchService>(sp =>
{
    var reader = sp.GetRequiredService<IReaderService>();
    return new SearchService(reader.ReadLocations(), reader.ReadContainers(), reader.ReadCouriers(), reader.ReadOrders());
});
builder.Services.AddSingleton<IWriterService>(sp =>
{
    var reader = sp.GetRequiredService<IReaderService>();
    return new XmlWriterService(reader.ReadLocations(), reader.ReadContainers(), reader.ReadCouriers(), reader.ReadOrders());
});

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();

// წკაპანა დრაკონჩიკი
// აქ ჯერ არ მაქვს მაგრამ ვაკეთებ