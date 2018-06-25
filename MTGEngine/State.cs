using MTGEngine.Zones;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MTGEngine
{
    public class State : IState
    {
        public Dictionary<Player, Battlefield> Battlefields;
        private IEnumerable<Player> players;
        public Player CurrentPlayer { private get; set; }

        public State()
        {

        }

        public void AddPlayers(Collection<Player> players)
        {
            this.players = players;

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

        public Player Opponent()
        {
            return this.players.First(player => player != this.CurrentPlayer);
        }

        public Player Me()
        {
            return this.CurrentPlayer;
        }
    }
}
