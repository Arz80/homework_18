using Tamagochi.Interfaces;
using Tamagochi.Modules;

namespace Tamagochi.BL;

static class Display
{
    public static void Show(List<Cat> cats)
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.BackgroundColor = ConsoleColor.White;
        Console.WriteLine();       
        Console.WriteLine("\t----+-----------------+------------+------------+------------+------------+-------------------+");
        Console.WriteLine("\t {0,-2} | {1,-15} | {2,-10} | {3,-10} | {4,-10} | {5,-10} | {6,-17} |", "#", "Имя", "Возраст", "Здоровье", "Настроение", "Сытость", "Средний уровень");
        Console.WriteLine("\t----+-----------------+------------+------------+------------+------------+-------------------+");
        int id = 0;
        foreach (Cat cat in cats)
        {
            Console.WriteLine("\t {0,-2} | {1,-15} | {2,-10} | {3,-10} | {4,-10} | {5,-10} | {6,-17} |", id, cat.Name, cat.Age, cat.Health, cat.Mood, cat.Satiety, cat.Level);
            Console.WriteLine("\t----+-----------------+------------+------------+------------+------------+-------------------+");
            id++;
        }
        Console.ResetColor();
        Console.WriteLine();
    }
}
