namespace MTGEngine.Phases
{
    public class MainPhase : IPhase
    {
        private IPlayer currentPlayer;

        public MainPhase(IPlayer currentPlayer)
        {
            this.currentPlayer = currentPlayer;
        }

        public void Begin()
        {
            this.currentPlayer.DoMainPhaseActions();
        }
    }
}
