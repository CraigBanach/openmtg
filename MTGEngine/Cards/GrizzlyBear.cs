namespace MTGEngine.Cards
{
    public class GrizzlyBear : Card
    {
        public GrizzlyBear(
            string name = "Grizzly Bear",
            CardType type = CardType.Creature,
            ManaCost manaCost = null,
            int power = 2)
            : base(
                  name,
                  type,
                  manaCost,
                  power)
        {
        }

        public override void Resolve()
        {
            throw new System.NotImplementedException();
        }
    }
}
