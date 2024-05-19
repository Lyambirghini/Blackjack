using System;

namespace ClassLibrary
{
    public class BlackjackGame
    {
        private BlackjackHand _dealer;
        private BlackjackHand _player;
        private Deck _deck;

        private const int CursorPosX = 0;
        private const int DealerHandPosY = 0;
        private const int PlayerHandPosY = 12;

        public void PlayRound()
        {
            do
            {
                InitializeGame();
                PlayCurrentRound();
                _dealer.IsDealer = false;
                DeclareWinner();
            } while (WantToPlayAgain());
        }

        private void InitializeGame()
        {
            _dealer = new BlackjackHand(isDealer: true);
            _player = new BlackjackHand(isDealer: false);
            _deck = new Deck();
            _deck.InitializeDeck(); // Ensure InitializeDeck is public in Deck class
            _deck.Shuffle();
            DealInitialCards();
        }

        private void DealInitialCards()
        {
            for (int i = 0; i < 2; i++)
            {
                _player.AddCard(_deck.Deal());
                _dealer.AddCard(_deck.Deal());
            }
            DrawTable();
        }

        private void PlayCurrentRound()
        {
            bool playRound = true;
            while (playRound)
            {
                if (_dealer.Score == 21 || _player.Score == 21)
                {
                    playRound = false;
                    DrawTable();
                    RevealDealerCard();
                }
                else
                {
                    PlayersTurn();
                    DealersTurn();
                    playRound = false;
                }
            }
        }

        private void PlayersTurn()
        {
            bool userStands = false;

            while (_player.Score < 21 && !userStands)
            {
                Console.SetCursorPosition(0, 20);
                _player.Print(0, 20);
                int option = ReadMethods.ReadInteger("(1) Hit or (2) Stand ", 1, 2);
                if (option == 1)
                {
                    _player.AddCard(_deck.Deal());
                    DrawTable();
                }
                else
                {
                    userStands = true;
                }
            }
        }

        private void DealersTurn()
        {
            while (_dealer.Score < 17)
            {
                _dealer.AddCard(_deck.Deal());
                DrawTable();
            }
        }

        private void DeclareWinner()
        {
            DrawTable();
            string result;
            if (_player.Score > 21)
            {
                result = "Dealer wins, Player went over 21";
            }
            else if (_dealer.Score > 21)
            {
                result = "Player wins, Dealer went over 21";
            }
            else if (_player.Score > _dealer.Score)
            {
                result = "Player wins, Player's score was higher";
            }
            else if (_dealer.Score > _player.Score)
            {
                result = "Dealer wins, Dealer's score was higher";
            }
            else
            {
                result = "No winner, Player and Dealer tied";
            }

            Console.SetCursorPosition(0, 23);
            Console.WriteLine(result);
        }

        private void DrawTable()
        {
            Console.Clear();
            DrawHand("Dealer's Hand", _dealer, DealerHandPosY);
            DrawHand("Player's Hand", _player, PlayerHandPosY);
        }

        private void DrawHand(string title, BlackjackHand hand, int posY)
        {
            Console.SetCursorPosition(CursorPosX, posY);
            Console.WriteLine($"---- {title} ----");
            hand.Print(CursorPosX, posY + 1);
        }

        private void RevealDealerCard()
        {
            Console.SetCursorPosition(CursorPosX, DealerHandPosY + 1);
            _dealer.PrintReveal(CursorPosX, DealerHandPosY + 1);
        }

        private bool WantToPlayAgain()
        {
            int choice = ReadMethods.ReadInteger("Want to play again?\n(1) Yes   (2) No ", 1, 2);
            return choice == 1;
        }
    }
}
