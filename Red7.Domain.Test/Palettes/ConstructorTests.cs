// <copyright file="ConstructorTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
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
    [TestCategory(nameof(Domain) + "/" + nameof(Palette) + "/Constructor")]
    [TestClass]
    public class ConstructorTests
    {
        /// <summary>
        /// Tests the constructor with valid list of cards.
        /// </summary>
        [TestMethod]
        public void TestConstructorWithValidListOfCards()
        {
            // ARRANGE
            IAxiom axiom = new Axiom();
            IList<ICard> cards = new List<ICard>
            {
                new Card(Colour.Orange, Number.Three, axiom),
                new Card(Colour.Blue, Number.Seven, axiom),
                new Card(Colour.Red, Number.One, axiom)
            };

            // ACT
            IPalette actualPalette = new Palette(cards);

            // ASSERT
            Assert.IsNotNull(actualPalette);
        }

        /// <summary>
        /// Tests that the constructor with null list of cards throws exception.
        /// </summary>
        /// <exception cref="System.IO.IOException">Ignore.</exception>
        [TestMethod]
        public void TestConstructorWithNullListOfCardsThrowsException()
        {
            // ACT
            ArgumentNullException argumentNullException = null;
            IPalette palette = null;
            try
            {
                palette = new Palette(null);
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

            Assert.IsNotNull(argumentNullException, "argumentNullException != null");
            Assert.IsNull(palette, "palette == null");
        }

        /// <summary>
        /// Tests that the constructor with empty list of cards throws exception.
        /// </summary>
        /// <exception cref="System.IO.IOException">Ignore.</exception>
        [TestMethod]
        public void TestConstructorWithEmptyListOfCardsThrowsException()
        {
            // ARRANGE
            IList<ICard> cards = new List<ICard>();

            // ACT
            ArgumentException argumentException = null;
            IPalette palette = null;
            try
            {
                palette = new Palette(cards);
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

            Assert.IsNotNull(argumentException);
            Assert.IsNull(palette);
        }
    }
}