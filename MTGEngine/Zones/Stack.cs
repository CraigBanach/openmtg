using System.Collections.Generic;

namespace MTGEngine.Zones
{
    public class Stack : Stack<Card>
    {

        public Stack()
        {
        }

        public void Cast(Card card)
        {
            this.Push(card);
            this.Resolve();
        }

        public void Resolve()
        {
            this.Pop().Resolve();
        }
    }
}
