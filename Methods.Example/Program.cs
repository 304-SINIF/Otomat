using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods.Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] productNames = {
                "Kola", "Çikolata", "Bisküvi"
            };
            double[] productPrices = {
                9.5, 2.7, 6.5
            };

            double wallet = 25.5;
            double sum = 0;

            string[] boughtProducts = new string[0];

            while (true)
            {
                Console.WriteLine("1- Kola\n2- Çikolata\n3- Bisküvi\n(Çıkmak için -1)");
                string input = Console.ReadLine();
                bool isParsableInput = int.TryParse(input, out int selection);

                // selection > 3 || selection == 0 || selection < -1
                if (!isParsableInput || !((selection > 0 && selection < 4) || selection == -1))
                {
                    Console.Clear();
                    Console.WriteLine("Lütfen ürün seçmek için yalnızca 1, 2 ya da 3 giriniz. Çıkmak istiyorsanız -1 giriniz.");
                    continue;
                }

                if (selection == -1)
                {
                    Console.Clear();
                    Console.WriteLine("Teşekkürler");
                    Console.ReadKey();
                    break;
                }

                string product = productNames[selection - 1];
                double price = productPrices[selection - 1];

                if (wallet < price)
                {
                    Console.Clear();
                    Console.WriteLine("Bakiye yetersiz");
                    continue;
                }

                wallet -= price;
                sum += price;

                Console.Clear();
                Console.WriteLine("Bakiye: {0}\nToplam: {1}", wallet, sum);

                string[] temp = new string[boughtProducts.Length + 1];
                for (int i = 0; i < boughtProducts.Length; i++)
                {
                    temp[i] = boughtProducts[i];
                }

                temp[temp.Length - 1] = product;
                boughtProducts = temp;
            }

            Console.Clear();
            for (int i = 0; i < boughtProducts.Length; i++)
            {
                Console.WriteLine(boughtProducts[i]);
            }

            Console.ReadKey();
        }
    }
}
