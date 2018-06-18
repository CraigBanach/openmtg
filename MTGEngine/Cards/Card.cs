using MTGEngine.Cards;

namespace MTGEngine
{
    public class Card
    {
        public string Name { get; set; }
        public CardType Type { get; set; }
        public ManaCost ManaCost { get; set; }
    }
}
