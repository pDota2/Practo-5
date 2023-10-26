using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practo_5
{
    class MainMenu
    {
        public string[] Options { get; } = {
        "Форма",
        "Размер",
        "Вкус",
        "Количество",
        "Глазурь",
        "Декор",
        "Оформить заказ",
        "История заказов"
        };
        public int SelectedOption { get; set; } = 0;
        public int ShowMenu()
        {
            int selectedIndex = SelectedOption;
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Выберите параметры торта:"); // сосискъъъа
                Console.ResetColor();
                for (int i = 0; i < Options.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("->");
                        Console.ResetColor();
                    }
                    Console.WriteLine(Options[i]);
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex + 1) % Options.Length;
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex - 1 + Options.Length) % Options.Length;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    return selectedIndex;
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
            }
        }
        public string GetSelectedSubMenuOption()
        {
            switch (SelectedOption)
            {
                case 0:
                    return ShowSubMenu(new[] { "Круг - Цена: 400", "Квадрат - Цена: 500", "Прямоугольник - Цена: 600" });
                case 1:
                    return ShowSubMenu(new[] { "Маленький - Цена: 1000", "Средний - Цена: 1500", "Большой - Цена: 2000" });
                case 2:
                    return ShowSubMenu(new[] { "Ванильный - Цена: 100", "Шоколадный - Цена: 200", "Кокосовый - Цена: 400" });
                case 3:
                    return ShowSubMenu(new[] { "1 корж - Цена: 200", "2 коржа - Цена: 350", "3 коржа - Цена: 500", "4 коржа - Цена: 650" });
                case 4:
                    return ShowSubMenu(new[] { "Шоколад - Цена: 200", "Крем - Цена: 300", "Бизе - Цена: 400" });
                case 5:
                    return ShowSubMenu(new[] { "Классический - Цена: 500", "Праздничный - Цена: 1000" });
                default:
                    return "";
            }
        }
        private string ShowSubMenu(string[] subMenuOptions)
        {
            int selectedIndex = 0;
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < subMenuOptions.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("->");
                        Console.ResetColor();
                    }
                    Console.WriteLine(subMenuOptions[i]);
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex + 1) % subMenuOptions.Length;
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex - 1 + subMenuOptions.Length) % subMenuOptions.Length;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    return subMenuOptions[selectedIndex];
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
