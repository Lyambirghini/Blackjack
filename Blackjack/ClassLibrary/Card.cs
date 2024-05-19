using System;

namespace ClassLibrary
{
    public class Card : ICard
    {
        public CardFace Face { get; }
        public CardSuit Suit { get; }

        private const int CardWidth = 9;
        private const int CardHeight = 5;

        public Card(CardFace face, CardSuit suit)
        {
            Face = face;
            Suit = suit;
        }

        public void Print(int x, int y)
        {
            string faceSymbol = GetFaceSymbol();
            string suitSymbol = GetSuitSymbol();

            Console.SetCursorPosition(x, y);

            Console.ForegroundColor = Suit == CardSuit.Hearts || Suit == CardSuit.Diamonds
                ? ConsoleColor.Red
                : ConsoleColor.Black;

            string[] cardLines = new string[]
            {
                "┌───────┐",
                $"│{faceSymbol,-2}     │",
                $"│   {suitSymbol,-2}  │",
                "│       │",
                "└───────┘"
            };

            foreach (string line in cardLines)
            {
                Console.SetCursorPosition(x, y++);
                Console.WriteLine(line);
            }

            Console.ResetColor();
        }

        private string GetFaceSymbol()
        {
            return Face switch
            {
                CardFace.A => "A",
                CardFace._2 => "2",
                CardFace._3 => "3",
                CardFace._4 => "4",
                CardFace._5 => "5",
                CardFace._6 => "6",
                CardFace._7 => "7",
                CardFace._8 => "8",
                CardFace._9 => "9",
                CardFace._10 => "10",
                CardFace.J => "J",
                CardFace.Q => "Q",
                CardFace.K => "K",
                _ => throw new ArgumentException("Invalid card face"),
            };
        }

        private string GetSuitSymbol()
        {
            return Suit switch
            {
                CardSuit.Spades => "♠",
                CardSuit.Hearts => "♥",
                CardSuit.Clubs => "♣",
                CardSuit.Diamonds => "♦",
                _ => throw new ArgumentException("Invalid card suit"),
            };
        }
    }
}