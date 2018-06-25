using MTGEngine.Cards;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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
            var cost = card.ManaCost.Total();
            var landsToTap = this.Cards.Where(land => land.Type == CardType.Land).Take(cost);
            foreach(var land in landsToTap)
            {
                land.Tap();
            }
        }

        internal void PlayLand(Card card)
        {
            this.Cards.Add(card);
        }
    }
}
