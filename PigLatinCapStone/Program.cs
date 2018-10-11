using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PigLatinCapStone
{
    class Program
    {
        public static string spitter(string old)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u',};
            char temp1 = ' ';
            string[] ar = old.Split(' ');
            for(int i = 0; i < ar.Length; i++)
            {
                if (Regex.IsMatch(ar[i], @"^[A-Za-z]*@[a-zA-Z]*\.[a-zA-Z]*$") || Regex.IsMatch(ar[i], @"\d+"))
                {
                    Console.WriteLine(ar[i]);
                    continue;
                }
                if (vowels.Contains(ar[i][0]))
                {
                    if (char.IsPunctuation(ar[i][ar[i].Length-1]))
                    {
                        temp1 = ar[i][ar[i].Length - 1];
                        ar[i] = ar[i].Substring(0, ar[i].Length-1);
                        ar[i] += "way" + temp1;
                    }
                    else
                    {
                        ar[i] = ar[i].Substring(0, ar[i].Length);
                        ar[i] += "way";
                    }
                }
                else
                {
                    if (char.IsPunctuation(ar[i][ar[i].Length - 1]))
                    {
                        temp1 = ar[i][ar[i].Length - 1];
                        ar[i] = ar[i].Substring(1, ar[i].Length-2)+ar[i][0];
                        ar[i] += "ay" + temp1;
                    }
                    else
                    {
                        ar[i] = ar[i].Substring(1, ar[i].Length - 1) + ar[i][0];
                        ar[i] += "ay";
                    }
                }
            }

            return string.Join(" ", ar);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("ENTER A STRING: ");                      //remove 'Line'
            string str = Console.ReadLine().ToLower();
            Console.WriteLine(spitter(str));
        }
    }
}
