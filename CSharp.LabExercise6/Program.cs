using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CSharp.LabExercise6a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**********SCRABBLE**********\n");

            var answer = "y";
            while (answer.Trim().ToLower().Equals("y"))
            {
                Console.Write("Enter Word: ");
                string Input = Console.ReadLine().ToUpper();

                if (Input.Length < 1 || string.IsNullOrWhiteSpace(Input) || Int32.TryParse(Input, out var outParse)
                    || Regex.IsMatch(Input, @"[^A-Za-z0-9 ]") || Input.Contains(" ") || Input.Any(c => char.IsDigit(c)))

                {
                    Console.WriteLine("Invalid Word!");
                }
                else
                {
                    Console.Clear();
                    var userInput = new ValuePairsDictionary();
                    Console.WriteLine("Your word: {0}", Input);
                    Console.WriteLine("Score: {0}\n", userInput.Score(Input));

                    Console.WriteLine("===============================");

                    Console.Write("Do you want to continue(y/n)? ");
                    answer = Console.ReadLine();
                }
            }
        }
    }

    class ValuePairsDictionary
    {
        public int points { get; set; }
        public int score;

        Dictionary<char, int> keyValuePairs = new Dictionary<char, int>()
        {
            {'A', 1},
            {'E', 1},
            {'I', 1},
            {'O', 1},
            {'U', 1},
            {'L', 1},
            {'N', 1},
            {'R', 1},
            {'S', 1},
            {'T', 1},

            {'D', 2},
            {'G', 2},

            {'B', 3},
            {'C', 3},
            {'M', 3},
            {'P', 3},

            {'F', 4},
            {'H', 4},
            {'V', 4},
            {'W', 4},
            {'Y', 4},

            {'K', 5},

            {'J', 8},
            {'X', 8},

            {'Q', 10},
            {'Z', 10},
        };

        public int Score(string inputWord)
        {
            foreach (var letter in inputWord)
            {
                keyValuePairs.TryGetValue(letter, out score);
                points += score;
            }
            return points;
        }
    }
}