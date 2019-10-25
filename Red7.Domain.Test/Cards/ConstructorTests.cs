// <copyright file="ConstructorTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Axioms;
using Red7.Domain.DomainObjects.Cards;
using Red7.Domain.ValueObjects;

namespace Red7.Domain.Test.Cards
{
    /// <summary>
    /// Test the Constructor.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(Cards) + "/Constructor")]
    [TestClass]
    public class ConstructorTests
    {
        /// <summary>
        /// Tests the constructor with various colour and number combinations.
        /// </summary>
        /// <param name="cardColour">The card colour.</param>
        /// <param name="cardNumber">The card number.</param>
        [TestMethod]
        [DataRow(Colour.Red, Number.Three)]
        [DataRow(Colour.Orange, Number.Five)]
        [DataRow(Colour.Yellow, Number.Seven)]
        [DataRow(Colour.Green, Number.One)]
        [DataRow(Colour.Blue, Number.Four)]
        [DataRow(Colour.Indigo, Number.Six)]
        [DataRow(Colour.Violet, Number.Two)]
        public void TestConstructor(Colour cardColour, Number cardNumber)
        {
            // ARRANGE
            IAxiom axiom = new Axiom();

            // ACT
            ICard actualCard = new Card(cardColour, cardNumber, axiom);

            // ASSERT
            Assert.AreEqual(cardColour, actualCard.Colour);
            Assert.AreEqual(cardNumber, actualCard.Number);
            Assert.AreEqual(cardColour, actualCard.Rule.Colour);
        }
    }
}