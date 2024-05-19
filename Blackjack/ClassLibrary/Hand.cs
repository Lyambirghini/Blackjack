using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Hand
    {
        protected List<ICard> _cards = new List<ICard>();
        private const int MaxXPosition = 108;
        private const int XIncrement = 12;
        private const int YIncrement = 8;
        public Hand()
        {
            _cards = new List<ICard>();
        }
        public virtual void AddCard(ICard card)
        {
            if (card == null)
                throw new ArgumentNullException(nameof(card), "Card cannot be null");

            _cards.Add(card);
        }
        public virtual void Print(int x, int y)
        {
            foreach (var card in _cards)
            {
                if (x >= MaxXPosition)
                {
                    x = 0;
                    y += YIncrement;
                }

                card.Print(x, y);
                x += XIncrement;
            }
        }
    }
}