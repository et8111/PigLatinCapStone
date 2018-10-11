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
        public static string Worker(string substring,string firstLetter, string ending, string punc)
        {
            return substring + firstLetter + ending + punc;
        }

        public static string[] spitter(string[] ar)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            
            for (int i = 0; i < ar.Length; i++)
            {
                if (Regex.IsMatch(ar[i], @"^.*[@0-9<>/()*&^%$#@!].*$"))
                    continue;
                if (char.IsPunctuation(ar[i][ar[i].Length - 1]))
                {
                    if (vowels.Contains(ar[i][0]))
                        ar[i] = Worker(ar[i].Substring(0, ar[i].Length - 1), "", "way", ar[i][ar[i].Length - 1].ToString());
                    else
                        ar[i] = Worker(ar[i].Substring(1, ar[i].Length - 2), ar[i][0].ToString(), "ay", ar[i][ar[i].Length - 1].ToString());
                }
                else
                    if (vowels.Contains(ar[i][0]))
                        ar[i] = Worker(ar[i].Substring(0, ar[i].Length), "", "way", "");
                    else
                        ar[i] = Worker(ar[i].Substring(1, ar[i].Length - 1), ar[i][0].ToString(), "ay", "");

            }
            return ar;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("ENTER A STRING: ");
                string str = Console.ReadLine();
                string[] ar = str.Split(' ');
                spitter(ar);
                for (int i = 0; i < ar.Length; i++)
                {
                    if (Regex.IsMatch(ar[i], @"^.*[A-Z].*$"))
                        ar[i] = char.ToUpper(ar[i][0]) + ar[i].Substring(1, ar[i].Length - 1).ToLower();
                }
                Console.WriteLine(string.Join(" ", ar));
                Console.Write("\nPress 'y' to enter another line: ");
                if (Console.ReadLine() != "y")
                    break;
            }
        }
    }
}