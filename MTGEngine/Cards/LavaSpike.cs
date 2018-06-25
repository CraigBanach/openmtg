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

        public override void Resolve(IState state)
        {
            state.Opponent().Damage(3);
            state.Me().Graveyard.Add(this);
        }
    }
}
