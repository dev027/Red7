// <copyright file="FoldTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Axioms;
using Red7.Domain.DomainObjects.Cards;
using Red7.Domain.DomainObjects.Hands;
using Red7.Domain.ValueObjects;

namespace Red7.Domain.Test.Hands
{
    /// <summary>
    /// Test Fold.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(Hands) + "/" + nameof(Hand.Fold))]
    [TestClass]
    public class FoldTests
    {
        /// <summary>
        /// Tests that fold returns the correct cards and that the hand
        /// no longer has any cards remaining.
        /// </summary>
        [TestMethod]
        public void TestFoldReturnsCorrectCards()
        {
            // ARRANGE
            IAxiom axiom = new Axiom();
            IList<ICard> cards = new List<ICard>
            {
                new Card(Colour.Red, Number.Seven, axiom),
                new Card(Colour.Blue, Number.Five, axiom),
                new Card(Colour.Green, Number.Two, axiom),
            };
            IHand hand = new Hand(cards);

            // ACT
            IList<ICard> actualFoldedCards = hand.Fold();

            // ASSERT
            Assert.IsNotNull(actualFoldedCards);
            Assert.IsNotNull(hand.Cards);
            Assert.AreEqual(expected: 3, actualFoldedCards.Count);
            Assert.AreEqual(expected: 0, hand.Cards.Count);
        }
    }
}