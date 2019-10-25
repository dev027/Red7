// <copyright file="IDeck.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Red7.Domain.DomainObjects.Cards;
using Red7.Domain.DomainObjects.Hands;
using Red7.Domain.DomainObjects.Palettes;

namespace Red7.Domain.DomainObjects.Decks
{
    /// <summary>
    /// Deck of cards.
    /// </summary>
    public interface IDeck
    {
        #region Public Properties

        /// <summary>
        /// Gets the Cards in the Deck.
        /// </summary>
        IReadOnlyList<ICard> Cards { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Deals a Hand from the Deck.
        /// </summary>
        /// <returns>Hand.</returns>
        IHand DealHand();

        /// <summary>
        /// Deals a Palette from the Deck.
        /// </summary>
        /// <returns>Palette.</returns>
        IPalette DealPalette();

        #endregion Public Methods
    }
}