namespace MTGEngine.Cards
{
    public class Mountain : Card
    {
        public Mountain(
            string name = "Mountain",
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
