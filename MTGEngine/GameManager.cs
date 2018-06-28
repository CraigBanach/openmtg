using MTGEngine.Cards;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MTGEngine
{
    public class GameManager
    {
        private IEnumerable<Game> games;
        private Game currentGame;
        private Random random = new Random();
        private ICollection<Player> players = new Collection<Player>();
        
        public void StartGame()
        {
            Collection<IEnumerable<Card>> decks = new Collection<IEnumerable<Card>>();

            for ( var i = 0; i < 2; i++ )
            {
                var deck = new List<Card>();
                for ( var j = 0; j < 30; j++ )
                {
                    deck.Add( new Mountain() );
                    deck.Add( new LavaSpike( manaCost: new ManaCost { Red = 1 } ) );
                }
                decks.Add( deck );
            }
            
            this.players.Add(new Player(decks[0], "Red"));
            this.players.Add(new Player(decks[1], "Green"));

            do
            {
                foreach ( var player in this.players )
                {
                    player.Reset();
                }

                State.GetInstance.AddPlayers( this.players );

                this.currentGame = new Game( this.players );

                while ( !this.currentGame.gameIsOver )
                {
                    this.MoveToNextTurn();
                    this.BeginTurn();
                }
            } while ( !this.MatchIsOver() );
        }

        private bool MatchIsOver()
        {
            return this.players.Any( player => player.wins > 1 );
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
