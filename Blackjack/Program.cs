using System;
using ClassLibrary;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Title = "♣ ♠ Blackjack ♥ ♦";

        bool runProgram = true;
        string prompt = "What would you like to do? ";
        string[] menuOptions = new string[] { "(1) Play Blackjack", "(2) Shuffle and Show Deck", "(3) Exit" };
        int menuSelection;

        while (runProgram)
        {
            Console.Clear();
            ReadMethods.ReadChoice(prompt, menuOptions, out menuSelection);

            switch (menuSelection)
            {
                case 1:
                    RunBlackjackGame();
                    break;
                case 2:
                    ShuffleAndShowDeck();
                    break;
                case 3:
                    runProgram = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }

    static void RunBlackjackGame()
    {
        Console.Clear();
        BlackjackGame gameInstance = new BlackjackGame();
        bool playBlackjack = true;

        while (playBlackjack)
        {
            gameInstance.PlayRound();
            int choice = ReadMethods.ReadInteger("Want to play again?\n(1) Yes   (2) No ", 1, 2);
            playBlackjack = (choice == 1);
        }
    }

    static void ShuffleAndShowDeck()
    {
        Console.Clear();
        Deck deck = new Deck();
        deck.InitializeDeck();
        deck.Shuffle();
        deck.Print(0, 6);
        Console.WriteLine("\nPress any key to return to the main menu...");
        Console.ReadKey();
    }
}
