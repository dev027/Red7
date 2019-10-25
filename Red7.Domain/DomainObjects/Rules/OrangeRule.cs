// <copyright file="OrangeRule.cs" company="Do It Wright">
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
    /// Orange Rule - Most of one number.
    /// </summary>
    /// <seealso cref="Red7.Domain.DomainObjects.Rules.IRule" />
    public class OrangeRule : IRule
    {
        #region Public Properties

        /// <inheritdoc/>
        public string Description => "Most of one number wins";

        /// <inheritdoc/>
        public Colour Colour => Colour.Orange;

        #endregion Public Properties

        #region Public Properties

        /// <inheritdoc/>
        public IRuleScore Score(IPalette palette)
        {
            if (palette == null)
            {
                throw new ArgumentNullException(nameof(palette));
            }

            // Any number will do as long as the popularity is zero
            Number mostPopularNumber = Number.One;
            int popularity = 0;

            IList<Number> paletteNumbers = palette.Cards
                .Select(c => c.Number)
                .Distinct()
                .ToList();

            // Find the most popular number in the Palette.
            foreach (Number number in paletteNumbers)
            {
                int thisPopularity = palette.Cards.Count(card => card.Number == number);
                if (thisPopularity > popularity)
                {
                    mostPopularNumber = number;
                    popularity = thisPopularity;
                }
            }

            // Find all the cards in the Palette that match this Number
            IList<ICard> cardsThatMatchRule = palette.Cards
                .Where(c => c.Number == mostPopularNumber)
                .ToList();

            ICard topCard = Card.TopCard(cardsThatMatchRule);

            return new RuleScore(popularity, topCard);
        }

        /// <inheritdoc />
        public IList<ICard> ScoringCards(IPalette palette)
        {
            if (palette == null)
            {
                throw new ArgumentNullException(nameof(palette));
            }

            IRuleScore ruleScore = this.Score(palette);

            return palette.Cards
                .Where(c => c.Number == ruleScore.TopCard.Number)
                .ToList();
        }

        #endregion Public Properties
    }
}