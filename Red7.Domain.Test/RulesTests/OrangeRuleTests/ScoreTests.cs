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

namespace Red7.Domain.Test.RulesTests.OrangeRuleTests
{
    /// <summary>
    /// Test Score for Orange Rule.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(OrangeRule) + "/" + nameof(OrangeRule.Score))]
    [TestClass]
    public class ScoreTests
    {
        /// <summary>
        /// Test that Score picks out the most of one number.
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
                new Card(Colour.Red, Number.Four, axiom),
                new Card(Colour.Green, Number.Four, axiom),
                new Card(Colour.Blue, Number.Two, axiom),
            };

            IRule orangeRule = new OrangeRule();

            IPalette palette = new Palette(cards);

            // ACT
            IRuleScore ruleScore = orangeRule.Score(palette);

            // ASSERT
            Assert.IsNotNull(ruleScore);
            Assert.AreEqual(expected: 2, actual: ruleScore.NumberOfCards);
            Assert.IsNotNull(ruleScore.TopCard);
            Assert.AreEqual(Colour.Red, ruleScore.TopCard.Colour);
            Assert.AreEqual(Number.Four, ruleScore.TopCard.Number);
        }
    }
}