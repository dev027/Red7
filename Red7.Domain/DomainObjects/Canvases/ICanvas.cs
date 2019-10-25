// <copyright file="ICanvas.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Red7.Domain.DomainObjects.Cards;
using Red7.Domain.DomainObjects.Rules;

namespace Red7.Domain.DomainObjects.Canvases
{
    /// <summary>
    /// Canvas.
    /// </summary>
    public interface ICanvas
    {
        /// <summary>
        /// Gets the Current Rule.
        /// </summary>
        /// <exception cref="InvalidOperationException">Get. Ignore.</exception>
        IRule CurrentRule { get; }

        /// <summary>
        /// Gets cards discarded to the canvas.
        /// </summary>
        IReadOnlyList<ICard> Cards { get; }

        /// <summary>
        /// Add a card to the Canvas.
        /// </summary>
        /// <param name="card">Card to be added.</param>
        void AddCard(ICard card);
    }
}