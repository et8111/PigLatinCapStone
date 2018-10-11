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
        public static string Worker(string substring,string firstPart, string ending, string punc)
        {
            return substring + firstPart + ending + punc;
        }

        public static string[] spitter(string[] ar)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u','A','E','I','O','U' };
            int j;
            for (int i = 0; i < ar.Length; i++)
            {
                j = 0;
                if (Regex.IsMatch(ar[i], @"^.*[@0-9<>/()*&^%$#@!].*$"))
                    continue;
                if (char.IsPunctuation(ar[i][ar[i].Length - 1]))
                {
                    if (vowels.Contains(ar[i][0]))
                        ar[i] = Worker(ar[i].Substring(0, ar[i].Length - 1), "", "way", ar[i][ar[i].Length - 1].ToString());
                    else
                    {
                        j = ar[i].IndexOf(ar[i].First(a => vowels.Contains(a)));
                        ar[i] = Worker(ar[i].Substring(j, ar[i].Length - j-1), ar[i].Substring(0,j), "ay", ar[i][ar[i].Length - 1].ToString());
                    }
                }
                else
                    if (vowels.Contains(ar[i][0]))
                        ar[i] = Worker(ar[i].Substring(0, ar[i].Length), "", "way", "");
                    else
                    {
                        j = ar[i].IndexOf(ar[i].First(a => vowels.Contains(a)));
                        ar[i] = Worker(ar[i].Substring(j, ar[i].Length - j), ar[i].Substring(0,j), "ay", "");
                    }
            }
            return ar;
        }

        static void Main(string[] args)
        {
            string str = "", choice = "";
            string[] ar;
            while (true)
            {
                Console.WriteLine("ENTER A STRING: ");
                str = Console.ReadLine();
                ar = str.Split(' ');
                spitter(ar);
                for (int i = 0; i < ar.Length; i++)
                {
                    if (Regex.IsMatch(ar[i], @"^.*[A-Z].*$"))
                        ar[i] = char.ToUpper(ar[i][0]) + ar[i].Substring(1, ar[i].Length - 1).ToLower();
                }
                Console.WriteLine(string.Join(" ", ar));
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