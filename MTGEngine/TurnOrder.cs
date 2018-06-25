using System.Collections.Generic;
using System.Linq;

namespace MTGEngine
{
    public class TurnOrder
    {
        private IList<Player> playerOrder;
        private int listCounter = 0;

        public TurnOrder( IEnumerable<Player> players )
        {
            this.playerOrder = players.ToList();
        }

        public Player NextPlayer()
        {
            var player = this.playerOrder[ this.listCounter ];
            this.listCounter = this.listCounter >= this.playerOrder.Count - 1
                ? 0
                : this.listCounter + 1;

            return player;
        }
    }
}
