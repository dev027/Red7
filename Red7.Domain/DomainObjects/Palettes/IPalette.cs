// <copyright file="IPalette.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Red7.Domain.DomainObjects.Cards;

namespace Red7.Domain.DomainObjects.Palettes
{
    /// <summary>
    /// The Palette is collection of cards that a player plays in order to score.
    /// </summary>
    public interface IPalette
    {
        #region Public Properties

        /// <summary>
        /// Gets the Cards in the Palette.
        /// </summary>
        IReadOnlyList<ICard> Cards { get; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds a Card to the Palette.
        /// </summary>
        /// <param name="card">Card to add.</param>
        void AddCard(ICard card);

        /// <summary>
        /// Folds this Palette.
        /// </summary>
        /// <returns>List of cards that were folded.</returns>
        IList<ICard> Fold();

        #endregion
    }
}