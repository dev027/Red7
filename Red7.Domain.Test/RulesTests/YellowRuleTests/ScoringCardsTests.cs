// <copyright file="ScoringCardsTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Axioms;
using Red7.Domain.DomainObjects.Cards;
using Red7.Domain.DomainObjects.Palettes;
using Red7.Domain.DomainObjects.Rules;
using Red7.Domain.ValueObjects;

namespace Red7.Domain.Test.RulesTests.YellowRuleTests
{
    /// <summary>
    /// Test ScoringCards for Yellow Rule.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(YellowRule) + "/" + nameof(YellowRule.ScoringCards))]
    [TestClass]
    public class ScoringCardsTests
    {
        /// <summary>
        /// Test that ScoringCards the Blues are the most of one colour.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Ignore.</exception>
        [TestMethod]
        public void TestScoringCards()
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

            IList<ICard> expectedScoringCards = new List<ICard>
            {
                new Card(Colour.Blue, Number.Five, axiom),
                new Card(Colour.Blue, Number.Two, axiom),
            };

            IRule yellowRule = new YellowRule();

            IPalette palette = new Palette(cards);

            // ACT
            IList<ICard> scoringCards = yellowRule.ScoringCards(palette);

            // ASSERT
            Assert.IsNotNull(scoringCards);
            Assert.AreEqual(expected: 2, scoringCards.Count);

            foreach (ICard card in expectedScoringCards)
            {
                Assert.IsTrue(scoringCards.Any(c => c.CompareTo(card) == 0), card.ToString());
            }
        }
    }
}