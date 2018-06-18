using System.Collections.Generic;

namespace MTGEngine
{
    public class GameManager
    {
        private IEnumerable<Game> games;
        
        public void StartGame()
        {
            var player1 = new Player();
            var player2 = new Player();

            var game = new Game(player1, player2);
        }
    }
}
