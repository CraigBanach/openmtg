namespace MTGEngine.Phases
{
    public class BeginningPhase : IPhase
    {
        private Player currentPlayer;

        public BeginningPhase(Player currentPlayer)
        {
            this.currentPlayer = currentPlayer;
        }

        public void Begin()
        {
            this.currentPlayer.Untap();
            this.currentPlayer.DrawCards(1);
        }
    }
}
