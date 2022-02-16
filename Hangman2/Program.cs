using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman2
{
    class Program
    {
        static string correctWord = "jesus";
        static char[] letters;
        static string name;
        static int numberOfGuesses;
        

        static void Main(string[] args)
        {
            StartGame();
            PlayGame();
            EndGame();
        }

        private static void StartGame()
        {
            letters = new char[correctWord.Length];

            for (int i = 0; i < correctWord.Length; i++)
                letters[i] = '-';
            
            AskForUsersName();
        }

        static void AskForUsersName()
        {
            Console.WriteLine("Enter your name");

           string input = Console.ReadLine();
            
            if (input.Length >= 2)
                name = input;    
            else
            {
                //the user entered an invalid name
                AskForUsersName();
            }
        }

        private static void PlayGame()
        {
            do
            {
                Console.Clear();
                DisplayMaskedWord();
                char guessedLetter = AskForLetter();
                CheckLetter(guessedLetter);

            } while (correctWord != new string(letters));

            Console.Clear(); 
        }

        private static void CheckLetter(char guessedLetter)
        {
            for (int i = 0; i < correctWord.Length; i++)
            {
                if (guessedLetter == correctWord[i])
                {
                    letters[i] = guessedLetter;
                }
            }
        }

        static void DisplayMaskedWord()
        {
            foreach (char c in letters)
                Console.Write(c);
            
            Console.WriteLine();
            
        }

        static char AskForLetter()
        {
            string input;
            do
            {
                Console.WriteLine("Enter a letter!");
                input = Console.ReadLine();
            } while (input.Length != 1);


            //for (int i = 0; i < correctWord.Length; i++)
            //{
            //    Console.WriteLine("Guess the right letter!");
            //    input = Console.ReadLine();
            //}
            //Console.WriteLine($"{correctWord}");


            numberOfGuesses++;

            return input[0];
        }

        private static void EndGame()
        {
            Console.WriteLine("Game over...");
            Console.WriteLine($"Thank you for playing {name}");
            Console.WriteLine($" Guesses: {numberOfGuesses}");
        }
    }
}
