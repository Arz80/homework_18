using System.Text.Json;
using Tamagochi.Interfaces;
using Tamagochi.Modules;

namespace Tamagochi.BL;

static class FileManager
{
    private static string fileName = "DBCats\\Cats.json";
    private static string directoryName = "DBCats";
    
    public static void SaveAll(List<Cat> allCat)
    {
        // TODO: записать в файл
        File.WriteAllText(fileName, "");
        foreach (Cat cat in allCat)
        { 
            SaveOne(cat);
        }
    }
    public static void SaveOne(Cat cat)
    {
        string serCat = JsonSerializer.Serialize<Cat>(cat);
        File.AppendAllText(fileName, serCat + "\n");
            
    }
    public static List<Cat> ReadAll()
    {
        Directory.CreateDirectory(directoryName);
        if (File.Exists(fileName))
        {
            string[] allCatsString = File.ReadAllLines(fileName);
            List<Cat> allCats = new List<Cat>();
            foreach (string cat in allCatsString)
            {
                Cat? catDesir = JsonSerializer.Deserialize<Cat>(cat);
                if (catDesir != null)
                {
                    allCats.Add(catDesir);
                }
            }
            return allCats;
        }
        else 
        {
            Console.ForegroundColor= ConsoleColor.DarkCyan;
            Console.WriteLine("\t ************************************************************");
            Console.WriteLine("\t ********                                            ********");
            Console.WriteLine("\t ********          В базе нет ни одного Кота         ********");
            Console.WriteLine("\t *** Для продожения программы ва нужно ввести данные Кота ***");
            Console.WriteLine("\t ***                                                      ***");
            Console.WriteLine("\t ************************************************************\n");
            Console.ResetColor();
            File.Create(fileName).Close();
            SaveOne(Actions.InputData());
            return ReadAll();
        }
    }
    public static void ReadOne()
    {
        // TODO: Прочитать из файла

    }
    public static void Sorting()
    {
        // TODO: Показать таблицу на экране
    }
}
