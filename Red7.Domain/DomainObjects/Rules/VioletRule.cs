// <copyright file="VioletRule.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Red7.Domain.DomainObjects.Cards;
using Red7.Domain.DomainObjects.Palettes;
using Red7.Domain.ValueObjects;
using Red7.Domain.ValueObjects.RuleScores;

namespace Red7.Domain.DomainObjects.Rules
{
    /// <summary>
    /// The Violet Rule - Most cards below a 4.
    /// </summary>
    public class VioletRule : IRule
    {
        /// <inheritdoc/>
        public string Description => "Most cards below 4 wins";

        /// <inheritdoc/>
        public Colour Colour => Colour.Violet;

        /// <inheritdoc/>
        public IRuleScore Score(IPalette palette)
        {
            if (palette == null)
            {
                throw new ArgumentNullException(nameof(palette));
            }

            IList<ICard> cardsThatMatchRule = palette.Cards
                .Where(c => c.Number < Number.Four)
                .ToList();

            ICard topCard = Card.TopCard(cardsThatMatchRule);

            return new RuleScore(cardsThatMatchRule.Count, topCard);
        }

        /// <inheritdoc/>
        public IList<ICard> ScoringCards(IPalette palette)
        {
            throw new NotImplementedException();
        }
    }
}