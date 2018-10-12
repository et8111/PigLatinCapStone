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
        public static string puncuationChecker(string str)
        {
            string temp = "";
            if (Regex.Match(str, "[.,!?]").Success)
            {
                temp = str[str.Length-1].ToString();
                return VowelSeparator(str.Substring(0, str.Length - 1),temp);
            }
            return VowelSeparator(str, temp);
        }

        public static string VowelSeparator(string str, string p)
        {
            int j = Regex.Match(str, "[aeiouAEIOU]").Index;
            string temp = (j == 0)?"way":"ay";
            return CapitalLetter(str.Substring(j, str.Length-j) +str.Substring(0,j)+ temp+ p);
        }

        public static string CapitalLetter(string str)
        {
            if (Regex.IsMatch(str, @"^.*[A-Z].*$"))
                str = char.ToUpper(str[0]) + str.Substring(1, str.Length - 1).ToLower();
            return str;
        }

        static void Main(string[] args)
        {
            string choice = "";
            string[] word;
            while (true)
            {
                Console.WriteLine("ENTER A STRING: ");
                word = Console.ReadLine().Split(' ');
                for (int i = 0; i < word.Length; i++) //puncuationChecker->vowelSeperator->CapitalLetter: back here
                    word[i] = puncuationChecker(word[i]);
                Console.WriteLine(string.Join(" ", word));
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

/*Original solution. Way messier then new one.
 * 

    

        public static string[] spitter(string[] ar)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u','A','E','I','O','U' };
            int j;
            string[] final = new string[ar.Length];
            for (int i = 0; i < ar.Length; i++)
            {//ALL 'final[i]=' formats are->(subarray: firstVowel-EndOrPuncuation, ConsenantsArray, Ending(WayOrAy), Puncuation(IfAny))
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
 */
