using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MTGEngine
{
    public class Game
    {
        private TurnOrder turnOrder;
        private Turn currentTurn;
        public bool gameIsOver = false;

        public Game( ICollection<IPlayer> players )
        { 
            this.turnOrder = new TurnOrder( players );
        }

        public void NextTurn()
        {
            var player = this.turnOrder.NextPlayer();
            this.currentTurn = new Turn( player );
        }
        
        public void StartTurn()
        {
            this.currentTurn.Begin();
            if ( State.GetInstance.Me().HitPoints < 1 )
            {
                this.gameIsOver = true;
                State.GetInstance.Me().Wins++;
            } else if (State.GetInstance.Opponent().HitPoints < 1)
            {
                this.gameIsOver = true;
                State.GetInstance.Opponent().Wins++;
            }
        }
    }
}
