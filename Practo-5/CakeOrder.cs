using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practo_5
{
    class CakeOrder
    {
        private List<string> selectedOptions = new List<string>();
        private decimal totalPrice = 0;


        private decimal CalculatePriceForOption(string option)
        {
            var priceIndex = option.LastIndexOf("Цена: ");
            if (priceIndex != -1)
            {
                var priceString = option.Substring(priceIndex + 6);
                if (decimal.TryParse(priceString, out decimal price))
                {
                    return price;
                }
            }
            return 0;
        }

        public void CompleteOrder()
        {
            Console.WriteLine("\nИтоговый заказ:");
            foreach (string option in selectedOptions)
            {
                Console.WriteLine(option);
                totalPrice += CalculatePriceForOption(option);
            }
            Console.WriteLine($"Суммарная цена: {totalPrice}");
            SaveOrder();
            selectedOptions.Clear();
            totalPrice = 0;
        }

        private void SaveOrder()
        {
            using (StreamWriter writer = File.AppendText("История заказов.txt"))
            {
                writer.WriteLine(string.Join(", ", selectedOptions));
            }
        }
        public void AddOption(string option)
        {
            Console.WriteLine($"Выбрано: {option}");
            selectedOptions.Add(option);
        }
    }
}
