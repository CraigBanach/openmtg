using System.Collections.Generic;

namespace MTGEngine.Zones
{
    public class Stack : Stack<Card>
    {
        private IState state;

        public Stack()
        {
        }

        public Stack(IState state)
        {
            this.state = state;
        }

        public void Cast(Card card)
        {
            this.Push(card);
            this.Resolve();
        }

        public void Resolve()
        {
            this.Pop().Resolve(state);
        }
    }
}
