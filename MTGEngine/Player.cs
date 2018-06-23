using MTGEngine.Zones;

namespace MTGEngine
{
    public class Player
    {
        public Battlefield Battlefield { get; set; } = new Battlefield();
        public Deck Deck { get; set; }
        public Hand Hand { get; set; }

        public void Untap()
        {
            this.Battlefield.Untap();
        }

        public void DrawCards(int number)
        {
            for ( var i = 1; i <= number; i++ )
            {
                this.Deck.Draw();
            }
        }
    }
}
