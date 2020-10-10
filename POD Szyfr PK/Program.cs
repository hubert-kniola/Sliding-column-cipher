using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary1;

namespace POD_Szyfr_PK
{
    class Program
    { 
        static void Main(string[] args)
        {
            int x = default;
            string plainText = default, keyWord = default;
            Encryption enc = new Encryption();
            try
            {
                do
                {
                    Console.WriteLine("SZYFR PRZEKATNOKOLUMNOWY by Hubert Knioła");
                    Console.Write("0. Zakoncz dzialanie programu\n1. Szyfrowanie\n2. Deszyfrowanie\n");
                    Console.Write("Podaj odpowiedni numer: ");
                    x = Int32.Parse(Console.ReadLine());
                    switch (x)
                    {
                        case 0:
                            break;
                        case 1:
                            Console.WriteLine("Wybrano szyfrowanie!");
                            Console.WriteLine("Podaj tekst jawny, ktory chcesz zaszyfrowac: ");
                            plainText = Console.ReadLine();
                            Console.WriteLine("Podaj slowo klucz: ");
                            keyWord = Console.ReadLine();
                            Encryption.Encrypt(keyWord, plainText);

                            break;
                        case 2:
                            Console.WriteLine("Wybrano deszyfrowanie!");
                            Console.WriteLine("Podaj tekst, ktory chcesz odszyfrowac: ");
                            plainText = Console.ReadLine();
                            Console.WriteLine("Podaj slowo klucz: ");
                            keyWord = Console.ReadLine();

                            break;
                        default:
                            Console.WriteLine("Podano nieprawidłowy numer!");
                            continue;
                    }   
                } while (x != 0);    
            }
            catch(FormatException e)
            {
                Console.WriteLine("Znak nie jest typu INT");
            }
             Console.ReadKey();
        }
    }
}
