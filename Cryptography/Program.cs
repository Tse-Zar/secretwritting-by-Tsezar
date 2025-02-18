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
                    Console.Write("Encrypt/Decrypt (E/D) --> ");
                    string? input = Console.ReadLine();
                    if (input == "E")
                    {
                        Console.Write("Accepted, please select an encrypting algorithm from those available (С) --> ");
                        input = Console.ReadLine();

                        switch (input)
                        {
                            case "C":
                                Console.Write("Good choice! Now decide on the step size (whole number) --> ");
                                int step = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Enter text to encrypt --> ");
                                input = Console.ReadLine();

                                Console.WriteLine("Accepted, wait for the result...");
                                if (input != null)
                                    crypto = new(input, step);

                                crypto.CezarCrypt();

                                break;
                        }
                    }
                    else if (input == "D")
                    {
                        Console.Write("Accepted, please select an decrypting algorithm from those available (С) --> ");
                        input = Console.ReadLine();

                        switch (input)
                        {
                            case "C":
                                Console.Write("Good choice! Now decide on the step size (whole number, 0 - brute force method) --> ");
                                int step = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Enter text to decrypt --> ");
                                input = Console.ReadLine();

                                Console.WriteLine("Accepted, wait for the result...");
                                if (input != null)
                                    crypto = new(input, step);

                                crypto.CezarDecrypt();

                                break;
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
    }
}
