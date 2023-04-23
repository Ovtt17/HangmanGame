using System;
using System.Collections.Generic;

namespace HangmanGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hangman Game!");

            // List of words to choose from
            List<string> words = new List<string> { "apple", "banana", "cherry", "orange", "pear" };

            // Select a random word
            Random random = new Random();
            string selectedWord = words[random.Next(words.Count)];

            // Create a char array to store the guessed letters
            char[] guessedLetters = new char[selectedWord.Length];

            // Fill the guessed letters array with underscores
            for (int i = 0; i < guessedLetters.Length; i++)
            {
                guessedLetters[i] = '_';
            }

            // Print the initial state of the game
            Console.WriteLine($"The word has {selectedWord.Length} letters: {string.Join(" ", guessedLetters)}");

            // Keep track of the number of incorrect guesses
            int incorrectGuesses = 0;

            // Loop until the word is guessed or the player runs out of guesses
            while (incorrectGuesses < 6 && Array.IndexOf(guessedLetters, '_') >= 0)
            {
                Console.Write("Guess a letter: ");
                char guess = Console.ReadLine()[0];

                // Check if the letter has already been guessed
                if (Array.IndexOf(guessedLetters, guess) >= 0)
                {
                    Console.WriteLine($"You already guessed '{guess}'");
                    continue;
                }

                // Check if the letter is in the word
                bool found = false;
                for (int i = 0; i < selectedWord.Length; i++)
                {
                    if (selectedWord[i] == guess)
                    {
                        guessedLetters[i] = guess;
                        found = true;
                    }
                }

                // If the letter is not in the word, increment the number of incorrect guesses
                if (!found)
                {
                    incorrectGuesses++;
                    Console.WriteLine($"'{guess}' is not in the word");
                }

                // Print the current state of the game
                Console.WriteLine($"Incorrect guesses: {incorrectGuesses}");
                Console.WriteLine($"Guessed letters: {string.Join(" ", guessedLetters)}\n");
            }

            // Print the result of the game
            if (incorrectGuesses == 6)
            {
                Console.WriteLine("You lost! The word was " + selectedWord);
            }
            else
            {
                Console.WriteLine("You won!");
            }

            Console.WriteLine("Thanks for playing!");
        }
    }
}
