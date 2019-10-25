// <copyright file="Hand.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Red7.Domain.DomainObjects.Cards;

namespace Red7.Domain.DomainObjects.Hands
{
    /// <summary>
    /// Player's hand.
    /// </summary>
    public class Hand : IHand
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Hand"/> class.
        /// </summary>
        /// <param name="cards">List of cards that make up the hand.</param>
        public Hand(IEnumerable<ICard> cards)
        {
            this.CardList = cards.ToList();
        }

        #endregion Constructor

        #region Public Properties

        /// <inheritdoc/>
        public IReadOnlyList<ICard> Cards => this.CardList.ToList();

        private IList<ICard> CardList { get; }

        #endregion Properties

        #region Public Methods

        /// <inheritdoc/>
        public IList<ICard> Fold()
        {
            IList<ICard> foldedCards = this.Cards.ToList();
            this.CardList.Clear();
            return foldedCards;
        }

        #endregion Public Methods
    }
}