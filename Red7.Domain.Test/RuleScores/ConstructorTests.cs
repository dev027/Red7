// <copyright file="ConstructorTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Axioms;
using Red7.Domain.DomainObjects.Cards;
using Red7.Domain.ValueObjects;
using Red7.Domain.ValueObjects.RuleScores;

namespace Red7.Domain.Test.RuleScores
{
    /// <summary>
    /// Test Constructor.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(RuleScore) + "/Constructor")]
    [TestClass]
    public class ConstructorTests
    {
        /// <summary>
        /// Tests the constructor with actual score.
        /// </summary>
        [TestMethod]
        public void TestConstructorWithActualScore()
        {
            // ARRANGE
            IAxiom axiom = new Axiom();
            const int numberOfCards = 5;
            ICard topCard = new Card(Colour.Red, Number.Seven, axiom);

            // ACT
            IRuleScore ruleScore = new RuleScore(
                numberOfCards: numberOfCards,
                topCard: topCard);

            // ASSERT
            Assert.AreEqual(numberOfCards, ruleScore.NumberOfCards);
            Assert.IsTrue(ruleScore.TopCard.CompareTo(topCard) == 0);
        }

        /// <summary>
        /// Tests the constructor with zero score (and null top card).
        /// </summary>
        [TestMethod]
        public void TestConstructorWithZeroScore()
        {
            // ARRANGE
            const int numberOfCards = 0;

            // ACT
            IRuleScore ruleScore = new RuleScore(
                numberOfCards: numberOfCards,
                topCard: null);

            // ASSERT
            Assert.AreEqual(numberOfCards, ruleScore.NumberOfCards);
            Assert.IsNull(ruleScore.TopCard);
        }

        /// <summary>
        /// Tests the constructor with bad number of cards throws an exception.
        /// </summary>
        /// <param name="numberOfCards">The number of cards.</param>
        /// <exception cref="System.IO.IOException">Ignore.</exception>
        [DataRow(-1, DisplayName = "Negative number")]
        [DataRow(50, DisplayName = "Excessively high number")]
        [TestMethod]
        public void TestConstructorWithBadNumberOfCards(int numberOfCards)
        {
            // ARRANGE
            IAxiom axiom = new Axiom();
            ICard topCard = new Card(Colour.Blue, Number.Five, axiom);

            // ACT
            ArgumentOutOfRangeException argumentOutOfRangeException = null;
            IRuleScore ruleScore = null;
            try
            {
                ruleScore = new RuleScore(
                   numberOfCards: numberOfCards,
                   topCard: topCard);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                argumentOutOfRangeException = ex;
            }

            // ASSERT
            if (argumentOutOfRangeException != null)
            {
                Console.WriteLine(argumentOutOfRangeException.ToString());
            }

            Assert.IsNotNull(argumentOutOfRangeException, "Expected exception not thrown");
            Assert.IsNull(ruleScore, "ruleScore == null");
        }

        /// <summary>
        /// Tests the constructor with positive number of cards and null top card
        /// throws an exception.
        /// </summary>
        /// <exception cref="System.IO.IOException">Ignore.</exception>
        [TestMethod]
        public void TestConstructorWithPositiveNumberOfCardsAndNullTopCard()
        {
            // ARRANGE
            const int numberOfCards = 1;

            // ACT
            ArgumentException argumentException = null;
            IRuleScore ruleScore = null;
            try
            {
                ruleScore = new RuleScore(
                   numberOfCards: numberOfCards,
                   topCard: null);
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

            Assert.IsNotNull(argumentException, "argumentException != null");
            Assert.IsNull(ruleScore, "ruleScore == null");
        }

        /// <summary>
        /// Tests the constructor with zero number of cards and null top card
        /// throws an exception.
        /// </summary>
        /// <exception cref="System.IO.IOException">Ignore.</exception>
        [TestMethod]
        public void TestConstructorWithZeroNumberOfCardsAndNullTopCard()
        {
            // ARRANGE
            IAxiom axiom = new Axiom();
            const int numberOfCards = 0;
            ICard topCard = new Card(Colour.Blue, Number.Five, axiom);

            // ACT
            ArgumentException argumentException = null;
            IRuleScore ruleScore = null;
            try
            {
                ruleScore = new RuleScore(
                   numberOfCards: numberOfCards,
                   topCard: topCard);
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

            Assert.IsNotNull(argumentException, "argumentException != null");
            Assert.IsNull(ruleScore, "ruleScore == null");
        }
    }
}