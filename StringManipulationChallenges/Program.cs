using System;
using System.Collections.Generic;

namespace StringManipulationChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            // Reverse String
            Console.WriteLine("----- Reverse String -----");
            Console.Write("Enter a string: ");
            string reverseInput = Console.ReadLine() ?? "";
            Console.WriteLine("Reversed: " + ReverseString(reverseInput));

            // Count Vowels
            Console.WriteLine("\n----- Count Vowels -----");
            Console.Write("Enter a string: ");
            string vowelInput = Console.ReadLine() ?? "";
            Console.WriteLine("Vowel Count: " + CountVowels(vowelInput));

            // Anagram Check
            Console.WriteLine("\n----- Anagram Check -----");
            Console.Write("Enter first string: ");
            string first = Console.ReadLine() ?? "";

            Console.Write("Enter second string: ");
            string second = Console.ReadLine() ?? "";

            Console.WriteLine("Are Anagrams? " + IsAnagram(first, second));

            // Word Frequency
            Console.WriteLine("\n----- Word Frequency -----");
            Console.Write("Enter a sentence: ");
            string sentence = Console.ReadLine() ?? "";

            Dictionary<string, int> result = WordFrequency(sentence);

            Console.WriteLine("\nWord Frequencies:");
            foreach (var item in result)
            {
                Console.WriteLine(item.Key + " -> " + item.Value);
            }

            Console.ReadKey();
        }

        // 1. Reverse String (Without Reverse())
        static string ReverseString(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            string reversed = "";

            for (int i = s.Length - 1; i >= 0; i--)
            {
                reversed += s[i];
            }

            return reversed;
        }

        // 2. Count Vowels
        static int CountVowels(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            int count = 0;

            s = s.ToLower();

            foreach (char c in s)
            {
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                {
                    count++;
                }
            }

            return count;
        }

        // 3. Is Anagram
        static bool IsAnagram(string a, string b)
        {
            if (a == null || b == null)
                return false;

            a = a.Replace(" ", "").ToLower();
            b = b.Replace(" ", "").ToLower();

            if (a.Length != b.Length)
                return false;

            char[] arr1 = a.ToCharArray();
            char[] arr2 = b.ToCharArray();

            Array.Sort(arr1);
            Array.Sort(arr2);

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                    return false;
            }

            return true;
        }

        // 4. Word Frequency
        static Dictionary<string, int> WordFrequency(string sentence)
        {
            Dictionary<string, int> frequency = new Dictionary<string, int>();

            if (string.IsNullOrWhiteSpace(sentence))
                return frequency;

            string[] words = sentence.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (frequency.ContainsKey(word))
                {
                    frequency[word]++;
                }
                else
                {
                    frequency[word] = 1;
                }
            }

            return frequency;
        }
    }
}