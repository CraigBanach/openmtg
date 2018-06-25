using System.Collections.ObjectModel;

namespace MTGEngine
{
    public class Game
    {
        private TurnOrder turnOrder;
        private Turn currentTurn;
        private IState state;
        public bool gameIsOver = false;

        public Game( Player player1, Player player2 )
        {
            var players = new Collection<Player>{
                player1,
                player2
            };

            this.state = new State( players );

            this.turnOrder = new TurnOrder( players );
        }

        public void NextTurn()
        {
            var player = this.turnOrder.NextPlayer();
            this.currentTurn = new Turn( player, this.state );
        }
        
        public void StartTurn()
        {
            this.currentTurn.Begin();
        }
    }
}
