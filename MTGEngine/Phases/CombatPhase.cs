using MTGEngine.Cards;
using System.Linq;

namespace MTGEngine.Phases
{
    public class CombatPhase : IPhase
    {
        private Player currentPlayer;

        public CombatPhase(Player currentPlayer)
        {
            this.currentPlayer = currentPlayer;
        }

        public void Begin()
        {
            var creatures = this.currentPlayer.Battlefield.Cards
                .Where(
                    card => card.Type == CardType.Creature
                    && !card.Tapped
                );

            foreach (var creature in creatures ?? Enumerable.Empty<Card>())
            {
                creature.Attack();
                State.GetInstance.Opponent().Damage(creature.Power);
            }
        }
    }
}
