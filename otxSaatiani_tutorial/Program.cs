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
            ///////////////////////////////////////////
            // start 
            Console.WriteLine(" tsmti bibis mode v.1 \n");
            Console.WriteLine("es programa gkitxavs folderis saxels (momxmareblis)\n" +
                "mere gkitxavs failis saxelis (chanaweris)\n" +
                "mere gkitxavs ra chaweros failshi\n" +
                "jerjerobit esaa\n" +
                "//////////////////////////////////////////////\n");
            
            ///////////////////////////////////////////
            // aq unda iyos cvladeis agwera
            string fullPath_jado   = "";        // ჯადოების ფოლდერის სრული მისამართი
            string folderName_jado = "Jadoebi"; // ამ ფოლდერში იწერება ყველაფერი (რაც ქლაუდზე წავა)
            
            string folderName      = "";        // მომხმარებლის მიერ შექმნილი ფოლდერი jadoebi - ში
            string fullPath        = "";        // ფოლდერ ჯადოებში შექმნილი ფოლდერის და შიგნით ფაილის სრული მისამართი

            string fileName        = "";        // მომხმარებლის მიერ შექმნილი ფაილის სახელი (.txt ს გარეშე)
            string filePath        = "";        //
            
            string text            = "";        // შეყვანილი ტექსტი
            string readText        = "";        // ტექსტის ამოკითხვა

            int lineCount          = 0;         // ფაილში რომელზეც ვმუშაობ ლაინების შემოწმება
            string numberedLine    = "";        // სტრიქონი სადაც ჩაიწერება 1. 2. 3. ასე შემდეგ ფაილში
            string dateFormatted   = "";        // აქ ვწერ დროს და თარიღს 

            ///////////////////////////////////////////
            // folder jadoebi სადაც ჩაიწერება ლოცვები იმის მიხედვით ვინ გაუშვებს ამ კოდს
            fullPath_jado = Path.Combine(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..")), folderName_jado);

            ///////////////////////////////////////////
            // aq unda iyos faili statistikis  

            // folder შეყვანილთან მუშაობა ///////////////////////////////////////////
            // მომხმარებლის მიერ ფოლდერის შეყვანა და ფოლდერის სრული მისამართი ფოლდერის შექმნა (თუ არ არსებობს)
            Console.WriteLine("//////////////////////////////////////////////\n");
            Console.Write("enter folder name: ");
            folderName = Console.ReadLine();
            Console.WriteLine("folder name is " + folderName);

            fullPath = Path.Combine(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..")), fullPath_jado, folderName);
            Console.WriteLine("fullpath is " + fullPath);

            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
                Console.WriteLine("folder created: " + fullPath);
            }
            else
            {
                Console.WriteLine("folder exist: " + fullPath);
            }

            // text ფაილთან მუშაობა ///////////////////////////////////////////
            // მომხმარებლის მიერ ფაილის სახელის შეყვანა და ფაილის სრული მისამართი
            Console.WriteLine("//////////////////////////////////////////////\n");
            Console.Write("enter file name (without .txt): ");
            fileName = Console.ReadLine() + ".txt";
            Console.WriteLine("file name is " + fileName);
            
            filePath = Path.Combine(fullPath, fileName);

            // ტექსტის შეყვანა
            Console.Write("enter text for file: ");
            text = Console.ReadLine();

            // ლაინების რაოდენობას ითვლის ფოლდერში
            if (File.Exists(filePath))
            {
                lineCount = File.ReadAllLines(filePath).Length;
                Console.WriteLine("file exists");
                Console.WriteLine("lineCount in file is " + lineCount);
            } else
            {
                Console.WriteLine("file does not exists");
                Console.WriteLine("lineCount in file is " + lineCount);
            }

            // date time
            DateTime now = DateTime.Now;
            Console.WriteLine(now);
            dateFormatted = now.ToString("yyyy-MM-dd HH:mm:ss");

            // ნომრით სტრიქონის ფორმირება (ჩაწერის დროს 1. 2. 3. ჩანაწერის რაოდენობა რომ გააკეთოს)
            numberedLine = $"{lineCount + 1}. {text} {dateFormatted}";
            Console.WriteLine(">>>> numberedLine >>>>> " + numberedLine);

            // ტექსტის ჩაწერა ფაილში 
            // File.WriteAllText(filePath, text);
            File.AppendAllText(filePath, numberedLine + Environment.NewLine); ;
            Console.WriteLine("text will save in file: " + filePath);

            // ფაილიდან წაკითხვა
            readText = File.ReadAllText(filePath);
            Console.WriteLine("text from file:");
            Console.WriteLine(readText);

            // ეს კოდი ელექტრას ეძღვნება
        }
    }
}
