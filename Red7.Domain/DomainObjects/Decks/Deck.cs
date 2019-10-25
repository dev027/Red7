// <copyright file="Deck.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Red7.Domain.DomainObjects.Axioms;
using Red7.Domain.DomainObjects.Cards;
using Red7.Domain.DomainObjects.Hands;
using Red7.Domain.DomainObjects.Palettes;
using Red7.Domain.ValueObjects;
using Red7.Utilities;

namespace Red7.Domain.DomainObjects.Decks
{
    /// <summary>
    /// The Deck of cards to deal from.
    /// </summary>
    /// <seealso cref="IDeck" />
    public class Deck : IDeck
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Deck"/> class.
        /// </summary>
        /// <param name="axiom">The axiom.</param>
        public Deck(IAxiom axiom)
        {
            this.Axiom = axiom;

            // Create a Deck of of all the possible Cards
            this.CardList = new List<ICard>();

            foreach (Colour colour in typeof(Colour).GetEnumValues().Cast<Colour>())
            {
                foreach (Number number in typeof(Number).GetEnumValues().Cast<Number>())
                {
                    this.CardList.Add(new Card(colour, number, axiom));
                }
            }

            // Shuffle the Deck
            this.Shuffle();
        }

        #endregion Constructor

        #region Public Properties

        /// <summary>
        /// Gets the cards.
        /// </summary>
        public IReadOnlyList<ICard> Cards => (IReadOnlyList<ICard>)this.CardList;

        #endregion Public Properties

        #region Private Properties

        private IList<ICard> CardList { get; }

        private IAxiom Axiom { get; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        /// Deals a hand.
        /// </summary>
        /// <returns>A Hand.</returns>
        public IHand DealHand()
        {
            IList<ICard> cards = this.DealCards(this.Axiom.InitialNumberOfCardsInHand);

            return cards == null
                ? null
                : new Hand(cards);
        }

        /// <summary>
        /// Deals a palette.
        /// </summary>
        /// <returns>A Palette.</returns>
        public IPalette DealPalette()
        {
            IList<ICard> cards = this.DealCards(this.Axiom.InitialNumberOfCardsInPalette);

            return cards == null
                ? null
                : new Palette(cards);
        }

        #endregion Public Methods

        #region Private Methods

        private void Shuffle()
        {
            this.CardList.Shuffle();
        }

        private IList<ICard> DealCards(int cardsToDeal)
        {
            IList<ICard> cards = new List<ICard>();

            for (int i = 0; i < cardsToDeal; i++)
            {
                ICard card = this.DealCard();

                // If insufficient cards then return null
                if (card == null)
                {
                    return null;
                }

                cards.Add(card);
            }

            return cards;
        }

        private ICard DealCard()
        {
            ICard card = this.CardList.FirstOrDefault();
            if (card != null)
            {
                this.CardList.Remove(card);
            }

            return card;
        }

        #endregion Private Methods
    }
}