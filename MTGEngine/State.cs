using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MTGEngine
{
    public class State
    {
        private IEnumerable<IPlayer> players;
        public IPlayer CurrentPlayer { private get; set; }
        private static State state;

        public static State GetInstance
        {
            get
            {
                if (state == null)
                {
                    state = new State();
                }
                return state;
            }
        }

        private State()
        {
        }

        public void ResetState()
        {
            state = null;
        }

        public void AddPlayers(ICollection<IPlayer> players)
        {
            this.players = players;
        }

        public IPlayer Opponent()
        {
            return this.players.First(player => player != this.CurrentPlayer);
        }

        public IPlayer Me()
        {
            return this.CurrentPlayer;
        }
    }
}
