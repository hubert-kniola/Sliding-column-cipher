using System;
using System.Collections.Generic;
using System.IO;
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
            string plainText = default, keyWord = default, fileName = default, encryptText = default;
            Encryption enc = new Encryption();
            Decryption dec = new Decryption();

            do
            {
                try
                {
                    Console.WriteLine("=========================================");
                    Console.WriteLine("SZYFR PRZEKATNOKOLUMNOWY");
                    Console.Write("0. Zakoncz dzialanie programu\n1. Szyfrowanie\n2. Deszyfrowanie\n3. Szyfrowanie z pliku\n4. Deszyfrowanie z pliku\n");
                    Console.Write("Podaj odpowiedni numer: ");
                    x = Int32.Parse(Console.ReadLine());
                    switch (x)
                    {
                        case 0:
                            break;
                        case 1:
                            Console.WriteLine("Wybrano szyfrowanie!");
                            Console.Write("Podaj tekst jawny, ktory chcesz zaszyfrowac: ");
                            plainText = Console.ReadLine();
                            Console.Write("Podaj slowo klucz: ");
                            keyWord = Console.ReadLine();
                            Encryption.Encrypt(keyWord, plainText);
                            break;
                        case 2:
                            Console.WriteLine("Wybrano deszyfrowanie!");
                            Console.Write("Podaj tekst, ktory chcesz odszyfrowac: ");
                            encryptText = Console.ReadLine();
                            Console.Write("Podaj slowo klucz: ");
                            keyWord = Console.ReadLine();
                            Decryption.Decrypt(keyWord, encryptText);
                            break;
                        case 3:
                            Console.WriteLine("Wybrano szyfrowanie z pliku!");
                            Console.WriteLine("Proponowane pliki");
                            string[] efiles = Directory.GetFiles(@"C:\Users\Dell\Desktop\Sliding-column-cipher", "*.txt");
                            foreach(var element in efiles)
                            {
                                Console.WriteLine(element);
                            }
                            Console.Write("Podaj nazwę pliku: ");
                            fileName = Console.ReadLine();
                            StreamReader ereader = new StreamReader(@"C:\Users\Dell\Desktop\Sliding-column-cipher" + fileName + ".txt");
                            {
                                plainText = ereader.ReadLine();
                                keyWord = ereader.ReadLine();
                            }
                            Console.WriteLine($"Tekst jawny: {plainText}");
                            Console.WriteLine($"Slowo klucz: {keyWord}");
                            Encryption.Encrypt(keyWord, plainText);
                            break;
                        case 4:
                            Console.WriteLine("Wybrano deszyfrowanie z pliku!");
                            Console.WriteLine("Proponowane pliki");
                            string[] sfiles = Directory.GetFiles(@"C:\Users\Dell\Desktop\Sliding-column-cipher", "*.txt");
                            foreach (var element in sfiles)
                            {
                                Console.WriteLine(element);
                            }
                            Console.Write("Podaj nazwę pliku: ");
                            fileName = Console.ReadLine();
                            StreamReader dreader = new StreamReader(@"C:\Users\Dell\Desktop\Sliding-column-cipher" + fileName + ".txt");
                            {
                                encryptText = dreader.ReadLine();
                                keyWord = dreader.ReadLine();
                            }
                            Console.WriteLine($"Tekst zaszyfrowany: {encryptText}");
                            Console.WriteLine($"Slowo klucz: {keyWord}");
                            Decryption.Decrypt(keyWord, encryptText);
                            break;
                        default:
                            Console.WriteLine("Podano nieprawidłowy numer!");
                            continue;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Znak nie jest typu INT");
                    x = default;
                }catch(FileNotFoundException e)
                {
                    Console.WriteLine("Podana nazwa pliku nie istnieje");
                }
            } while (x != 0);
            Console.ReadKey();
        }
    }
}
