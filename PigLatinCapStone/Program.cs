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
        {//if theres puncuation send it to VOwelSeparator, if not send an empty string
            if (Regex.Match(str, @"[0-9@#$%&*()<>,+=\:;].").Success)
                return str;
            string temp = "";
            if (Regex.Match(str, @"[.,!?:;]").Success)
            {
                temp = str.Last().ToString();
                return VowelSeparator(str.Substring(0, str.Length - 1),temp);
            }
            return VowelSeparator(str, temp);
        }

        private static string VowelSeparator(string str, string p)
        {//j indexes first vowel. add 2 substrings plus pigLatin ending and punctuation if one exist sent to capitalLetter.
            int j = Regex.Match(str, "[aeiouAEIOU]").Index;
            string temp = (j == 0)?"way":"ay";
            return CapitalLetter(str.Substring(j, str.Length-j) +str.Substring(0,j)+ temp+ p);
        }

        private static string CapitalLetter(string str)
        {//This function assumes if there is a capital letter its supposed to be the first one.
            if (Regex.IsMatch(str, @"^.*[A-Z].*$"))
                str = char.ToUpper(str[0]) + str.Substring(1, str.Length - 1).ToLower();
            return str;
        }

        static void Main(string[] args)
        {
            string choice = "";
            string[] word, final;
            while (true)
            {
                Console.WriteLine("ENTER A STRING: ");
                word = Console.ReadLine().Split(' ');
                final = new string[word.Length];
                for (int i = 0; i < word.Length; i++)
                    final[i] = puncuationChecker(word[i]); //puncuationChecker->vowelSeperator->CapitalLetter: back here
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