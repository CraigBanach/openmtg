using System.Collections.Generic;

namespace MTGEngine
{
    public class GameManager
    {
        private IEnumerable<Game> games;
        private Game currentGame;
        
        public void StartGame()
        {
            var player1 = new Player();
            var player2 = new Player();

            this.currentGame = new Game(player1, player2);
        }

        private void MoveToNextTurn()
        {
            this.currentGame.NextTurn();
        }

        private void BeginTurn()
        {
            this.currentGame.StartTurn();
        }
    }
}
