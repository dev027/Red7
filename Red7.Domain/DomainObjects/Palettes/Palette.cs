// <copyright file="Palette.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Red7.Domain.DomainObjects.Cards;
using Red7.Domain.Resources;

namespace Red7.Domain.DomainObjects.Palettes
{
    /// <summary>
    /// The Palette is collection of cards that a player plays in order to score.
    /// </summary>
    public class Palette : IPalette
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Palette"/> class.
        /// </summary>
        /// <param name="cards">Initial list of Cards in the Palette.</param>
        public Palette(IList<ICard> cards)
        {
            if (!cards.Any())
            {
                throw new ArgumentException(ExceptionResource.CardListCannotBeEmpty, nameof(cards));
            }

            this.CardList = cards.ToList();
        }

        #endregion Constructors

        #region Public Properties

        /// <inheritdoc/>
        public IReadOnlyList<ICard> Cards => (IReadOnlyList<ICard>)this.CardList;

        #endregion Public Properties

        #region Private Properties

        /// <summary>
        /// Gets the internal list of Cards in the palette,.
        /// </summary>
        private IList<ICard> CardList { get; }

        #endregion Private Properties

        #region Public Methods

        /// <inheritdoc/>
        public void AddCard(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            bool isDuplicate = this.Cards.Any(c => c.CompareTo(card) == 0);
            if (isDuplicate)
            {
                throw new ArgumentException(ExceptionResource.DuplicateCard);
            }

            this.CardList.Add(card);
        }

        /// <inheritdoc/>
        public IList<ICard> Fold()
        {
            IList<ICard> foldedCards = this.CardList.ToList();
            this.CardList.Clear();

            return foldedCards;
        }

        #endregion Public Methods
    }
}