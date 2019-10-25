// <copyright file="TopCardTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Axioms;
using Red7.Domain.DomainObjects.Cards;
using Red7.Domain.ValueObjects;

namespace Red7.Domain.Test.Cards
{
    /// <summary>
    /// Test TopCard().
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(Card) + "/" + nameof(Card.TopCard))]
    [TestClass]
    public class TopCardTests
    {
        /// <summary>
        /// Picking the top card from a list of just one card will return that card.
        /// </summary>
        [TestMethod]
        public void PickTopCardFromSingleCardReturnsThatCard()
        {
            // ARRANGE
            IAxiom axiom = new Axiom();

            IList<ICard> cards = new List<ICard>
            {
                new Card(Colour.Green, Number.Four, axiom),
            };

            // ACT
            ICard topCard = Card.TopCard(cards);

            // ASSERT
            Assert.IsNotNull(topCard);
            Assert.AreEqual(Colour.Green, topCard.Colour);
            Assert.AreEqual(Number.Four, topCard.Number);
        }

        /// <summary>
        /// Picking the top card from blue2 and red3 returns red3, regardless of the order of the cards.
        /// </summary>
        /// <param name="card1Colour">The Colour of Card 1.</param>
        /// <param name="card1Number">The Number of Card 1.</param>
        /// <param name="card2Colour">The Colour of Card 2.</param>
        /// <param name="card2Number">The Number of Card 2.</param>
        [DataRow(Colour.Red, Number.Three, Colour.Blue, Number.Two, DisplayName = "Highest card first")]
        [DataRow(Colour.Blue, Number.Two, Colour.Red, Number.Three, DisplayName = "Lowest card first")]
        [TestMethod]
        public void PickTopCardFromBlue2AndRed3ReturnsRed3(
            Colour card1Colour,
            Number card1Number,
            Colour card2Colour,
            Number card2Number)
        {
            // ARRANGE
            IAxiom axiom = new Axiom();

            IList<ICard> cards = new List<ICard>
            {
                new Card(card1Colour, card1Number, axiom),
                new Card(card2Colour, card2Number, axiom),
            };

            // ACT
            ICard topCard = Card.TopCard(cards);

            // ASSERT
            Assert.IsNotNull(topCard);
            Assert.AreEqual(Colour.Red, topCard.Colour);
            Assert.AreEqual(Number.Three, topCard.Number);
        }

        /// <summary>
        /// Picking the top card from an empty list should return null.
        /// </summary>
        [TestMethod]
        public void PickTopCardFromEmptyListReturnsNull()
        {
            // ARRANGE
            IReadOnlyList<ICard> cards = new List<ICard>();

            // ACT
            ICard topCard = Card.TopCard(cards);

            // ASSERT
            Assert.IsNull(topCard);
        }

        /// <summary>
        /// Picks the top card from null list throws argument null exception.
        /// </summary>
        /// <exception cref="System.IO.IOException">Ignore.</exception>
        [TestMethod]
        public void PickTopCardFromNullListThrowsArgumentNullException()
        {
            // ACT
            ArgumentNullException argumentNullException = null;
            ICard topCard = null;
            try
            {
                topCard = Card.TopCard(null);
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
            Assert.IsNull(topCard);
        }
    }
}