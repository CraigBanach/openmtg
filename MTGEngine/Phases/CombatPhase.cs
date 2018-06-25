using MTGEngine.Cards;
using System.Linq;

namespace MTGEngine.Phases
{
    public class CombatPhase : IPhase
    {
        private Player currentPlayer;
        private IState state;

        public CombatPhase(Player currentPlayer, IState state)
        {
            this.currentPlayer = currentPlayer;
            this.state = state;
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
                this.state.Opponent().Damage(creature.Power);
            }
        }
    }
}
