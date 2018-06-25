﻿using System.Collections.Generic;

namespace MTGEngine
{
    public class Deck : Stack<Card>
    {
        public Deck(IList<Card> cards)
            : base(cards)
        {
        }

        public Card Draw()
        {
            return this.Pop();
        }
    }
}
