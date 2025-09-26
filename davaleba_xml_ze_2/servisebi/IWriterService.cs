using davaleba_xml_ze_2.klasebi;
using System.Xml.Linq;

namespace davaleba_xml_ze_2.servisebi
{
    public interface IWriterService
    {
        XDocument BuildXml();
        void SaveToFile(string filePath);
    }
}
