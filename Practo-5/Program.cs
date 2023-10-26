using System;
using System.Collections.Generic;
using System.IO;
using Practo_5;

class Program
{
    static void Main()
    {
        Console.CursorVisible = false;
        var order = new CakeOrder();
        var menu = new MainMenu();
        while (true)
        {
            Console.Clear();
            int selectedOptionIndex = menu.ShowMenu();
            if (selectedOptionIndex == menu.Options.Length - 2)
            {
                order.CompleteOrder();
                Console.WriteLine("\nЗаказ оформлен. Нажмите Enter для продолжения.");
                Console.ReadLine();
            }
            else if (selectedOptionIndex == menu.Options.Length - 1)
            {
                DisplayOrderHistory();
                Console.WriteLine("Нажмите Enter для продолжения.");
                Console.ReadLine();
            }
            else
            {
                menu.SelectedOption = selectedOptionIndex;
                order.AddOption(menu.GetSelectedSubMenuOption());
            }
        }
    }

    static void DisplayOrderHistory()
    {
            string[] orders = File.ReadAllLines("История заказов.txt");
            Console.WriteLine("История заказов:");
            foreach (string order in orders)
            {
                Console.WriteLine(order);
            }
    }
}
