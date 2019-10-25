// <copyright file="BlueRule.cs" company="Do It Wright">
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
    /// Blue rule - Most different colours.
    /// </summary>
    /// <seealso cref="IRule" />
    public class BlueRule : IRule
    {
        #region Public Propeties

        /// <summary>
        /// Gets the Description of the Rule.
        /// </summary>
        public string Description => "Most different colours wins";

        /// <summary>
        /// Gets the Colour of the Rule.
        /// </summary>
        public Colour Colour => Colour.Blue;

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the Score for the Rule from the Palette.
        /// </summary>
        /// <param name="palette">The Palette.</param>
        /// <returns>
        /// Score.
        /// </returns>
        public IRuleScore Score(IPalette palette)
        {
            if (palette == null)
            {
                throw new ArgumentNullException(nameof(palette));
            }

            // Count the number of unique colours in the Palette
            int colourCount = palette.Cards
                .Select(c => c.Colour)
                .Distinct()
                .Count();

            // Get the top card from the Palette for the tie-break
            // as this is always one of the scoring cards.
            ICard topCard = Card.TopCard(palette.Cards);

            return new RuleScore(colourCount, topCard);
        }

        /// <summary>
        /// Gets the Cards for the Palette that are Scoring.
        /// </summary>
        /// <param name="palette">The Palette.</param>
        /// <returns>
        /// List of Cards.
        /// </returns>
        public IList<ICard> ScoringCards(IPalette palette)
        {
            if (palette == null)
            {
                throw new ArgumentNullException(nameof(palette));
            }

            IList<Colour> uniqueColours = palette.Cards
                .Select(c => c.Colour)
                .Distinct()
                .ToList();

            IList<ICard> scoringCards = new List<ICard>(uniqueColours.Count);

            foreach (Colour uniqueColour in uniqueColours)
            {
                IList<ICard> cardsOfThisColour = palette.Cards
                    .Where(c => c.Colour == uniqueColour)
                    .ToList();

                ICard topCardOfThisColour = Card.TopCard(cardsOfThisColour);

                scoringCards.Add(topCardOfThisColour);
            }

            return scoringCards;
        }

        #endregion
    }
}