// <copyright file="CompareToTests.cs" company="Do It Wright">
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
    /// Test CompareTo().
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(RuleScore) + "/" + nameof(RuleScore.CompareTo))]
    [TestClass]
    public class CompareToTests
    {
        /// <summary>
        /// Tests the compare to null throws exception.
        /// </summary>
        /// <exception cref="System.IO.IOException">Ignore.</exception>
        [TestMethod]
        public void TestCompareToNullThrowsException()
        {
            // ARRANGE
            IAxiom axiom = new Axiom();
            ICard topCard = new Card(Colour.Green, Number.Four, axiom);
            const int numberOfCards = 4;
            IRuleScore ruleScore = new RuleScore(numberOfCards, topCard);

            // ACT
            ArgumentNullException argumentNullException = null;
            int comparison = 99;
            try
            {
                comparison = ruleScore.CompareTo(null);
            }
            catch (ArgumentNullException exception)
            {
                argumentNullException = exception;
            }

            // ASSERT
            if (argumentNullException != null)
            {
                Console.WriteLine(argumentNullException.ToString());
            }

            Assert.IsNotNull(argumentNullException);
            Assert.AreEqual(expected: 99, actual: comparison);
        }

        /// <summary>
        /// Tests the compare with various combinations.
        /// </summary>
        /// <param name="topCard1Colour">The top card colour.</param>
        /// <param name="topCard1Number">The top card number.</param>
        /// <param name="numberOfCards1">The number of cards.</param>
        /// <param name="expectedResult">The expected result.</param>
        [DataRow(Colour.Red, Number.Seven, 3, 1, DisplayName = "Bigger card, Bigger Score")]
        [DataRow(Colour.Red, Number.Seven, 2, 1, DisplayName = "Bigger card, Same Score")]
        [DataRow(Colour.Red, Number.Seven, 1, -1, DisplayName = "Bigger card, Smaller Score")]
        [DataRow(Colour.Violet, Number.One, 3, 1, DisplayName = "Smaller card, Bigger Score")]
        [DataRow(Colour.Violet, Number.One, 2, -1, DisplayName = "Smaller card, Same Score")]
        [DataRow(Colour.Violet, Number.One, 1, -1, DisplayName = "Smaller card, Smaller Score")]
        [DataRow(Colour.Green, Number.Four, 3, 1, DisplayName = "Same card, Bigger Score")]
        [DataRow(Colour.Green, Number.Four, 2, 0, DisplayName = "Same card, Same Score")]
        [DataRow(Colour.Green, Number.Four, 1, -1, DisplayName = "Same card, Smaller Score")]
        [TestMethod]
        public void TestCompareWithVariousCombinations(
            Colour topCard1Colour,
            Number topCard1Number,
            int numberOfCards1,
            int expectedResult)
        {
            // ARRANGE
            IAxiom axiom = new Axiom();

            ICard topCard1 = new Card(topCard1Colour, topCard1Number, axiom);
            IRuleScore ruleScore1 = new RuleScore(numberOfCards1, topCard1);

            ICard topCard2 = new Card(Colour.Green, Number.Four, axiom);
            const int numberOfCards2 = 2;
            IRuleScore ruleScore2 = new RuleScore(numberOfCards2, topCard2);

            // ACT
            int actualResult = ruleScore1.CompareTo(ruleScore2);

            // ASSERT
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Tests the compare with a zero score.
        /// </summary>
        [TestMethod]
        public void TestCompareWithZeroScore()
        {
            // ARRANGE
            IRuleScore ruleScore1 = new RuleScore(numberOfCards: 0, topCard: null);
            IRuleScore ruleScore2 = new RuleScore(numberOfCards: 0, null);

            // ACT
            int actualResult = ruleScore1.CompareTo(ruleScore2);

            // ASSERT
            Assert.AreEqual(expected: 0, actual: actualResult);
        }
    }
}