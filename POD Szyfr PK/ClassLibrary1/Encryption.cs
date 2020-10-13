using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class Encryption
    {
        static public void Encrypt(string keyWord, string plainText)
        {
            int k = 0;
            int n = keyWord.Length;
            int m = plainText.Length / n + 1;
            Console.WriteLine("n: " + n + "| m: " + m);
            int[] valueKeyTable = new int[n];
            char[] charTable = plainText.ToCharArray();
            char[] keyTable = keyWord.ToCharArray();
            char[] abcTable = new char[26];
            char[,] normalTable = new char[n, m];
            char[,] encryptTable = new char[n, n + m - 1];
            //===============================
            //INDEKSOWANIE SŁOWA KLUCZ
            int index = 0;
            for (char letter = 'a'; letter <= 'z'; letter++)
            {
                abcTable[index++] = letter;
            }
            Console.WriteLine();

            var abcKeyList = new Dictionary<int, char>();

            Array.Sort(keyTable);

            int dex = 1;
            foreach (var element in keyTable)
            {
                abcKeyList.Add(dex++, element);
            }

            foreach (var element in abcKeyList)
            {
                Console.WriteLine($"Number in alphabet: {element.Key}, char: {element.Value} ");
            }

            //===============================
            //WPISYWANIE TEKSTU JAWNEGO DO MACIERZY
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (k >= charTable.Length)
                        normalTable[i, j] = 'x';
                    else
                        normalTable[i, j] = charTable[k];
                    k++;
                }
            }

            //WYŚWIETLANIE TEKSTU JAWNEGO Z MACIERZY
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (normalTable[i, j] == ' ')
                        Console.Write(" _ ");
                    else
                        Console.Write($" {normalTable[i, j]} ");
                }
                Console.WriteLine();
            }

            //PRZEPISYWANIE MACIERZY WZDLUZ SZEROKOSCI I DLUGOSCI DO LISTY
            var shifted = new List<char>();
            int lastMaxColumn = n - 1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j == lastMaxColumn)
                    {
                        for (int l = i; l < m; l++)
                        {
                            shifted.Add(normalTable[l, j]);
                        }

                        lastMaxColumn--;
                        break;
                    }

                    shifted.Add(normalTable[i, j]);
                }
            }
            Console.WriteLine(string.Join(" ", shifted.ToArray()));

            //WPISYWANIE LISTY W KSZTALT PIRAMIDY DO MACIERZY
            int shiftInt = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n + m - 1; j++)
                {
                    if (j >= i && j <= n + m - 2 - i)
                    {
                        encryptTable[i, j] = shifted[shiftInt];
                        shiftInt++;
                    }
                }
            }

            //SPISYWANIE KOLUMN W ODPOWIEDNIEJ KOLEJNOSCI DO TABLICY WYNIKOWEJ (OTRZYMYWANIE SZYFROGRAMU)
            var result = "";
            var keyWordRemoveTable = keyWord.ToCharArray();

            for (int letter = 0; letter < keyTable.Length; letter++)
            {
                var encIndex = Array.IndexOf(keyWordRemoveTable, keyTable[letter]);
                keyWordRemoveTable[encIndex] = '?';

                while (encIndex < n + m - 1)
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (encryptTable[i, encIndex] == 0) break;

                        result += encryptTable[i, encIndex];
                    }

                    encIndex += n;
                }
            }
            Console.Write("Szyfrogram: ");
            Console.WriteLine(result);
        }
    }
}
