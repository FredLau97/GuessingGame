using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Game
    {
        Random random = new Random();
        List<string> words = new List<string>() { "hospital", "penguin", "fork", "socks", "dinosaur" };
        List<string> hints = new List<string>() { "", "", "" };
        string secretWord;
        string guess;
        string prompt;
        public string endPrompt;
        int randomWord;
        int maxGuesses;
        int guessCount;
        int hintUses;
        bool outOfGuesses;
        bool hasGuessedWord;
        bool outOfHints;

        public Game()
        {
            randomWord = random.Next(0, 5);
            secretWord = words[randomWord];
            prompt = "\nEnter your guess - or have a hint!";
            guessCount = 0;
            maxGuesses = 10;
            hintUses = 0;
            outOfGuesses = false;
            hasGuessedWord = false;
            outOfHints = false;
        }

        public void StartGame()
        {
            SetHints();

            Console.WriteLine($"Welcome to the Guessing Game!" +
                $"\nYou have to guess the secret word." +
                $"\nYou have a total of 10 guesses before you lose." +
                $"\nYou can have 3 hints as to what the word is - they do however cost a guess to use!" +
                $"\nType in 'hint' to get one of the hints!" +
                $"\nType in 'q' at any time to quit the game." +
                $"\nOtherwise, just type in your guess. Good luck!");

            while (guess != secretWord && !outOfGuesses && !hasGuessedWord)
            {
                if (guessCount < maxGuesses)
                {
                    Console.WriteLine(prompt);
                    guess = Console.ReadLine();
                    guess.ToLower();

                    if (guess == "hint")
                    {
                        if (!outOfHints)
                        {
                            Console.WriteLine("\n" + hints[0]);
                            hints.Remove(hints[0]);
                            hintUses++;
                            guessCount++;
                            Console.WriteLine($"You have {maxGuesses - guessCount} guesses left!");

                            if (hintUses == 3)
                            {
                                outOfHints = true;
                                prompt = "\nEnter your guess!";
                            }
                        }
                        else
                            Console.WriteLine("You are out of hints!");
                    }
                    else if (guess == "q")
                        Environment.Exit(0);
                    else if (guess != "hint" && guess != "q")
                    {
                        if (guess == secretWord)
                        {
                            hasGuessedWord = true;
                            guessCount++;
                        }
                        else
                        {
                            if (guessCount == 9)
                            {
                                Console.WriteLine("\nThat is not the right word!");
                                guessCount++;
                                Console.WriteLine($"You are out of guesses!");
                            }
                            else
                            {
                                Console.WriteLine("\nThat is not the right word!");
                                guessCount++;
                                Console.WriteLine($"You have {maxGuesses - guessCount} guesses left!");
                            }
                        }
                    }

                }
                else
                    outOfGuesses = true;
            }

            if (hasGuessedWord)
            {
                Console.WriteLine($"\nCongratulations! You guessed the word '{secretWord}'!");
                Console.WriteLine($"You used {guessCount} guesses and {hintUses} hints!");
            }
            else if (outOfGuesses)
            {
                Console.WriteLine($"\nToo bad! You did not guess the word '{secretWord}'!");
            }
        }

        void SetHints()
        {
            switch (secretWord)
            {
                case "hospital":
                    hints[0] = " - Unhealthy people come here";
                    hints[1] = " - It is a kind of building";
                    hints[2] = " - A red cross is often associated with it";
                    break;
                case "penguin":
                    hints[0] = " - It is an animal";
                    hints[1] = " - It is often black and white";
                    hints[2] = " - It often likes the cold";
                    break;
                case "fork":
                    hints[0] = " - An item of cutlery";
                    hints[1] = " - Most often used with the left hand";
                    hints[2] = " - Often seen with a knife";
                    break;
                case "socks":
                    hints[0] = " - Puppets can be made of them";
                    hints[1] = " - A kind of garment";
                    hints[2] = " - They hang on fireplaces at a certain time of year";
                    break;
                case "dinosaur":
                    hints[0] = " - Extinct reptile";
                    hints[1] = " - Can be both carnivores and herbivores";
                    hints[2] = " - Part of Jurassic Park";
                    break;
                default:
                    break;
            }
        }
    }
}
