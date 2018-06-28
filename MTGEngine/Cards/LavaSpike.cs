namespace MTGEngine.Cards
{
    public class LavaSpike : Card
    {
        public LavaSpike(
            string name = "Lava Spike", 
            CardType type = CardType.Sorcery, 
            ManaCost manaCost = null, 
            int power = 0) 
            : base(
                  name, 
                  type, 
                  manaCost, 
                  power)
        {
        }

        public override void Resolve()
        {
            State.GetInstance.Opponent().Damage(3);
            State.GetInstance.Me().Graveyard.Add(this);
        }
    }
}
