// <copyright file="ConstructorTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Axioms;
using Red7.Domain.DomainObjects.Canvases;
using Red7.Domain.DomainObjects.Cards;
using Red7.Domain.DomainObjects.Rules;
using Red7.Domain.ValueObjects;

namespace Red7.Domain.Test.Canvases
{
    /// <summary>
    /// Test Constructor.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(Canvases) + "/Constructor")]
    [TestClass]
    public class ConstructorTests
    {
        /// <summary>
        /// Tests the constructor.
        /// </summary>
        [TestMethod]
        public void TestConstructor()
        {
            // ARRANGE
            IAxiom axiom = new Axiom();

            // ACT
            ICanvas actualCanvas = new Canvas(axiom);

            // ASSERT
            Assert.IsNotNull(actualCanvas);
        }

        /// <summary>
        /// Tests that the initial current rule is axiom default rule.
        /// </summary>
        [TestMethod]
        public void TestInitialCurrentRuleIsAxiomDefaultRule()
        {
            // ARRANGE
            IAxiom axiom = new Axiom();
            Colour expectedColour = axiom.DefaultRule.Colour;

            // ACT
            ICanvas canvas = new Canvas(axiom);
            IRule actualCurrentRule = canvas.CurrentRule;

            // ASSERT
            Assert.IsNotNull(actualCurrentRule);
            Assert.AreEqual(expectedColour, actualCurrentRule.Colour);
        }

        /// <summary>
        /// Tests that the cards are empty.
        /// </summary>
        [TestMethod]
        public void TestCardsAreEmpty()
        {
            // ARRANGE
            IAxiom axiom = new Axiom();

            // ACT
            ICanvas canvas = new Canvas(axiom);
            IReadOnlyList<ICard> actualCards = canvas.Cards;

            // ASSERT
            Assert.IsNotNull(actualCards);
            Assert.IsFalse(actualCards.Any());
        }

        /// <summary>
        /// Test that creating a Canvas with a null axiom throws and exception.
        /// </summary>
        /// <exception cref="System.IO.IOException">Ignore.</exception>
        [TestMethod]
        public void ConstructorWithNullAxiom()
        {
            // ACT
            Exception actualArgumentNullException = null;
            ICanvas canvas = null;
            try
            {
                canvas = new Canvas(null);
            }
            catch (ArgumentNullException ex)
            {
                actualArgumentNullException = ex;
                Console.WriteLine(actualArgumentNullException);
            }

            // ASSERT
            Assert.IsNotNull(actualArgumentNullException);
            Assert.IsNull(canvas);
        }
    }
}