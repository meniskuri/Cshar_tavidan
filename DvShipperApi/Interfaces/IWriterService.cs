using DvShipperApi.Models;
using System.Xml.Linq;

namespace DvShipperApi.Interfaces
{
    public interface IWriterService
    {
        XDocument BuildXml();
        void SaveToFile(string filePath);
    }
}
