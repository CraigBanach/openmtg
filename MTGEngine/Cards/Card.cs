using System;
using MTGEngine.Cards;

namespace MTGEngine
{
    public abstract class Card
    {
        public bool Tapped { get; private set; } = false;
        //public bool Attacking { get; private set; } = false;
        public int Power { get; private set; }
        public string Name { get; set; }
        public CardType Type { get; set; }
        public ManaCost ManaCost { get; set; }

        public Card(
            string name, 
            CardType type, 
            ManaCost manaCost = null, 
            int power = 0)
        {
            this.Name = name;
            this.Type = type;
            this.ManaCost = manaCost;
            this.Power = power;
        }

        public abstract void Resolve();

        public void Untap()
        {
            this.Tapped = false;
        }
        
        public void Tap()
        {
            this.Tapped = true;
        }

        public void Attack()
        {
            //this.Attacking = true;
            this.Tapped = true;
        }
    }
}
