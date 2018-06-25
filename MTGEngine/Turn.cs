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
        private bool turnEnded = false;

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
            this.NextPhase();
            if (this.turnEnded)
            {
                return;
            } else
            {
                this.Begin();
            }
        }

        public void NextPhase()
        {
            var currentPhaseNum = this.Phases.IndexOf( this.currentPhase );

            if ( currentPhaseNum == this.Phases.Count )
            {
                this.turnEnded = true;
            } else
            {
                this.currentPhase = this.Phases[ currentPhaseNum + 1 ];
            }
        }
    }
}
