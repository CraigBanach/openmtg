using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MTGEngine
{
    public class Game
    {
        private TurnOrder turnOrder;

        public Game( Player player1, Player player2 )
        {
            var players = new Collection<Player>{
                player1,
                player2
            };

            this.turnOrder = new TurnOrder( players );
        }
    }
}
