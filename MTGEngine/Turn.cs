using MTGEngine.Phases;
using System.Collections.Generic;

namespace MTGEngine
{
    public class Turn
    {
        private Player player;
        private IList<IPhase> Phases = new List<IPhase>();
        private IPhase currentPhase;

        public Turn(Player player)
        {
            this.player = player;

            this.Phases.Add( new BeginningPhase() );
            this.Phases.Add( new MainPhase() );
            this.Phases.Add( new CombatPhase() );
            this.Phases.Add( new MainPhase() );
            this.Phases.Add( new EndingPhase() );

            this.currentPhase = this.Phases[ 0 ];
        }
    }
}
