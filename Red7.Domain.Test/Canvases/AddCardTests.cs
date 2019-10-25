// <copyright file="AddCardTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Axioms;
using Red7.Domain.DomainObjects.Canvases;
using Red7.Domain.DomainObjects.Cards;
using Red7.Domain.ValueObjects;

namespace Red7.Domain.Test.Canvases
{
    /// <summary>
    /// Test AddCard.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(Canvases) + "/" + nameof(Canvas.AddCard))]
    [TestClass]
    public class AddCardTests
    {
        /// <summary>
        /// Tests that calling AddCard once has just one card on the canvas,
        /// changing the current rule to match that card.
        /// </summary>
        [TestMethod]
        public void TestAddCardOnce()
        {
            // ARRANGE
            IAxiom axiom = new Axiom();
            ICanvas canvas = new Canvas(axiom);
            ICard card = new Card(Colour.Blue, Number.Four, axiom);

            // ACT
            canvas.AddCard(card);

            // ASSERT
            Assert.IsNotNull(canvas.Cards);
            Assert.AreEqual(expected: 1, canvas.Cards.Count);
            Assert.AreEqual(expected: Colour.Blue, canvas.CurrentRule.Colour);
        }

        /// <summary>
        /// Tests that calling AddCard twice has two cards on the canvas,
        /// changing the current rule to match the second card.
        /// </summary>
        [TestMethod]
        public void TestAddCardTwice()
        {
            // ARRANGE
            IAxiom axiom = new Axiom();
            ICanvas canvas = new Canvas(axiom);
            ICard card1 = new Card(Colour.Blue, Number.Four, axiom);
            ICard card2 = new Card(Colour.Yellow, Number.Four, axiom);

            // ACT
            canvas.AddCard(card1);
            canvas.AddCard(card2);

            // ASSERT
            Assert.IsNotNull(canvas.Cards);
            Assert.AreEqual(expected: 2, canvas.Cards.Count);
            Assert.AreEqual(expected: Colour.Yellow, canvas.CurrentRule.Colour);
        }

        /// <summary>
        /// Test that adding a Null card throws an ArgumentNullException.
        /// </summary>
        /// <exception cref="System.IO.IOException">Ignore.</exception>
        [TestMethod]
        public void TestAddNullCardThrowsArgumentNullException()
        {
            // ARRANGE
            IAxiom axiom = new Axiom();
            ICanvas canvas = new Canvas(axiom);

            // ACT
            ArgumentNullException argumentNullException = null;
            try
            {
                canvas.AddCard(null);
            }
            catch (ArgumentNullException ex)
            {
                argumentNullException = ex;
            }

            if (argumentNullException != null)
            {
                Console.WriteLine(argumentNullException.ToString());
            }

            // ASSERT
            Assert.IsNotNull(argumentNullException);
        }
    }
}