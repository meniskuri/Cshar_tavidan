using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otxSaatiani_tutorial
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            // start 
            Console.WriteLine(" bidzinas dedas movtynav\n " +
                "-vnaxot aba ra moxdeba\n -putinic miyveba\n" +
                "//////////////////////////////////////////////\n");
            Console.WriteLine("es programa gkitxavs folderis saxels (momxmareblis)\n" +
                "mere gkitxavs failis saxelis (chanaweris)\n" +
                "mere gkitxavs ra chaweros failshi\n" +
                "jerjerobit esaa\n" +
                "//////////////////////////////////////////////\n");
            
            // aq unda iyos cvladeis agwera
            int lineCount          = 0;         // ფაილში რომელზეც ვმუშაობ ლაინების შემოწმება

            string fullPath_jado   = "";        // ჯადოების ფოლდერის სრული მისამართი
            string folderName_jado = "Jadoebi"; // ამ ფოლდერში იწერება ყველაფერი (რაც ქლაუდზე წავა)
            
            string folderName      = "";        // მომხმარებლის მიერ შექმნილი ფოლდერი jadoebi - ში
            string fullPath        = "";        // ფოლდერ ჯადოებში შექმნილი ფოლდერის და შიგნით ფაილის სრული მისამართი

            string fileName        = "";        // მომხმარებლის მიერ შექმნილი ფაილის სახელი (.txt ს გარეშე)
            string filePath        = "";        //
            string text            = "";        // შეყვანილი ტექსტი
            string readText        = "";        // ტექსტის ამოკითხვა

            // folder jadoebi სადაც ჩაიწერება ლოცვები იმის მიხედვით ვინ გაუშვებს ამ კოდს
            fullPath_jado   = Path.Combine(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..")), folderName_jado);
            // aq unda iyos faili statistikis  

            // მომხმარებლის მიერ ფოლდერის შეყვანა და ფოლდერის სრული მისამართი
            Console.Write("enter folder name: ");
            folderName = Console.ReadLine();
            Console.WriteLine("folder name is " + folderName);

            fullPath = Path.Combine(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..")), fullPath_jado, folderName);
            Console.WriteLine("fullpath_folder is " + fullPath);

            // მომხმარებლის მიერ ფაილის სახელის შეყვანა და ფაილის სრული მისამართი
            Console.Write("enter file name (without .txt): ");
            fileName = Console.ReadLine() + ".txt";
            Console.WriteLine("file name is " + fileName);
            
            filePath = Path.Combine(fullPath, fileName);

            // აქ ჯერ შეამოწმოს fullpath ში რა ფოლდერებია
            // ამომიწეროს და მკითხოს ახალი ფოლდერი შევქნა თუ ავირჩიო 
            // თუ შეყვანილი ფოლდერის სახელირომელიმეს ემთხვევა მითხრას რომ მაგაში ჩაიწრება?
            // როგორ ავირჩიო ორით უკან ფაილი? 
            // kai jer chavwero faili shignit da mere vnaxot aba ra da rogor gadavaketo

            // ფოლდერის შექმნა (თუ არ არსებობს)
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
                Console.WriteLine("folder created: " + fullPath);
            } else
            {
                Console.WriteLine("folder exist: " + fullPath);
            }

            // ტექსტის შეყვანა
            Console.Write("enter text for file: ");
            text = Console.ReadLine();

            // ლაინების რაოდენობას ითვლის ფოლდერში
            lineCount = File.ReadAllLines(filePath).Length;
            Console.WriteLine("lineCount in file is " + lineCount);

            // ტექსტის ჩაწერა ფაილში
            // File.WriteAllText(filePath, text);
            File.AppendAllText(filePath, text + Environment.NewLine); ;
            Console.WriteLine("text will save in file: " + filePath);
            

            // ფაილიდან წაკითხვა
            readText = File.ReadAllText(filePath);
            Console.WriteLine("text from file:");
            Console.WriteLine(readText);
        }
    }
}
