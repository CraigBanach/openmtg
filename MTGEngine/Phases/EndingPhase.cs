namespace MTGEngine.Phases
{
    public class EndingPhase : IPhase
    {
        private Player currentPlayer;

        public EndingPhase(Player currentPlayer)
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
