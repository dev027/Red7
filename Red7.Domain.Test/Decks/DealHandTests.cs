// <copyright file="DealHandTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Axioms;
using Red7.Domain.DomainObjects.Decks;
using Red7.Domain.DomainObjects.Hands;

namespace Red7.Domain.Test.Decks
{
    /// <summary>
    /// Test DealHand.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(Decks) + "/" + nameof(Deck.DealHand))]
    [TestClass]
    public class DealHandTests
    {
        /// <summary>
        /// Tests that dealing a hand creates a hand with the correct number of cards
        /// and that the deck has been shortened by that number of cards.
        /// </summary>
        [TestMethod]
        public void TestDealHand()
        {
            // ARRANGE
            IAxiom axiom = new Axiom();
            const int numberOfColours = 7;
            const int numberOfNumbers = 7;
            const int numberOfCardsInDeck = numberOfColours * numberOfNumbers;
            int expectedCardsLeftInDeck = numberOfCardsInDeck - axiom.InitialNumberOfCardsInHand;

            // ACT
            IDeck actualDeck = new Deck(axiom);
            IHand actualHand = actualDeck.DealHand();

            // ASSERT
            Assert.IsNotNull(actualHand);
            Assert.AreEqual(expected: axiom.InitialNumberOfCardsInHand, actualHand.Cards.Count);
            Assert.AreEqual(expectedCardsLeftInDeck, actualDeck.Cards.Count);
        }

        /// <summary>
        /// Tests the dealing with insufficient cards returns null hand.
        /// </summary>
        [TestMethod]
        public void TestDealingWithInsufficientCardsReturnsNullHand()
        {
            // ARRANGE
            IAxiom axiom = new Axiom();
            IDeck deck = new Deck(axiom);
            while (deck.Cards.Count >= axiom.InitialNumberOfCardsInHand)
            {
                deck.DealHand();
            }

            // ACT
            IHand actualHand = deck.DealHand();

            // ASSERT
            Assert.IsNull(actualHand);
        }
    }
}