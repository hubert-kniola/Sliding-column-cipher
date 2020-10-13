using System;

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

            Array.Sort(sortedKey);

            /*var textIndex = 0;
            foreach (var c in sortedKey)
            {
                var index = Array.IndexOf(keyArray, c);
                keyArray[index] = '?';



                for (int i = 0; i < index + 1; i++)
                {
                    pyramid[i, index] = text[textIndex++];
                }

                var mirrorIndex = index + key.Length;

                for (int i = 0; i < mirrorIndex - index; i++)
                {

                }
            }*/

            //WPISYWANIE 'X' W KSZTALT PIRAMIDY DO MACIERZY
            int shiftInt = 0;
            for (int i = 0; i < key.Length; i++)
            {
                for (int j = 0; j < key.Length + width - 1; j++)
                {
                    if (j >= i && j <= key.Length + width - 2 - i)
                    {
                        pyramid[i, j] = 'X';
                        shiftInt++;
                    }
                }
            }

            //WYPISYWANIE PIRAMIDY
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

                for (int i = 0; i < index + 1; i++)
                {
                    if (pyramid[i, index] == 'X')
                        pyramid[i, index] = text[textIndex++];
                }

                var mirrorIndex = index + key.Length;
                for (int i = 0; i < mirrorIndex + 1; i++)
                {
                    if (mirrorIndex <= key.Length + width - 1 && pyramid[i, mirrorIndex] == 'X')
                    {
                        pyramid[i, mirrorIndex] = text[textIndex++];
                        
                    }
                    else
                    {
                        break;
                    }
                }
            }

            //WYPISYWANIE PIRAMIDY
            for (int i = 0; i < key.Length; i++)
            {
                for (int j = 0; j < key.Length + width - 1; j++)
                {
                    Console.Write($"{(pyramid[i, j] == 0 ? '-' : pyramid[i, j])} ");
                }

                Console.WriteLine();
            }

        }
    }
}