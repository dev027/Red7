// <copyright file="Canvas.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Red7.Domain.DomainObjects.Axioms;
using Red7.Domain.DomainObjects.Cards;
using Red7.Domain.DomainObjects.Rules;

namespace Red7.Domain.DomainObjects.Canvases
{
    /// <summary>
    /// Canvas.
    /// </summary>
    public class Canvas : ICanvas
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Canvas"/> class.
        /// </summary>
        /// <param name="axiom">Game axioms.</param>
        public Canvas(IAxiom axiom)
        {
            if (axiom == null)
            {
                throw new ArgumentNullException(nameof(axiom));
            }

            // Canvas is empty of cards
            this.CardList = new List<ICard>();

            // Default rule to start the game with
            this.DefaultRule = axiom.DefaultRule;
        }

        #endregion Constructor

        #region Public Properties

        /// <summary>
        /// Gets the Current Rule.
        /// </summary>
        /// <exception cref="InvalidOperationException">Get. Ignore.</exception>
        public IRule CurrentRule => this.CardList.Any()
            ? this.CardList.Last().Rule
            : this.DefaultRule;

        /// <summary>
        /// Gets cards discarded to the canvas.
        /// </summary>
        public IReadOnlyList<ICard> Cards => (IReadOnlyList<ICard>)this.CardList;

        #endregion Public Properties

        #region Private Members

        /// <summary>
        /// Gets default rule to use when the canvas is empty.
        /// </summary>
        private IRule DefaultRule { get; }

        /// <summary>
        /// Gets internal list of cards in the canvas.
        /// </summary>
        private IList<ICard> CardList { get; }

        #endregion Private Members

        #region Public Methods

        /// <summary>
        /// Add a card to the Canvas.
        /// </summary>
        /// <param name="card">Card to be added.</param>
        public void AddCard(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            this.CardList.Add(card);
        }

        #endregion Public Methods
    }
}