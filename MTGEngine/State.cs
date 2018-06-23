using MTGEngine.Zones;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MTGEngine
{
    public class State : IState
    {
        public Dictionary<Player, Battlefield> Battlefields;

        public State(Collection<Player> players)
        {
            this.Battlefields = new Dictionary<Player, Battlefield>
            {
                { players[0], new Battlefield() },
                { players[1], new Battlefield() }
            };
        }

        public Battlefield Battlefield(Player player)
        {
            return this.Battlefields[ player ];
        }
    }
}
