// <copyright file="YellowRule.cs" company="Do It Wright">
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
    /// Yellow rule - Most of one colour.
    /// </summary>
    /// <seealso cref="IRule" />
    public class YellowRule : IRule
    {
        #region Public Properties

        /// <inheritdoc/>
        public string Description => "Most of one colour wins";

        /// <inheritdoc/>
        public Colour Colour => Colour.Yellow;

        #endregion Public Properties

        #region Public Methods

        /// <inheritdoc />
        public IRuleScore Score(IPalette palette)
        {
            if (palette == null)
            {
                throw new ArgumentNullException(nameof(palette));
            }

            // Any colour will do, as long as we set the popularity to zero
            Colour mostPopularColour = Colour.Violet;
            int popularity = 0;

            // Get list of unique colours in the Palette
            IList<Colour> paletteColours = palette.Cards
                .Select(c => c.Colour)
                .Distinct()
                .ToList();

            // Find out which colour is the most popular
            foreach (Colour colour in paletteColours)
            {
                int thisPopularity = palette.Cards.Count(card => card.Colour == colour);
                if (thisPopularity > popularity)
                {
                    mostPopularColour = colour;
                    popularity = thisPopularity;
                }
            }

            // Select all the Cards in the Palette that match this Colour
            IList<ICard> cardsThatMatchRule = palette.Cards
                .Where(c => c.Colour == mostPopularColour)
                .ToList();

            ICard topCard = Card.TopCard(cardsThatMatchRule);

            return new RuleScore(popularity, topCard);
        }

        /// <inheritdoc/>
        public IList<ICard> ScoringCards(IPalette palette)
        {
            IRuleScore ruleScore = this.Score(palette);

            return palette.Cards
                .Where(c => c.Colour == ruleScore.TopCard.Colour)
                .ToList();
        }

        #endregion Public Methods
    }
}