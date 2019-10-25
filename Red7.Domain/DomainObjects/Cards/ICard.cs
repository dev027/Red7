// <copyright file="ICard.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using Red7.Domain.DomainObjects.Rules;
using Red7.Domain.ValueObjects;

namespace Red7.Domain.DomainObjects.Cards
{
    /// <summary>
    /// Card.
    /// </summary>
    public interface ICard : IComparable<ICard>
    {
        /// <summary>
        /// Gets Card Colour.
        /// </summary>
        Colour Colour { get; }

        /// <summary>
        /// Gets Card Number.
        /// </summary>
        Number Number { get; }

        /// <summary>
        /// Gets the Rule associated with the card.
        /// </summary>
        IRule Rule { get; }
    }
}