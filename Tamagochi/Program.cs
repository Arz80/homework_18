using System.Text;
using Tamagochi.BL;
using Tamagochi.Modules;

namespace Tamagochi;

class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        /*Cat cat = InputData();
        FileManager.SaveOne(cat);*/
        
        Menu menu = new Menu();
        while (true)
        {
            switch (menu.Run())
            {
                case 0:
                    FileManager.SaveOne(Actions.InputData());
                    break;
                case 1:
                    Actions.ActionCat("Вы покормили кота", 1);
                    break;
                case 2:
                    Actions.ActionCat("Вы покорали с котом", 2);
                    break;
                case 3:
                    Actions.ActionCat("Вы поличили кота", 3);
                    break;
                case 4:
                    Actions.NextDay();
                    break;

                case 5:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
            }
            Console.Clear();
        }
    }

    
}