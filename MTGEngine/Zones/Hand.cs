using System.Collections.ObjectModel;

namespace MTGEngine
{
    public class Hand : Collection<Card>
    {
        public void AddCard(Card card)
        {
            this.Add( card );
        }

        public Card Play(Card card)
        {
            this.Remove( card );
            return card;
        }
    }
}
