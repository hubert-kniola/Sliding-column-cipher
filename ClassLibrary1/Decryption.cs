using System;
using System.Collections.Generic;
using System.IO;

namespace ClassLibrary1
{
    public class Decryption
    {
        public static void Decrypt(string key, string text)
        {
            var width = text.Replace("X", "").Length / key.Length + 1;

            var pyramid = new char[key.Length, key.Length + width - 1];

            var sortedKey = key.ToCharArray();
            var keyArray = key.ToCharArray();
            if (width * key.Length != text.Length) throw new IOException();

            Array.Sort(sortedKey);

            //WPISYWANIE 'X' W KSZTALT PIRAMIDY DO MACIERZY
            int shiftInt = 0;
            for (int i = 0; i < key.Length; i++)
            {
                for (int j = 0; j < key.Length + width - 1; j++)
                {
                    if (j >= i && j <= key.Length + width - 2 - i && i < width)
                    {
                        pyramid[i, j] = 'X';
                        shiftInt++;
                    }
                }
            }

            //WYŚWIETLANIE PIRAMIDY
            for (int i = 0; i < key.Length; i++)
            {
                for (int j = 0; j < key.Length + width - 1; j++)
                {
                    Console.Write($"{(pyramid[i, j] == 0 ? '-' : pyramid[i, j])} ");
                }

                Console.WriteLine();
            }

            //ZLICZANIE X ORAZ WPISYWANIE ODPOWIEDNIEJ LICZBY ZNAKOW DO KOLUMN
            var xSpaces = 0;
            var textIndex = 0;
            foreach (var c in sortedKey)
            {
                var index = Array.IndexOf(keyArray, c);
                keyArray[index] = '?';

                /*for (int i = 0; i < index + 1; i++)
                {
                    if (pyramid[i, index] == 'X')
                        pyramid[i, index] = text[textIndex++];
                }*/


                while (index < key.Length + width - 1)
                {

                    for (int i = 0; i < key.Length; i++)
                    {
                        if (pyramid[i, index] == 'X')
                        {
                            pyramid[i, index] = text[textIndex++];

                        }
                        else
                        {
                            break;
                        }
                    }
                    index += key.Length;
                }

            }

            //WYŚWIETLANIE PIRAMIDY
            for (int i = 0; i < key.Length; i++)
            {
                for (int j = 0; j < key.Length + width - 1; j++)
                {
                    Console.Write($"{(pyramid[i, j] == 0 ? '-' : pyramid[i, j])} ");
                }

                Console.WriteLine();
            }

            //WPISYWANIE PIRAMIDY DO LISTY
            var shifted = new List<char>();
            for (int i = 0; i < key.Length; i++)
            {
                for (int j = 0; j < key.Length + width - 1; j++)
                {
                    if (pyramid[i, j] != 0)
                    {
                        shifted.Add(pyramid[i, j]);
                    }
                }
            }
            Console.WriteLine(String.Join(" ", shifted));

            //WPISYWANIE LISTY W MACIERZ
            char[,] normalTable = new char[width, key.Length];
            int lastMaxColumn = key.Length - 1;
            var shiftIndex = 0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (j == lastMaxColumn)
                    {
                        for (int l = i; l < width; l++)
                        {
                            normalTable[l, j] = shifted[shiftIndex++];
                        }

                        lastMaxColumn--;
                        break;
                    }
                    if(shiftIndex < text.Length)
                    { 
                        normalTable[i, j] = shifted[shiftIndex++];
                    }
                    else
                    {
                        break;
                    }
                    

                }
            }

            //TWORZENIE TEKSTY JAWNEGO
            var plainText = "";
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (normalTable[i, j] == '_')
                    {
                        Console.Write(" _ ");
                        plainText += " ";
                    }
                    else
                    {
                        Console.Write($" {normalTable[i, j]} ");
                        plainText += normalTable[i, j];
                    }

                }
                Console.WriteLine();
            }

            var howMany = text.Length - text.Replace("X", "").Length;
            plainText = plainText.Remove(plainText.Length - howMany);;
            Console.WriteLine($"Tekst jawny: {plainText}");

            //ZAPISYWANIE DO PLIKU
            string[] lines = { plainText, key };

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "decryptionResult.txt")))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }
        }
    }
}