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
        public static string[] spitter(string[] ar)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u','A','E','I','O','U' };
            int j;
            string[] final = new string[ar.Length];
            for (int i = 0; i < ar.Length; i++)
            {
                j = 0;
                if (Regex.IsMatch(ar[i], @"^.*[@0-9<>/()*&^%$#@.!;,.].*$"))
                {
                    final[i] = ar[i];
                    continue;
                }
                if (char.IsPunctuation(ar[i][ar[i].Length - 1]))
                {
                    if (vowels.Contains(ar[i][0]))
                        final[i] = ar[i].Substring(0, ar[i].Length - 1)+ ""+ "way"+ ar[i][ar[i].Length - 1].ToString();
                    else
                    {
                        j = ar[i].IndexOf(ar[i].First(a => vowels.Contains(a)));
                        final[i] = ar[i].Substring(j, ar[i].Length - j-1)+ ar[i].Substring(0,j)+ "ay"+ ar[i][ar[i].Length - 1].ToString();
                    }
                }
                else
                    if (vowels.Contains(ar[i][0]))
                        final[i] = ar[i].Substring(0, ar[i].Length)+ ""+ "way"+ "";
                    else
                    {
                        j = ar[i].IndexOf(ar[i].First(a => vowels.Contains(a)));
                        final[i] = ar[i].Substring(j, ar[i].Length - j)+ ar[i].Substring(0,j)+ "ay"+"";
                    }
            }
            return final;
        }

        static void Main(string[] args)
        {
            string str = "", choice = "";
            string[] ar, final;
            while (true)
            {
                Console.WriteLine("ENTER A STRING: ");
                ar = Console.ReadLine().Split(' ');
                final = spitter(ar);
                for (int i = 0; i < final.Length; i++)
                {
                    if (Regex.IsMatch(final[i], @"^.*[A-Z].*$"))
                        final[i] = char.ToUpper(final[i][0]) + final[i].Substring(1, final[i].Length - 1).ToLower();
                }
                Console.WriteLine(string.Join(" ", final));
            Ask:
                Console.Write("\nAgain (y/n)?: ");
                choice = Console.ReadLine();
                if (choice == "Y" || choice == "y")
                    continue;
                else if (choice == "n" || choice == "N")
                    break;
                else
                    goto Ask;
            }
        }
    }
}