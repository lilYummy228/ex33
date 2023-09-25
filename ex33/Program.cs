using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex33
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int CommandAddCustomer = 1;
            const int CommandCalculateCustomer = 2;
            const int CommandExit = 3;

            bool isOpen = true;
            int shopBank = 0;
            Queue<string> customers = new Queue<string>();

            while (isOpen)
            {
                Console.SetCursorPosition(40, 0);
                Console.WriteLine($"Сумма в кассе: {shopBank} $");
                Console.SetCursorPosition(0, 0);
                Console.Write("1 - Добавить покупателя\n2 - Рассчитать покупателя\n3 - Выход из программы\nВыберите операцию: ");
                int chosenOperation = Convert.ToInt32(Console.ReadLine());

                switch (chosenOperation)
                {
                    case CommandAddCustomer:
                        AddCustomers(customers);
                        break;

                    case CommandCalculateCustomer:
                        shopBank = CalculateCustomer(customers, shopBank);
                        break;

                    case CommandExit:
                        isOpen = false;
                        break;

                    default:
                        Console.WriteLine("Неверная команда...");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        static void AddCustomers(Queue<string> customers)
        {
            Console.Write("Введите имя покупателя: ");
            string name = Console.ReadLine();
            customers.Enqueue(name);
            Console.WriteLine($"{name} успешно добавлен в очередь...");
        }

        static int CalculateCustomer(Queue<string> customers, int shopBank)
        {
            if (customers.Count > 0)
            {
                Random random = new Random();
                int purchaseAmount = random.Next(1, 1001);
                Console.WriteLine($"Покупатель {customers.Dequeue()}. Сумма покупки составила {purchaseAmount} $");
                shopBank += purchaseAmount;
            }
            else
            {
                Console.WriteLine("Список покупателей пуст");
            }

            return shopBank;
        }
    }
}
