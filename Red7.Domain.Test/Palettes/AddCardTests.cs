// <copyright file="AddCardTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
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
    /// Test AddCard().
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(Palette) + "/" + nameof(Palette.AddCard))]
    [TestClass]
    public class AddCardTests
    {
        /// <summary>
        /// Test that AddCard adds the cards to the palette.
        /// </summary>
        [TestMethod]
        public void TestAddCardAddsTheCardToThePalette()
        {
            // ARRANGE
            IAxiom axiom = new Axiom();
            IList<ICard> cards = new List<ICard>
            {
                new Card(Colour.Orange, Number.Three, axiom),
                new Card(Colour.Blue, Number.Seven, axiom),
                new Card(Colour.Red, Number.One, axiom)
            };
            ICard card = new Card(Colour.Violet, Number.Four, axiom);
            IPalette palette = new Palette(cards);

            // ACT
            palette.AddCard(card);

            // ASSERT
            Assert.AreEqual(expected: cards.Count + 1, actual: palette.Cards.Count);

            bool found = palette.Cards
                .Where(c => c.Colour == card.Colour)
                .Any(c => c.Number == card.Number);
            Assert.IsTrue(found, "Card exists");
        }

        /// <summary>
        /// Test that adding a null card throws an exception.
        /// </summary>
        /// <exception cref="System.IO.IOException">Ignore.</exception>
        [TestMethod]
        public void TestAddNullCardThrowsAnException()
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
            ArgumentNullException argumentNullException = null;
            try
            {
                palette.AddCard(null);
            }
            catch (ArgumentNullException ex)
            {
                argumentNullException = ex;
            }

            // ASSERT
            if (argumentNullException != null)
            {
                Console.WriteLine(argumentNullException.ToString());
            }

            Assert.IsNotNull(argumentNullException, "Expected exception not thrown");
        }

        /// <summary>
        /// Test that adding a duplicate card throws an exception.
        /// </summary>
        /// <exception cref="System.IO.IOException">Ignore.</exception>
        [TestMethod]
        public void TestAddDuplicateCardThrowsAnException()
        {
            // ARRANGE
            IAxiom axiom = new Axiom();
            IList<ICard> cards = new List<ICard>
            {
                new Card(Colour.Orange, Number.Three, axiom),
                new Card(Colour.Blue, Number.Seven, axiom),
                new Card(Colour.Red, Number.One, axiom)
            };
            ICard duplicateCard = new Card(Colour.Orange, Number.Three, axiom);
            IPalette palette = new Palette(cards);

            // ACT
            ArgumentException argumentException = null;
            try
            {
                palette.AddCard(duplicateCard);
            }
            catch (ArgumentException ex)
            {
                argumentException = ex;
            }

            // ASSERT
            if (argumentException != null)
            {
                Console.WriteLine(argumentException.ToString());
            }

            Assert.IsNotNull(argumentException, "Expected exception not thrown");
        }
    }
}