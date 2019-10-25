// <copyright file="IndigoRule.cs" company="Do It Wright">
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
using Red7.Domain.ValueObjects.Runs;

namespace Red7.Domain.DomainObjects.Rules
{
    /// <summary>
    /// Indigo rule - Most cards in a run.
    /// </summary>
    public class IndigoRule : IRule
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="IndigoRule"/> class.
        /// </summary>
        /// <param name="axiom">Axiom.</param>
        public IndigoRule(IAxiom axiom)
        {
            if (axiom == null)
            {
                throw new ArgumentNullException(nameof(axiom));
            }

            this.Runs = axiom.Runs;
        }

        #endregion Constructors

        #region Public Properties

        /// <inheritdoc/>
        public string Description => "Most cards in a run";

        /// <inheritdoc/>
        public Colour Colour => Colour.Indigo;

        #endregion Public Properties

        #region Private Properties

        /// <summary>
        /// Gets the List of Runs.
        /// </summary>
        private IReadOnlyList<IRun> Runs { get; }

        #endregion Private Properties

        #region Public Methods

        /// <inheritdoc/>
        public IRuleScore Score(IPalette palette)
        {
            if (palette == null)
            {
                throw new ArgumentNullException(nameof(palette));
            }

            List<Number> paletteNumbers = palette.Cards
                .Select(c => c.Number)
                .Distinct()
                .ToList();

            // Runs are sorted into highest Run first
            // Find first Run that matches the Palette
            foreach (IRun run in this.Runs)
            {
                // Check that the Palette contains all the Numbers in the Run
                if (run.Numbers.TakeWhile(n => paletteNumbers.Contains(n)).Count() == run.Length)
                {
                    Number topNumberInRun = run.Numbers.Max();

                    IList<ICard> cardsThatMatchRule = palette.Cards
                        .Where(c => c.Number == topNumberInRun)
                        .ToList();

                    ICard topCard = Card.TopCard(cardsThatMatchRule);

                    return new RuleScore(run.Length, topCard);
                }
            }

            // If we reach here then we have no Runs
            return new RuleScore(1, Card.TopCard(palette.Cards));
        }

        /// <inheritdoc/>
        public IList<ICard> ScoringCards(IPalette palette)
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}