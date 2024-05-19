
namespace ClassLibrary
{
    public class BlackjackHand : Hand
    {
        public int Score { get; private set; }
        public bool IsDealer { get; set; }

        private const int CardSpacing = 5;
        private const int DealerHiddenCardOffset = 12;

        public BlackjackHand(bool isDealer = false)
        {
            IsDealer = isDealer;
        }

        public override void AddCard(ICard card)
        {
            base.AddCard(card);
            UpdateScore();
        }

        private void UpdateScore()
        {
            Score = 0;
            int aceCount = 0;

            foreach (var card in _cards)
            {
                if (card is BlackjackCard blackjackCard)
                {
                    if (blackjackCard.Face == CardFace.A)
                        aceCount++;
                    else
                        Score += blackjackCard.Value;
                }
            }

            // Handle aces
            while (aceCount > 0)
            {
                if (Score + 11 <= 21)
                {
                    Score += 11;
                }
                else
                {
                    Score += 1;
                }
                aceCount--;
            }

        }

        public override void Print(int x, int y)
        {
            foreach (var card in _cards)
            {
                card.Print(x, y);
                y += CardSpacing;
            }
            Console.WriteLine($"Score: {Score}");
        }
        public int CountCards()
        {
            return _cards.Count;
        }

        public void PrintReveal(int x, int y)
        {
            if (_cards.Count > 0)
            {
                int yOffset = 0;
                for (int i = 0; i < _cards.Count; i++)
                {
                    Console.SetCursorPosition(x, y + yOffset);
                    Console.WriteLine("┌───────┐");
                    Console.WriteLine("│       │");
                    Console.WriteLine("│   ?   │");
                    Console.WriteLine("│       │");
                    Console.WriteLine("└───────┘");

                    yOffset += DealerHiddenCardOffset;
                }
            }
        }
    }
}
