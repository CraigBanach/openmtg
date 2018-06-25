using System;
using System.Collections.ObjectModel;

namespace MTGEngine
{
    public class Hand : Collection<Card>
    {
        private Random random = new Random();

        public void AddCard(Card card)
        {
            this.Add( card );
        }

        public Card Play(Card card)
        {
            this.Remove( card );
            return card;
        }

        internal Card Discard(Card card = null)
        {
            Card discard;

            if (card == null)
            {
                var randNum = this.random.Next(8);
                discard = this.Items[randNum];
                this.Items.RemoveAt(randNum);
            } else
            {
                discard = card;
                this.Items.Remove(card);
            }

            return discard;
        }
    }
}
