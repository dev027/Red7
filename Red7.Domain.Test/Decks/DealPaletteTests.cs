// <copyright file="DealPaletteTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Axioms;
using Red7.Domain.DomainObjects.Decks;
using Red7.Domain.DomainObjects.Palettes;

namespace Red7.Domain.Test.Decks
{
    /// <summary>
    /// Test DealPalette.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(Decks) + "/" + nameof(Deck.DealPalette))]
    [TestClass]
    public class DealPaletteTests
    {
        /// <summary>
        /// Tests that dealing a palette creates a palette with the correct number of cards
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
            int expectedCardsLeftInDeck = numberOfCardsInDeck - axiom.InitialNumberOfCardsInPalette;

            // ACT
            IDeck actualDeck = new Deck(axiom);
            IPalette actualPalette = actualDeck.DealPalette();

            // ASSERT
            Assert.IsNotNull(actualPalette);
            Assert.AreEqual(expected: axiom.InitialNumberOfCardsInPalette, actualPalette.Cards.Count);
            Assert.AreEqual(expectedCardsLeftInDeck, actualDeck.Cards.Count);
        }
    }
}