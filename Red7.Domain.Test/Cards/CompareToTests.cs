// <copyright file="CompareToTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Axioms;
using Red7.Domain.DomainObjects.Cards;
using Red7.Domain.ValueObjects;

namespace Red7.Domain.Test.Cards
{
    /// <summary>
    /// Tests the CompareTo.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(Cards) + "/" + nameof(Card.CompareTo))]
    [TestClass]
    public class CompareToTests
    {
        /// <summary>
        /// Test that CompareTo works with various card and number combinations.
        /// </summary>
        /// <param name="cardColour">The other card colour.</param>
        /// <param name="cardNumber">The other card number.</param>
        /// <param name="expectedComparison">The expected comparison.</param>
        [TestMethod]
        [DataRow(Colour.Red, Number.Seven, -1, DisplayName = "Higher colour and number")]
        [DataRow(Colour.Red, Number.Four, -1, DisplayName = "Higher colour and same number")]
        [DataRow(Colour.Red, Number.One, -1, DisplayName = "Higher colour and lower number")]
        [DataRow(Colour.Blue, Number.Seven, -1, DisplayName = "Same colour and higher number")]
        [DataRow(Colour.Blue, Number.Four, 0, DisplayName = "Same colour and number")]
        [DataRow(Colour.Blue, Number.One, 1, DisplayName = "Same colour and lower number")]
        [DataRow(Colour.Violet, Number.Seven, 1, DisplayName = "Lower colour and higher number")]
        [DataRow(Colour.Violet, Number.Four, 1, DisplayName = "Lower colour and same number")]
        [DataRow(Colour.Violet, Number.One, 1, DisplayName = "Lower colour and number")]
        public void CompareCardTest(
            Colour cardColour,
            Number cardNumber,
            int expectedComparison)
        {
            // ARRANGE
            IAxiom axiom = new Axiom();
            ICard thisCard = new Card(Colour.Blue, Number.Four, axiom);
            ICard thatCard = new Card(cardColour, cardNumber, axiom);

            // ACT
            int actualComparison = thisCard.CompareTo(thatCard);

            // ASSERT
            Assert.AreEqual(expectedComparison, actualComparison);
        }
    }
}