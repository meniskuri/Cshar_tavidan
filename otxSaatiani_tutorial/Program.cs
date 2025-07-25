﻿using System;
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
            Console.WriteLine(" tamri bibis mode v.1 \n");
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
            int lineCount_stat     = 0;         // statistic ფაილში ლაინების დათვლა
            string numberedLine    = "";        // სტრიქონი სადაც ჩაიწერება 1. 2. 3. ასე შემდეგ ფაილში
            string dateFormatted   = "";        // აქ ვწერ დროს და თარიღს 

            string fileStatistics  = "statistics.txt"; // სტატისტიკის ფაილი (ჩაიწერება რამდენჯერ გაეშვა კოდი) ვინ გაუშვა რა დროს და სად რა ცვლილება მოახდინა? გავართულო?
            string fileStatPath    = "";         // stat ფაილის გზა 
            string numberedLine_stat = "";       // ფაილში ჩაწერისას რიცხვებს 1. 2. აქ ერთიანდება ტექსტთან სტატ ფაილისთვის

            string showFolders     = "";         // გეკითხება გინდა თუარა ნახო ფოლდერების სიაო
            string[] directories;                // jadoebi ფოლდერში ფოლდერების სია

            string kitxva_loop     = "";         // გეკითხება მთავარი loop ის გაგრძელება გინდა თუარა
            string kitxva_loop_folders = "";     // გეკითხება შექმნილ ფოლდერში შევიდეს თუ ახალში

            bool sheqmnili_folder = false;       // ლამპოჩკა შექმნილი ფოლდერი გინდა ამოირჩიო თუ ახალი დაამატოსთვის

            bool gamogdeba;                      // ლუპიდან ამოგდებისთვის ვიყენებ ამას 

            ///////////////////////////////////////////
            // folder jadoebi სადაც ჩაიწერება ლოცვები იმის მიხედვით ვინ გაუშვებს ამ კოდს
            fullPath_jado = Path.Combine(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..")), folderName_jado);

            while (true)
            {
                // loop start
                Console.WriteLine("loop started *********************************");

                // ნახულობს jadoebi ფოლდერში სხვა ფოლდერები არის თუარა და ბეჭდავს
                directories = Directory.GetDirectories(fullPath_jado);

                if (directories.Length == 0)
                {
                    Console.WriteLine("folderebi ar aris.");
                }
                else
                {
                    Console.WriteLine("\n↓ folderebis sia ↓");

                    foreach (string dir in directories)
                    {
                        Console.WriteLine(dir);
                        Console.WriteLine("- " + Path.GetFileName(dir));
                    }
                }

                // ახალი ფოლდერი შექმნას თუ შექმნილებიდან ამოირჩიოს?
                if (directories.Length != 0)
                {
                    Console.WriteLine("//////////");
                    while (true)
                    {
                        Console.WriteLine("sheqmnil foldershi shexval? (ki) axali folderis sheqmna > dawere (ara)");
                        kitxva_loop_folders = Console.ReadLine()?.ToLower();
                        if (kitxva_loop_folders == "ki")
                        {
                            sheqmnili_folder = true;
                            break;
                        }
                        else if (kitxva_loop_folders == "ara")
                        {
                            sheqmnili_folder = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("dawere ki an ara");
                        }
                    }
                }
                

                // folder შეყვანილთან მუშაობა ///////////////////////////////////////////
                // მომხმარებლის მიერ ფოლდერის შეყვანა და ფოლდერის სრული მისამართი ფოლდერის შექმნა (თუ არ არსებობს)
                Console.WriteLine("//////////////////////////////////////////////\n");
                if (directories.Length == 0)
                {
                    Console.Write("enter folder name: ");
                    folderName = Console.ReadLine();
                    Console.WriteLine("folder name is " + folderName);
                }
                else if (directories.Length != 0 && sheqmnili_folder == true)
                {
                    // sheqmnili_folder = true
                    while (true)
                    {
                        Console.WriteLine("//////");
                        Console.WriteLine("sheiyvanet arsebuli folderis saxeli");
                        Console.WriteLine("\n↓ folderebis sia ↓");

                        foreach (string dir in directories)
                        {
                            Console.WriteLine(dir);
                            Console.WriteLine("- " + Path.GetFileName(dir));
                        }

                        Console.Write("enter folder name (sheqmnili_folder = ture): ");
                        folderName = Console.ReadLine();

                        if (directories.Any(dir => Path.GetFileName(dir) == folderName))
                        {
                            Console.WriteLine("monacemebi arsebobs masivshi rogorc folderi saxeli.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("ERROR :sheiyvanet arsebuli folderis saxeli");
                        }
                    }
                }
                else if (directories.Length != 0 && sheqmnili_folder == false)
                {
                    // sheqmnili_folder = false
                    while (true)
                    {
                        Console.WriteLine("//////");
                        Console.WriteLine("sheiyvanet ar arsebuli folderis saxeli");
                        Console.WriteLine("\n↓ folderebis sia ↓");

                        foreach (string dir in directories)
                        {
                            Console.WriteLine(dir);
                            Console.WriteLine("- " + Path.GetFileName(dir));
                        }

                        Console.Write("enter folder name (sheqmnili_folder = false): ");
                        folderName = Console.ReadLine();

                        if (directories.Any(dir => Path.GetFileName(dir) != folderName))
                        {
                            Console.WriteLine("monacemebi ar arsebobs masivshi rogorc folderi saxeli.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("ERROR :sheiyvanet ar arsebuli folderis saxeli");
                        }
                    }

                }
                else
                {
                    Console.WriteLine("ERROR: >>>>>>>>>>> chedavs <<<<<<<<<<<<<<<");
                }
                
                // ფოლდერის შექმნა 
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

                // რომელ ფოლდერშიც ხარ შესული ჩანაწერის გასაკეთებლად ნახულობს ფაილების სიას
                string[] files = Directory.GetFiles(fullPath);

                if (files.Length == 0)
                {
                    Console.WriteLine("ფაილები არ მოიძებნა ფოლდერში.");
                }
                else
                {
                    Console.WriteLine("↓ ფაილების სია ↓");
                    foreach (string file in files)
                    {
                        Console.WriteLine("- " + Path.GetFileName(file));
                    }
                }

                // გკითხოს რომელ ფაილში შევიდეს? 

                Console.WriteLine("/////////////\n");
                Console.Write("enter file name (without .txt): ");
                fileName = Console.ReadLine() + ".txt";
                Console.WriteLine("file name is " + fileName);

                filePath = Path.Combine(fullPath, fileName);

                // ტექსტის შეყვანა
                Console.WriteLine("/////////////////\n");
                Console.Write("enter text for file: ");
                text = Console.ReadLine();

                fileStatPath = Path.Combine(fullPath_jado, fileStatistics);
                // ლაინების რაოდენობას ითვლის სტატ ფაილში
                if (File.Exists(fileStatPath))
                {
                    lineCount_stat = File.ReadAllLines(fileStatPath).Length;
                    Console.WriteLine("file exists");
                    Console.WriteLine("lineCount_stat in file is " + lineCount_stat);
                }
                else
                {
                    Console.WriteLine("file does not exists");
                    Console.WriteLine("lineCount_stat in file is " + lineCount_stat);
                }
                
                // ლაინების რაოდენობას ითვლის რასაც ქმნი იქ
                if (File.Exists(filePath))
                {
                    lineCount = File.ReadAllLines(filePath).Length;
                    Console.WriteLine("file exists");
                    Console.WriteLine("lineCount in file is " + lineCount);
                }
                else
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

                // statistic ფაილი  
                Console.WriteLine("///////////////\n");
                numberedLine_stat = $"{lineCount_stat + 1}. {"cvlileba sheitana: "} {folderName} {dateFormatted}";

                File.AppendAllText(fileStatPath, numberedLine_stat + Environment.NewLine); ;
                Console.WriteLine("statistic text will save in file: " + fileStatPath);

                // ტექსტის ჩაწერა ფაილში 
                // File.WriteAllText(filePath, text);
                File.AppendAllText(filePath, numberedLine + Environment.NewLine); ;
                Console.WriteLine("text will save in file: " + filePath);

                
                ///////////////////////////////////////////
                // ფაილიდან წაკითხვა (+ უნდა იყოს რამდენჯერ გაეშვა კოდი წაკითხული)
                Console.WriteLine("//////////////////////////////////////////////\n");
                readText = File.ReadAllText(filePath);
                Console.WriteLine("text from file:");
                Console.WriteLine(readText);

   
                ///////////////////////////////////////////
                // გინდა loop ის გაგრძელება?
                while (true)
                {
                    Console.Write("ginda gagrdzeleba (ki/ara) ?");
                    kitxva_loop = Console.ReadLine()?.ToLower();
                    
                    if (kitxva_loop == "ki" || kitxva_loop == "KI")
                    {
                        Console.WriteLine("ki");
                        gamogdeba = false;
                        break;
                    }
                    else if (kitxva_loop == "ara")
                    {
                        Console.WriteLine("ara");
                        gamogdeba = true;
                        break;
                    } 
                    else
                    {
                        Console.WriteLine("sheiyvane ki an ara");
                    }    
                }

                if (gamogdeba == true)
                {
                    break;
                }

                // ეს კოდი ელექტრას ეძღვნება
             //
            }
         //
        }
    }
}
