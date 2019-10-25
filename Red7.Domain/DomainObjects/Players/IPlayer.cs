// <copyright file="IPlayer.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Red7.Domain.DomainObjects.Cards;
using Red7.Domain.DomainObjects.Hands;
using Red7.Domain.DomainObjects.Palettes;

namespace Red7.Domain.DomainObjects.Players
{
    /// <summary>
    /// Player.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Gets the Player's Name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the Hand.
        /// </summary>
        IHand Hand { get; }

        /// <summary>
        /// Gets the Palette.
        /// </summary>
        IPalette Palette { get; }

        /// <summary>
        /// Gets the list of Cards that are scoring.
        /// </summary>
        IReadOnlyList<ICard> ScoringCards { get; }

        /// <summary>
        /// Gets the Player's Score.
        /// </summary>
        int Score { get; }

        /// <summary>
        /// Gets the list of Folded Cards.
        /// </summary>
        IReadOnlyList<ICard> FoldedCards { get; }

        /// <summary>
        /// Gets a value indicating whether get a value indicating whether the Player has Folded.
        /// </summary>
        bool HasFolded { get; }

        /// <summary>
        /// Folds the Player's Hand.
        /// </summary>
        void Fold();
    }
}