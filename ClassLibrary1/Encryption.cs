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
            char[] charTable = plainText.ToCharArray();
            char[,] normalTable = new char[n, m];
            char[,] encryptTable = new char[n + m - 1, n];

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

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    encryptTable[i, j] = normalTable[i, j];
                }
            }
        }
    }
}
