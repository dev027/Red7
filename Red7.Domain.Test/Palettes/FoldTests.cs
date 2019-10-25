// <copyright file="FoldTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Axioms;
using Red7.Domain.DomainObjects.Cards;
using Red7.Domain.DomainObjects.Palettes;
using Red7.Domain.ValueObjects;

namespace Red7.Domain.Test.Palettes
{
    /// <summary>
    /// Test Fold().
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(Palette) + "/" + nameof(Palette.Fold))]
    [TestClass]
    public class FoldTests
    {
        /// <summary>
        /// Tests that folding returns folded cards and clears the cards property.
        /// </summary>
        [TestMethod]
        public void TestFoldingReturnsFoldedCardsAndClearsTheCardsProperty()
        {
            // ARRANGE
            IAxiom axiom = new Axiom();
            IList<ICard> cards = new List<ICard>
            {
                new Card(Colour.Orange, Number.Three, axiom),
                new Card(Colour.Blue, Number.Seven, axiom),
                new Card(Colour.Red, Number.One, axiom)
            };
            IPalette palette = new Palette(cards);

            // ACT
            IList<ICard> foldedCards = palette.Fold();

            // ASSERT
            Assert.IsNotNull(palette.Cards, "palette.Cards != null");
            Assert.IsFalse(palette.Cards.Any(), "palette.Cards.Any()");

            Assert.IsNotNull(foldedCards, "foldedCards != null");
            Assert.AreEqual(expected: cards.Count, actual: foldedCards.Count);
            foreach (ICard card in cards)
            {
                bool found = foldedCards.Any(c => c.CompareTo(card) == 0);
                Assert.IsTrue(found, card.ToString());
            }
        }
    }
}