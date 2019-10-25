// <copyright file="IRuleScore.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using Red7.Domain.DomainObjects.Cards;

namespace Red7.Domain.ValueObjects.RuleScores
{
    /// <summary>
    /// Score for a Rule.
    /// </summary>
    public interface IRuleScore : IComparable<IRuleScore>
    {
        #region Public Properties

        /// <summary>
        /// Gets the Number of Cards that are scoring.
        /// </summary>
        int NumberOfCards { get; }

        /// <summary>
        /// Gets the Top Card of those that are Scoring.
        /// </summary>
        ICard TopCard { get; }

        #endregion
    }
}