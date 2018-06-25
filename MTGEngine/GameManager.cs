using MTGEngine.Cards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MTGEngine
{
    public class GameManager
    {
        private IEnumerable<Game> games;
        private Game currentGame;
        private Random random = new Random();
        
        public void StartGame()
        {
            var deck = new List<Card>();
            for (var i = 0; i < 30; i++)
            {
                deck.Add(new Mountain());
                deck.Add(new LavaSpike(manaCost: new ManaCost { Red = 1 }));
            }
            var shuffled = deck.OrderBy(item => this.random.Next());

            var deck1 = new Deck(shuffled);

            var deck2 = new List<Card>();
            for (var i = 0; i < 30; i++)
            {
                deck2.Add(new Forest());
                deck2.Add(new GrizzlyBear(manaCost: new ManaCost { Green = 1, Any = 1 }));
            }
            var shuffled2 = deck2.OrderBy(item => this.random.Next());

            var deck3 = new Deck(shuffled2);

            var state = new State();

            var player1 = new Player(deck1, state, "Red");
            var player2 = new Player(deck3, state, "Green");

            state.AddPlayers(new System.Collections.ObjectModel.Collection<Player>()
            {
                player1, player2
            });

            this.currentGame = new Game(player1, player2);

            while ( !this.currentGame.gameIsOver )
            {
                this.MoveToNextTurn();
                this.BeginTurn();
            }
        }

        private void MoveToNextTurn()
        {
            this.currentGame.NextTurn();
        }

        private void BeginTurn()
        {
            this.currentGame.StartTurn();
        }
    }
}
