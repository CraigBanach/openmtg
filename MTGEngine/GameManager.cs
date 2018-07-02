using Microsoft.Data.Sqlite;
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
        //private IEnumerable<Game> games;
        private Game currentGame;
        private Random random = new Random();
        private ICollection<IPlayer> players = new Collection<IPlayer>();
        
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
            


            //SqliteConnection dbConnection = new SqliteConnection( @"Data Source=|DataDirectory|\..\..\..\..\db\openmtg.db;" );
            //dbConnection.Open();

            for ( var i = 0; i < 1000; i++ )
            {
                do
                {
                    this.players.Add(new AIV1(decks[0], "Red"));
                    this.players.Add(new AIV1(decks[1], "Green"));

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

                var winningPlayer = this.players.First( player => player.HitPoints > 0 );

                //SqliteCommand command = new SqliteCommand( $"INSERT INTO wins (deck) values ('{winningPlayer.Name}');", dbConnection );
                //command.ExecuteNonQuery();
                if ( i % 100 == 0 )
                {
                    Console.WriteLine( $"Run {i} games" );
                }
            }
            //dbConnection.Close();

            Console.WriteLine( "Inserted 10000 entries" );
            Console.ReadLine();
        }

        private bool MatchIsOver()
        {
            return this.players.Any( player => player.Wins > 1 );
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
