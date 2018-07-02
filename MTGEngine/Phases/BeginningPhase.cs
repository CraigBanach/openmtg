namespace MTGEngine.Phases
{
    public class BeginningPhase : IPhase
    {
        private IPlayer currentPlayer;

        public BeginningPhase(IPlayer currentPlayer)
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
