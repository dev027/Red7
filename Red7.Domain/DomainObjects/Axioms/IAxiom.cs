// <copyright file="IAxiom.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Red7.Domain.DomainObjects.Rules;
using Red7.Domain.ValueObjects;
using Red7.Domain.ValueObjects.Runs;

namespace Red7.Domain.DomainObjects.Axioms
{
    /// <summary>
    /// Game axioms.
    /// </summary>
    public interface IAxiom
    {
        /// <summary>
        /// Gets initial number of Cards in a Hand.
        /// </summary>
        int InitialNumberOfCardsInHand { get; }

        /// <summary>
        /// Gets initial number of Cards in a Palette.
        /// </summary>
        int InitialNumberOfCardsInPalette { get; }

        /// <summary>
        /// Gets the highest numbered card in a suit.
        /// </summary>
        int HighestCardNumber { get; }

        /// <summary>
        /// Gets the lowest numbers card in a suit.
        /// </summary>
        int LowestCardNumber { get; }

        /// <summary>
        /// Gets list of run permutations, with the highest being first.
        /// </summary>
        IReadOnlyList<IRun> Runs { get; }

        /// <summary>
        /// Gets list of even Numbers.
        /// </summary>
        IReadOnlyList<Number> EvenNumbers { get; }

        /// <summary>
        /// Gets the Red Rule.
        /// </summary>
        IRule RedRule { get; }

        /// <summary>
        /// Gets the Orange Rule.
        /// </summary>
        IRule OrangeRule { get; }

        /// <summary>
        /// Gets the Yellow Rule.
        /// </summary>
        IRule YellowRule { get; }

        /// <summary>
        /// Gets the Green Rule.
        /// </summary>
        IRule GreenRule { get; }

        /// <summary>
        /// Gets the Blue Rule.
        /// </summary>
        IRule BlueRule { get; }

        /// <summary>
        /// Gets the Indigo Rule.
        /// </summary>
        IRule IndigoRule { get; }

        /// <summary>
        /// Gets the Violet Rule.
        /// </summary>
        IRule VioletRule { get; }

        /// <summary>
        /// Gets the default rule to start the Canvas with.
        /// </summary>
        IRule DefaultRule { get; }

        /// <summary>
        /// Get the rule associated with this Colour.
        /// </summary>
        /// <param name="colour">Colour.</param>
        /// <returns>Rule.</returns>
        /// <exception cref="InvalidOperationException">Ignore.</exception>
        IRule GetRule(Colour colour);
    }
}