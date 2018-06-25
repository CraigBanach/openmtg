using MTGEngine.Phases;
using System;
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

        public Turn(Player player)
        {
            this.state = player.state;

            this.player = player;

            this.state.CurrentPlayer = this.player;

            this.Phases.Add( new BeginningPhase(this.state, this.player) );
            this.Phases.Add( new MainPhase(this.player) );
            this.Phases.Add( new CombatPhase(this.player, this.state) );
            this.Phases.Add( new MainPhase(this.player) );
            this.Phases.Add( new EndingPhase(this.player) );

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

            if ( currentPhaseNum == this.Phases.Count - 1 )
            {
                this.turnEnded = true;
                if (this.state.Me().HitPoints < 1 || this.state.Opponent().HitPoints < 1)
                {
                    Console.WriteLine("Game is over.");
                    Console.ReadLine();
                }
            } else
            {
                this.currentPhase = this.Phases[ currentPhaseNum + 1 ];
            }
        }
    }
}
