namespace MTGEngine.Phases
{
    public class BeginningPhase : IPhase
    {
        private IState state;
        private Player currentPlayer;

        public BeginningPhase(IState state, Player currentPlayer)
        {
            this.state = state;
            this.currentPlayer = currentPlayer;
        }

        public void Begin()
        {
            this.currentPlayer.Untap();
            this.currentPlayer.DrawCards(1);
        }
    }
}
