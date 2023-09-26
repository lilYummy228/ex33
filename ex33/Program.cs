using System;
using System.Collections.Generic;

namespace ex33
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddCustomer = "1";
            const string CommandCalculateCustomer = "2";
            const string CommandExit = "3";

            int shopBank = 0;
            bool isOpen = true;

            Queue<int> customers = new Queue<int>();

            while (isOpen)
            {
                Console.SetCursorPosition(0, 15);

                foreach (var customerPurchaseAmount in customers)
                {
                    Console.WriteLine($"Сумма, ожидающая расчета: {customerPurchaseAmount}$");
                }

                Console.SetCursorPosition(70, 0);
                Console.WriteLine($"Сумма в кассе: {shopBank} $");
                Console.SetCursorPosition(0, 0);
                Console.Write($"{CommandAddCustomer} - Добавить покупателя\n{CommandCalculateCustomer} - Рассчитать всех покупателей\n" +
                    $"{CommandExit} - Выход из программы\nВыберите операцию: ");
                string chosenOperation = (Console.ReadLine());

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

                Console.Clear();
            }
        }

        static void AddCustomers(Queue<int> customers)
        {
            int minPurchaseAmount = 10;
            int maxPurchaseAmount = 101;
            Random random = new Random();
            int purchaseAmount = random.Next(minPurchaseAmount, maxPurchaseAmount);
            customers.Enqueue(purchaseAmount);
            Console.Write($"Клиент с суммой покупок в {purchaseAmount}$ добавлен в очередь...");
            Console.ReadKey();
        }

        static int CalculateCustomer(Queue<int> customerPurchaseAmount, int shopBank)
        {
            if (customerPurchaseAmount.Count > 0)
            {
                for (int i = 0; i < customerPurchaseAmount.Count;)
                {
                    Console.Clear();
                    shopBank += customerPurchaseAmount.Peek();
                    Console.WriteLine($"Сумма покупок составила {customerPurchaseAmount.Dequeue()}$\nОбщий банк составил: {shopBank}$");
                    Console.Write("Нажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Очередь пуста...");
                Console.ReadKey();
            }

            return shopBank;
        }
    }
}