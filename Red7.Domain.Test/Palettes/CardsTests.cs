// <copyright file="CardsTests.cs" company="Do It Wright">
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
    /// Test AddCards().
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(Palette) + "/" + nameof(Palette.Cards))]
    [TestClass]
    public class CardsTests
    {
        /// <summary>
        /// Tests that  cards property returns all the cards.
        /// </summary>
        [TestMethod]
        public void TestCardsPropertyReturnsAllTheCards()
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
            IReadOnlyList<ICard> actualCards = palette.Cards;

            // ASSERT
            Assert.AreEqual(expected: cards.Count, actualCards.Count);
            foreach (ICard card in cards)
            {
                bool found = actualCards.Any(c => c.CompareTo(card) == 0);
                Assert.IsTrue(found, card.ToString());
            }
        }
    }
}