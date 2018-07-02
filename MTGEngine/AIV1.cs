using System;
using MTGEngine.Zones;
using System.Collections.ObjectModel;
using System.Linq;
using MTGEngine.Cards;
using System.Collections.Generic;

namespace MTGEngine
{
    public class AIV1 : IPlayer
    {
        public Battlefield Battlefield { get; set; } = new Battlefield();
        public IEnumerable<Card> Deck { get; set; }
        public Library Library { get; set; }
        public Hand Hand { get; set; }
        public Graveyard Graveyard { get; set; }
        private Random random = new Random();
        public int HitPoints { get; private set; } = 20;
        private bool hasPlayedLand = false;
        public string Name { get; set; }
        public int Wins { get; set; }

        public AIV1(IEnumerable<Card> deck, string Name)
        {
            this.Deck = deck;
            this.Name = Name;
            this.Reset();
        }

        public void CreateLibrary()
        {
            this.Library = new Library( 
                this.Deck.OrderBy( item => this.random.Next() ) );
        }

        public void Reset()
        {
            this.CreateLibrary();
            this.Hand = new Hand();
            this.Graveyard = new Graveyard();
            this.DrawCards( 7 );
            this.HitPoints = 20;
        }
        
        public void Untap()
        {
            this.Battlefield.Untap();
        }

        public void DoMainPhaseActions()
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

        public void Damage(int damage)
        {
            this.HitPoints -= damage;
            //Console.WriteLine($"{State.GetInstance.Me().Name} did { damage } to {this.Name}.");
        }

        private void PlaySpell( Collection<Card> playableCards )
        {
            var rand = this.random.Next( playableCards.Count );

            if (playableCards[rand].Type == CardType.Creature)
            {
                this.Battlefield.Play(this.Hand.Play(playableCards[rand]));
            } else
            {
                this.Cast(this.Hand.Play(playableCards[rand]));
            }
        }

        public void Cast(Card card)
        {
            card.Resolve();
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
                    .Count(land => land.Type == CardType.Land) >= card.ManaCost.Total() )
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
            this.Battlefield.PlayLand( this.Hand.Play( landToPlay ) );
        }

        public void DrawCards(int number)
        {
            for ( var i = 1; i <= number; i++ )
            {
                this.Hand.AddCard(this.Library.Draw());
            }
        }
    }
}
