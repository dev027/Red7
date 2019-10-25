// <copyright file="GreenRule.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Red7.Domain.DomainObjects.Axioms;
using Red7.Domain.DomainObjects.Cards;
using Red7.Domain.DomainObjects.Palettes;
using Red7.Domain.ValueObjects;
using Red7.Domain.ValueObjects.RuleScores;

namespace Red7.Domain.DomainObjects.Rules
{
    /// <summary>
    /// Green rule - Most even cards.
    /// </summary>
    /// <seealso cref="IRule" />
    public class GreenRule : IRule
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GreenRule"/> class.
        /// </summary>
        /// <param name="axiom">The axiom.</param>
        public GreenRule(IAxiom axiom)
        {
            if (axiom == null)
            {
                throw new ArgumentNullException(nameof(axiom));
            }

            this.EvenNumbers = axiom.EvenNumbers;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the Description of the Rule.
        /// </summary>
        public string Description => "Most even cards wins";

        /// <summary>
        /// Gets the Colour of the Rule.
        /// </summary>
        public Colour Colour => Colour.Green;

        #endregion

        #region Private Properties

        /// <summary>
        /// Gets the list of even numbers.
        /// </summary>
        private IReadOnlyList<Number> EvenNumbers { get; }

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

            IList<ICard> cardsThatMatchRule = palette.Cards
                .Where(c => this.EvenNumbers.Contains(c.Number))
                .ToList();

            ICard topCard = Card.TopCard(cardsThatMatchRule);

            return new RuleScore(cardsThatMatchRule.Count, topCard);
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

            IList<ICard> cardsThatMatchRule = palette.Cards
                .Where(c => this.EvenNumbers.Contains(c.Number))
                .ToList();

            return cardsThatMatchRule;
        }

        #endregion
    }
}