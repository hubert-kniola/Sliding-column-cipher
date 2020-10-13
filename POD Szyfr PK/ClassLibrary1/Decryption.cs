using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class Decryption
    {
        static public void Decrypt(string keyWord, string encryptText)
        {

            int k = 2;
            int n = keyWord.Length;
            int m = encryptText.Replace("X", "").Length / n + 1; ;
            Console.WriteLine("n: " + n + "| m: " + m);
            int[] valueKeyTable = new int[n];
            char[] charTable = encryptText.ToCharArray();
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

            //================================

            int shiftInt = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n + m - 1; j++)
                {
                    if (j >= i && j <= n + m - 2 - i)
                    {
                        encryptTable[i, j] = 'X';
                        shiftInt++;
                    }
                }
            }


            int countSpaces = 0;
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
                        countSpaces++;
                        if (encryptTable[i, encIndex] == 0) break;

                        result += encryptTable[i, encIndex];
                        
                    }
                    Console.Write(countSpaces);
                    encIndex += n;
                }
                
            }
            Console.WriteLine();
            Console.Write("Szyfrogram: ");
            Console.WriteLine(result);

        }
    }
}
