using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagochi.Modules;

namespace Tamagochi.BL
{
    internal class Actions
    {
        public static void NextDay()
        {
            List<Cat> allCats = new List<Cat>();
            List<Cat> allCatsNew = new List<Cat>();
            Random rand = new Random();
            allCats = FileManager.ReadAll();
            foreach (Cat cat in allCats)
            {
                cat.Satiety += rand.Next(1, 6);
                cat.Mood += rand.Next(-3, 4);
                cat.Health += rand.Next(-3, 4);
                cat.Level = (cat.Health + cat.Mood + cat.Satiety) / 3;
                allCatsNew.Add(cat);
            }
            FileManager.SaveAll(allCatsNew);
        }

        public static void ActionCat(string action, int actionIndex)
        {
            string nameCat = UserInput.InputString("Введите имя кота");

            List<Cat> allCats = FileManager.ReadAll();
            bool findCat = false;
            foreach (Cat cat in allCats)
            {
                if (cat.Name.Contains(nameCat))
                {
                    Console.WriteLine($"{action} {nameCat}");
                    switch (actionIndex)
                    {
                        case 1:
                            if (cat.Age <= 5)
                            {
                                cat.Satiety += 7;
                                cat.Mood += 7;
                            }
                            else if (cat.Age >= 6 && cat.Age <= 10)
                            {
                                cat.Satiety += 5;
                                cat.Mood += 5;
                            }
                            else
                            {
                                cat.Satiety += 4;
                                cat.Mood += 4;
                            }
                            break;
                        case 2:
                            if (cat.Age <= 5)
                            {
                                cat.Satiety -= 3;
                                cat.Mood += 7;
                                cat.Health += 7;
                            }
                            else if (cat.Age >= 6 && cat.Age <= 10)
                            {
                                cat.Satiety -= 5;
                                cat.Mood += 5;
                                cat.Health += 5;
                            }
                            else
                            {
                                cat.Satiety -= 6;
                                cat.Mood += 4;
                                cat.Health += 4;
                            }
                            break;
                        case 3:
                            if (cat.Age <= 5)
                            {
                                cat.Satiety -= 3;
                                cat.Mood -= 3;
                                cat.Health += 7;
                            }
                            else if (cat.Age >= 6 && cat.Age <= 10)
                            {
                                cat.Satiety -= 5;
                                cat.Mood -= 5;
                                cat.Health += 5;
                            }
                            else
                            {
                                cat.Satiety -= 6;
                                cat.Mood -= 6;
                                cat.Health += 4;
                            }
                            break;
                        default:
                            break;
                    }
                    findCat = true;
                    cat.Level = (cat.Health + cat.Mood + cat.Satiety) / 3;
                }
                FileManager.SaveAll(allCats);
            }


            if (!findCat)
            {
                Console.WriteLine("Нет такого кота");

            }

            Console.ReadKey(true);

        }
        public static Cat InputData()
        {
            Cat cat = new Cat();
            cat.Name = UserInput.InputString("\tВведи Имя");
            cat.Age = UserInput.InputInteger("\tВведи возраст");
            Random random = new Random();
            cat.Health = random.Next(20, 81);
            cat.Mood = random.Next(20, 81);
            cat.Satiety = random.Next(20, 81);
            cat.Level = (cat.Health + cat.Mood + cat.Satiety) / 3;
            return cat;
        }
    }
}
