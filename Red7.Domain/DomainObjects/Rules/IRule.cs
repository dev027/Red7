// <copyright file="IRule.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Red7.Domain.DomainObjects.Cards;
using Red7.Domain.DomainObjects.Palettes;
using Red7.Domain.ValueObjects;
using Red7.Domain.ValueObjects.RuleScores;

namespace Red7.Domain.DomainObjects.Rules
{
    /// <summary>
    /// Rules.
    /// </summary>
    public interface IRule
    {
        #region Public Properties

        /// <summary>
        /// Gets the Description of the Rule.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the Colour of the Rule.
        /// </summary>
        Colour Colour { get; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the Score for the Rule from the Palette.
        /// </summary>
        /// <param name="palette">The Palette.</param>
        /// <returns>Score.</returns>
        IRuleScore Score(IPalette palette);

        /// <summary>
        /// Gets the Cards for the Palette that are Scoring.
        /// </summary>
        /// <param name="palette">The Palette.</param>
        /// <returns>List of Cards.</returns>
        IList<ICard> ScoringCards(IPalette palette);

        #endregion
    }
}