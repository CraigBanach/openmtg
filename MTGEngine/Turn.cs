using MTGEngine.Phases;
using System.Collections.Generic;

namespace MTGEngine
{
    public class Turn
    {
        private Player player;
        private IList<IPhase> Phases = new List<IPhase>();
        private IPhase currentPhase;
        private IState state;

        public Turn(Player player, IState state)
        {
            this.state = state;

            this.player = player;

            this.Phases.Add( new BeginningPhase(this.state, this.player) );
            this.Phases.Add( new MainPhase() );
            this.Phases.Add( new CombatPhase() );
            this.Phases.Add( new MainPhase() );
            this.Phases.Add( new EndingPhase() );

            this.currentPhase = this.Phases[ 0 ];
        }

        public void Begin()
        {
            this.currentPhase.Begin();
        }
    }
}
