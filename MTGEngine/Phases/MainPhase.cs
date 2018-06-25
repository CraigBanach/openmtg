namespace MTGEngine.Phases
{
    public class MainPhase : IPhase
    {
        private Player currentPlayer;

        public MainPhase(Player currentPlayer)
        {
            this.currentPlayer = currentPlayer;
        }

        public void Begin()
        {
            this.currentPlayer.DoMainPhaseActions();
        }
    }
}
