//made by Tsezar
//сделано Цезарем

namespace Cryptography
{
    internal class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("╔════╗╔══╗╔═══╗╔═══╗╔══╗╔═══╗╔══╗───╔══╗╔═══╗╔╗╔╗╔═══╗╔════╗╔══╗\n" +
                              "╚═╗╔═╝║╔═╝║╔══╝╚═╗─║║╔╗║║╔═╗║║╔═╝───║╔═╝║╔═╗║║║║║║╔═╗║╚═╗╔═╝║╔╗║\n" +
                              "──║║──║╚═╗║╚══╗─╔╝╔╝║╚╝║║╚═╝║║╚═╗───║║──║╚═╝║║╚╝║║╚═╝║──║║──║║║║\n" +
                              "──║║──╚═╗║║╔══╝╔╝╔╝─║╔╗║║╔╗╔╝╚═╗║───║║──║╔╗╔╝╚═╗║║╔══╝──║║──║║║║\n" +
                              "──║║──╔═╝║║╚══╗║─╚═╗║║║║║║║║─╔═╝║───║╚═╗║║║║──╔╝║║║─────║║──║╚╝║\n" +
                              "──╚╝──╚══╝╚═══╝╚═══╝╚╝╚╝╚╝╚╝─╚══╝───╚══╝╚╝╚╝──╚═╝╚╝─────╚╝──╚══╝");
            Console.ForegroundColor = ConsoleColor.Blue;

            try
            {
                CesarCrypto crypto = new("");
                while (true)
                {
                    Console.Write("Кодирование/Декодирование (C/E) --> ");
                    string? input = Console.ReadLine();
                    if (input == "C")
                    {
                        Console.Write("Хорошо, выберете режим шифрования из доступных (С/0) --> ");
                        input = Console.ReadLine();

                        switch (input)
                        {
                            case "C":
                                Console.Write("Хороший выбор! Выберет размер шага (целое число) --> ");
                                int step = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Введите текст для шифрования или укажите путь к файлу с текстом --> ");
                                input = Console.ReadLine();

                                Console.WriteLine("Принято! Ждите результат...");
                                if (input != null)
                                    crypto = new(input, step);

                                crypto.CezarCrypt();

                                break;
                            case "0":
                                ConfirmationExit();
                                continue;
                        }
                    }
                    else if (input == "E")
                    {
                        Console.Write("Хорошо, выберете режим дешифрования из доступных (С/0) --> ");
                        input = Console.ReadLine();

                        switch (input)
                        {
                            case "C":
                                Console.Write("Хороший выбор! Выберет размер шага (целое число, 0 - перебор всех вариантов) --> ");
                                int step = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Введите текст для дешифрования или укажите путь к файлу с текстом --> ");
                                input = Console.ReadLine();

                                Console.WriteLine("Принято! Ждите результат...");
                                if (input != null)
                                    crypto = new(input, step);

                                crypto.CezarEncrypt();

                                break;
                            case "0":
                                ConfirmationExit();
                                continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        public static void ConfirmationExit()
        {
            Console.Write("Вы действительно хотите выйти из программы? (Д/н)    ");
            string? c = Console.ReadLine();
            Console.WriteLine("Принято...");
            if (c == "н")
            {
                return;
            }
            else if (c == "Д")
            {
                Environment.Exit(0);
            }
        }
    }
}
