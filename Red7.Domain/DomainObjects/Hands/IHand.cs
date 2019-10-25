// <copyright file="IHand.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Red7.Domain.DomainObjects.Cards;

namespace Red7.Domain.DomainObjects.Hands
{
    /// <summary>
    /// Player's hand.
    /// </summary>
    public interface IHand
    {
        #region Public Properties

        /// <summary>
        /// Gets cards that make up the hand.
        /// </summary>
        IReadOnlyList<ICard> Cards { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Fold the current hand.
        /// </summary>
        /// <returns>List of folded cards.</returns>
        IList<ICard> Fold();

        #endregion Public Methods
    }
}