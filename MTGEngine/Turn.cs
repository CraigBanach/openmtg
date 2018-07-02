using MTGEngine.Phases;
using System;
using System.Collections.Generic;

namespace MTGEngine
{
    public class Turn
    {
        private IPlayer player;
        private IList<IPhase> Phases = new List<IPhase>();
        private IPhase currentPhase;
        private bool turnEnded = false;

        public Turn(IPlayer player)
        {
            this.player = player;

            State.GetInstance.CurrentPlayer = this.player;

            this.Phases.Add( new BeginningPhase(this.player) );
            this.Phases.Add( new MainPhase(this.player) );
            this.Phases.Add( new CombatPhase(this.player) );
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
                if (State.GetInstance.Me().HitPoints < 1 || State.GetInstance.Opponent().HitPoints < 1)
                {
                    //Console.WriteLine("Game is over.");
                    //Console.ReadLine();
                }
            } else
            {
                this.currentPhase = this.Phases[ currentPhaseNum + 1 ];
            }
        }
    }
}
