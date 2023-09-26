using System;
using System.Collections.Generic;

namespace ex33
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandCalculateCustomer = "1";
            const string CommandExit = "2";

            int shopBank = 0;
            int customersCount = 5;
            bool isOpen = true;

            Queue<int> customers = new Queue<int>();
            Random random = new Random();

            for (int i = 0; i < customersCount; i++)
            {
                customers.Enqueue(random.Next(10, 101));
            }

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
                Console.Write($"{CommandCalculateCustomer} - Рассчитать всех покупателей\n" +
                    $"{CommandExit} - Выход из программы\nВыберите операцию: ");
                string chosenOperation = (Console.ReadLine());

                switch (chosenOperation)
                {
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

        static int CalculateCustomer(Queue<int> customerPurchaseAmount, int shopBank)
        {
            if (customerPurchaseAmount.Count > 0)
            {
                while (customerPurchaseAmount.Count > 0)
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