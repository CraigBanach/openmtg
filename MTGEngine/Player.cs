using MTGEngine.Zones;

namespace MTGEngine
{
    public class Player
    {
        public Battlefield Battlefield { get; set; } = new Battlefield();
        public Deck Deck { get; set; }
        public Hand Hand { get; set; }
    }
}
