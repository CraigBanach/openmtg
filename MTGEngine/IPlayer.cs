using System.Collections.Generic;
using MTGEngine.Zones;

namespace MTGEngine
{
    public interface IPlayer
    {
        Battlefield Battlefield { get; set; }
        IEnumerable<Card> Deck { get; set; }
        Graveyard Graveyard { get; set; }
        Hand Hand { get; set; }
        int HitPoints { get; }
        Library Library { get; set; }
        int Wins { get; set; }
        string Name { get; set; }

        void Cast(Card card);
        void CreateLibrary();
        void Damage(int damage);
        void DoMainPhaseActions();
        void DrawCards(int number);
        void Reset();
        void Untap();
    }
}