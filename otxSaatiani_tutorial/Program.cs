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
            // 0. ნულოვანი წერტილი საიდანაც უნდა დაიწყოს ჩემი ცვლილება 
            Console.WriteLine(" bidzinas dedas movtynav\n " +
                "-vnaxot aba ra moxdeba\n -putinic miyveba \n//////////////");

            // 1. მომხმარებლის მიერ ფოლდერის შეყვანა
            Console.Write("enter folder name: ");
            string folderName = Console.ReadLine();
            Console.WriteLine("folder name is " + folderName);

            // 2. მომხმარებლის მიერ ფაილის სახელის შეყვანა
            Console.Write("enter file name (without .txt): ");
            string fileName = Console.ReadLine() + ".txt";
            Console.WriteLine("file name is " + fileName);

            // 3. ფოლდერის სრული მისამართი
            //string fullPath = Path.Combine(Environment.CurrentDirectory, folderName);
            // ფოლდერის მისამართს აბრუნებს ოღონდ cs ფაილი სადაც არის მანდ. მოკლედ ორით უკან ის ბინში ვარდებოდა
            // და გიტ იგნორით ბინ ფაილს ვერ ვკითხულობდი ასატვირთად. არადა უნდა დავადეკლალირო დაწყება ამ საქმის ტექსტ ფაილით
            string fullPath = Path.Combine(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..","..")), folderName);
            Console.WriteLine("fullpath is " + fullPath);
           
            // 3.4 აქ ჯერ შეამოწმოს fullpath ში რა ფოლდერებია
            // ამომიწეროს და მკითხოს ახალი ფოლდერი შევქნა თუ ავირჩიო 
            // თუ შეყვანილი ფოლდერის სახელირომელიმეს ემთხვევა მითხრას რომ მაგაში ჩაიწრება?
            // როგორ ავირჩიო ორით უკან ფაილი? 
            // kai jer chavwero faili shignit da mere vnaxot aba ra da rogor gadavaketo

            // Console.WriteLine("pauza");
            // Console.ReadLine();

            // 4. ფოლდერის შექმნა (თუ არ არსებობს)
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
                Console.WriteLine("folder created: " + fullPath);
            } else
            {
                Console.WriteLine("folder exist: " + fullPath);
            }

            // 5. ტექსტის შეყვანა
            Console.Write("enter text for file: ");
            string text = Console.ReadLine();

            // 6. ფაილის სრული მისამართი
            string filePath = Path.Combine(fullPath, fileName);

            // 7. ტექსტის ჩაწერა ფაილში
            File.WriteAllText(filePath, text);
            Console.WriteLine("text will save in file: " + filePath);

            // 8. ფაილიდან წაკითხვა
            string readText = File.ReadAllText(filePath);
            Console.WriteLine("\n📖 text from file:");
            Console.WriteLine(readText);
        }
    }
}
