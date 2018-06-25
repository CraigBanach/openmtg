using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MTGEngine.Zones
{
    public class Battlefield
    {
        public ICollection<Card> Cards = new Collection<Card>();

        public void Untap()
        {
            foreach (var card in this.Cards)
            {
                card.Untap();
            }
        }

        public void Play(Card card)
        {
            this.Cards.Add( card );
        }
    }
}
