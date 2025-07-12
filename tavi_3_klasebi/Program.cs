using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace tavi_3_klasebi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // shevqmant konstruqtorit obieqti
            Person giorgi = new Person();

            Console.WriteLine(giorgi);
            giorgi.name = "giorgi";
            giorgi.age = 33;
            giorgi.Print();
            
        }
    }
}
