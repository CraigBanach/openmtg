using MTGEngine.Cards;

namespace MTGEngine
{
    public class Card
    {
        private bool tapped = false;
        public string Name { get; set; }
        public CardType Type { get; set; }
        public ManaCost ManaCost { get; set; }

        public void Untap()
        {
            this.tapped = false;
        }
    }
}
