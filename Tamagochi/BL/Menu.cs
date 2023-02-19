using Tamagochi.Modules;

namespace Tamagochi.BL;
class Menu
{
    private List<string> Menus { get; set; } = new List<string>();
    private int selected = 0;
    public Menu()
    {
        Menus.Add("Завести нового питомца");
        Menus.Add("Покормить");
        Menus.Add("Поиграть");
        Menus.Add("К ветеренару");
        Menus.Add("Следующиц день");
        Menus.Add("Выход");
    }
    public void DisplayMenu()
    {
        for (int i = 0; i < Menus.Count; i++)
        {
            if (selected == i)
            {
                Console.ForegroundColor= ConsoleColor.Blue;
                Console.WriteLine($"\t> {Menus[i]}");
            }
            else
            { 
                Console.ForegroundColor= ConsoleColor.White;
                Console.WriteLine($"\t  {Menus[i]}");
            }
            Console.ResetColor();
        }
    }
    public int Run()
    {
        List<Cat> allCats = FileManager.ReadAll();
        List<Cat> sortAllCats = allCats.OrderBy( cat => cat.Level).ToList();
        allCats = sortAllCats;
        FileManager.SaveAll(allCats);

        //Console.WriteLine();
        while (true)
        {
            Console.Clear();
            Display.Show(allCats);
            DisplayMenu();
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.DownArrow:
                    if (selected < Menus.Count - 1)
                    {
                        selected++;
                    }
                    break;

                case ConsoleKey.UpArrow:
                    if (selected > 0)
                    {
                        selected--;
                    }
                    break;

                case ConsoleKey.Enter:
                    return selected;
            }
        }
    }
}