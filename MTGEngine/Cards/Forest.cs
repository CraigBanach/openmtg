namespace MTGEngine.Cards
{
    public class Forest : Card
    {
        public Forest(
            string name = "Forest",
            CardType type = CardType.Land,
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
            throw new System.NotImplementedException();
        }
    }
}
