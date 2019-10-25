// <copyright file="RedRule.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Red7.Domain.DomainObjects.Cards;
using Red7.Domain.DomainObjects.Palettes;
using Red7.Domain.ValueObjects;
using Red7.Domain.ValueObjects.RuleScores;

namespace Red7.Domain.DomainObjects.Rules
{
    /// <summary>
    /// The Red Rule - Highest Card.
    /// </summary>
    public class RedRule : IRule
    {
        #region Public Properties

        /// <inheritdoc/>
        public string Description => "Highest card wins";

        /// <inheritdoc/>
        public Colour Colour => Colour.Red;

        #endregion Public Properties

        #region Public Methods

        /// <inheritdoc/>
        public IRuleScore Score(IPalette palette)
        {
            if (palette == null)
            {
                throw new ArgumentNullException(nameof(palette));
            }

            ICard topCard = Card.TopCard(palette.Cards);
            return new RuleScore(numberOfCards: 1, topCard: topCard);
        }

        /// <inheritdoc/>
        public IList<ICard> ScoringCards(IPalette palette)
        {
            if (palette == null)
            {
                throw new ArgumentNullException(nameof(palette));
            }

            return new List<ICard>
            {
                Card.TopCard(palette.Cards)
            };
        }

        #endregion Public Methods
    }
}