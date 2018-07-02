namespace MTGEngine.Phases
{
    public class EndingPhase : IPhase
    {
        private IPlayer currentPlayer;

        public EndingPhase(IPlayer currentPlayer)
        {
            this.currentPlayer = currentPlayer;
        }

        public void Begin()
        {
            if ( this.currentPlayer.Hand.Count > 7 )
            {
                var discard = this.currentPlayer.Hand.Discard();
                this.currentPlayer.Graveyard.Add(discard);
            }
        }
    }
}
