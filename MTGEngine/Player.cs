using System;
using MTGEngine.Zones;
using System.Collections.ObjectModel;
using System.Linq;
using MTGEngine.Cards;

namespace MTGEngine
{
    public class Player
    {
        public Battlefield Battlefield { get; set; } = new Battlefield();
        public Deck Deck { get; set; }
        public Hand Hand { get; set; }
        private Random random = new Random();

        private bool hasPlayedLand = false;

        public void Untap()
        {
            this.Battlefield.Untap();
        }

        internal void DoMainPhaseActions()
        {
            if ( this.CanPlayLand() )
            {
                this.PlayLand();
            }

            var playableSpells = this.PlayableSpells();
            while ( playableSpells.Count > 0 )
            {
                this.PlaySpell(playableSpells);
                playableSpells = this.PlayableSpells();
            }
        }

        private void PlaySpell( Collection<Card> playableCards )
        {
            var rand = this.random.Next( playableCards.Count );

            this.Battlefield.Play( this.Hand.Play( playableCards[ rand ] ) );
        }

        private Collection<Card> PlayableSpells()
        {
            Collection<Card> cards = new Collection<Card>();

            foreach (var card in this.Hand)
            {
                if ( card.ManaCost == null )
                {
                    continue;
                }

                if ( this.Battlefield.Cards
                    .Where(land => land.Type == CardType.Land)
                    .Count(land => land.Type == CardType.Land) > card.ManaCost.Total() )
                {
                    cards.Add( card );
                }
            }

            return cards;
        }

        private bool CanPlayLand()
        {
            return !this.hasPlayedLand
                && this.Hand.Any( card => card.Type == CardType.Land );
        }

        private void PlayLand()
        {
            var landToPlay = this.Hand.First( card => card.Type == CardType.Land );
            this.Battlefield.Play( this.Hand.Play( landToPlay ) );
        }

        public void DrawCards(int number)
        {
            for ( var i = 1; i <= number; i++ )
            {
                this.Hand.AddCard(this.Deck.Draw());
            }
        }
    }
}
