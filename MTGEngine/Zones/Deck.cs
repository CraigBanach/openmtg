using System.Collections.Generic;

namespace MTGEngine
{
    public class Library : Stack<Card>
    {
        public Library(IEnumerable<Card> cards)
            : base(cards)
        {
        }

        public Card Draw()
        {
            return this.Pop();
        }
    }
}
