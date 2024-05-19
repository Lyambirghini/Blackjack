using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Deck
    {
        private const int TotalSuits = 4;
        private const int CardsPerSuit = 13;
        private const int TotalCards = 52;
        private List<ICard> _cards = new List<ICard>();

        public Deck()
        {
            InitializeDeck();
            Shuffle();
        }

        // Change access modifier to public
        public void InitializeDeck()
        {
            _cards.Clear();
            for (int i = 0; i < TotalSuits; i++)
            {
                for (int j = 0; j < CardsPerSuit; j++)
                {
                    _cards.Add(CardFactory.CreateBlackjackCard((CardFace)j, (CardSuit)i));
                }
            }
        }

        public void Shuffle()
        {
            Random rng = new Random();
            int n = _cards.Count;
            for (int i = 0; i < n - 1; i++)
            {
                int j = rng.Next(i, n);
                ICard temp = _cards[j];
                _cards[j] = _cards[i];
                _cards[i] = temp;
            }
        }

        public ICard Deal()
        {
            if (_cards.Count == 0)
            {
                throw new InvalidOperationException("No cards left in the deck to deal.");
            }
            ICard card = _cards[0];
            _cards.RemoveAt(0);
            return card;
        }

        public void Print(int x, int y)
        {
            const int MaxX = 108;
            const int XIncrement = 12;
            const int YIncrement = 8;

            for (int i = 0; i < _cards.Count; i++)
            {
                if (x >= MaxX)
                {
                    x = 0;
                    y += YIncrement;
                }

                _cards[i].Print(x, y);
                x += XIncrement;
            }
        }
    }
}
    