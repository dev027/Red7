// <copyright file="ScoreTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Axioms;
using Red7.Domain.DomainObjects.Cards;
using Red7.Domain.DomainObjects.Palettes;
using Red7.Domain.DomainObjects.Rules;
using Red7.Domain.ValueObjects;
using Red7.Domain.ValueObjects.RuleScores;

namespace Red7.Domain.Test.RulesTests.GreenRuleTests
{
    /// <summary>
    /// Test Score for Green Rule.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(GreenRule) + "/" + nameof(GreenRule.Score))]
    [TestClass]
    public class ScoreTests
    {
        /// <summary>
        /// Test that Score picks out even cards.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Ignore.</exception>
        [TestMethod]
        public void TestScore()
        {
            // ARRANGE
            IAxiom axiom = new Axiom();

            IList<ICard> cards = new List<ICard>
            {
                new Card(Colour.Blue, Number.Five, axiom),
                new Card(Colour.Red, Number.Seven, axiom),
                new Card(Colour.Red, Number.Six, axiom),
                new Card(Colour.Red, Number.Two, axiom),
                new Card(Colour.Green, Number.Seven, axiom),
                new Card(Colour.Blue, Number.Two, axiom),
            };

            IRule greenRule = new GreenRule(axiom);

            IPalette palette = new Palette(cards);

            // ACT
            IRuleScore ruleScore = greenRule.Score(palette);

            // ASSERT
            Assert.IsNotNull(ruleScore);
            Assert.AreEqual(expected: 3, actual: ruleScore.NumberOfCards);
            Assert.IsNotNull(ruleScore.TopCard);
            Assert.AreEqual(Colour.Red, ruleScore.TopCard.Colour);
            Assert.AreEqual(Number.Six, ruleScore.TopCard.Number);
        }

        /// <summary>
        /// Test that Score handle no even cards.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Ignore.</exception>
        [TestMethod]
        public void TestScoreWithNoEvenCards()
        {
            // ARRANGE
            IAxiom axiom = new Axiom();

            IList<ICard> cards = new List<ICard>
            {
                new Card(Colour.Blue, Number.Five, axiom),
                new Card(Colour.Red, Number.Seven, axiom),
                new Card(Colour.Green, Number.Seven, axiom),
            };

            IRule greenRule = new GreenRule(axiom);

            IPalette palette = new Palette(cards);

            // ACT
            IRuleScore ruleScore = greenRule.Score(palette);

            // ASSERT
            Assert.IsNotNull(ruleScore);
            Assert.AreEqual(expected: 0, actual: ruleScore.NumberOfCards);
            Assert.IsNull(ruleScore.TopCard);
        }
    }
}