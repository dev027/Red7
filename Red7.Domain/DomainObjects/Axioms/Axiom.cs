// <copyright file="Axiom.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Red7.Domain.DomainObjects.Rules;
using Red7.Domain.ValueObjects;
using Red7.Domain.ValueObjects.Runs;

namespace Red7.Domain.DomainObjects.Axioms
{
    /// <summary>
    /// Game axioms.
    /// </summary>
    public class Axiom : IAxiom
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Axiom"/> class.
        /// </summary>
        public Axiom()
        {
            // Create the Run permutations highest run first
            // The order is Run length, then highest Number in the Run
            IList<IRun> runs = new List<IRun>();

            for (var runLength = this.HighestCardNumber; runLength >= 2; runLength--)
            {
                int end = this.HighestCardNumber;
                int start = end - runLength + 1;
                for (; start >= this.LowestCardNumber; start--, end--)
                {
                    Number startNumber = (Number)start;
                    Number endNumber = (Number)end;
                    runs.Add(new Run(startNumber, endNumber));
                }
            }

            this.Runs = runs.ToList();

            // Define the Even numbers
            this.EvenNumbers = new List<Number>
            {
                Number.Six,
                Number.Four,
                Number.Two,
            };

            // Create the rules
            this.RedRule = new RedRule();
            this.OrangeRule = new OrangeRule();
            this.YellowRule = new YellowRule();
            this.GreenRule = new GreenRule(this);
            this.BlueRule = new BlueRule();
            this.IndigoRule = new IndigoRule(this);
            this.VioletRule = new VioletRule();

            // Create a list of all the rules
            this.Rules = new List<IRule>
            {
                this.RedRule, this.OrangeRule, this.YellowRule, this.GreenRule,
                this.BlueRule, this.IndigoRule, this.VioletRule,
            };
        }

        #endregion Constructors

        #region Public Properties

        /// <summary>
        /// Gets initial number of Cards in a Hand.
        /// </summary>
        public int InitialNumberOfCardsInHand => 7;

        /// <summary>
        /// Gets initial number of Cards in a Palette.
        /// </summary>
        public int InitialNumberOfCardsInPalette => 1;

        /// <summary>
        /// Gets the highest numbered card in a suit.
        /// </summary>
        public int HighestCardNumber => 7;

        /// <summary>
        /// Gets the lowest numbers card in a suit.
        /// </summary>
        public int LowestCardNumber => 1;

        /// <summary>
        /// Gets list of run permutations, with the highest being first.
        /// </summary>
        public IReadOnlyList<IRun> Runs { get; }

        /// <summary>
        /// Gets list of even Numbers.
        /// </summary>
        public IReadOnlyList<Number> EvenNumbers { get; }

        /// <summary>
        /// Gets the Red Rule.
        /// </summary>
        public IRule RedRule { get; }

        /// <summary>
        /// Gets the Orange Rule.
        /// </summary>
        public IRule OrangeRule { get; }

        /// <summary>
        /// Gets the Yellow Rule.
        /// </summary>
        public IRule YellowRule { get; }

        /// <summary>
        /// Gets the Green Rule.
        /// </summary>
        public IRule GreenRule { get; }

        /// <summary>
        /// Gets the Blue Rule.
        /// </summary>
        public IRule BlueRule { get; }

        /// <summary>
        /// Gets the Indigo Rule.
        /// </summary>
        public IRule IndigoRule { get; }

        /// <summary>
        /// Gets the Violet Rule.
        /// </summary>
        public IRule VioletRule { get; }

        /// <summary>
        /// Gets the default rule to start the Canvas with.
        /// </summary>
        public IRule DefaultRule => this.RedRule;

        /// <summary>
        /// Gets the list of all the rules.
        /// </summary>
        private IReadOnlyList<IRule> Rules { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Get the rule associated with this Colour.
        /// </summary>
        /// <param name="colour">Colour.</param>
        /// <returns>Rule.</returns>
        /// <exception cref="InvalidOperationException">Ignore.</exception>
        public IRule GetRule(Colour colour)
        {
            return this.Rules.Single(r => r.Colour == colour);
        }

        #endregion Public Methods
    }
}