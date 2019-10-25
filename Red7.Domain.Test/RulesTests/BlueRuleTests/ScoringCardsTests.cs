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

namespace Red7.Domain.Test.RulesTests.BlueRuleTests
{
    /// <summary>
    /// Test ScoringCards for Blue Rule.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(BlueRule) + "/" + nameof(BlueRule.ScoringCards))]
    [TestClass]
    public class ScoringCardsTests
    {
        /// <summary>
        /// Test that ScoringCards picks top card in each colour
        /// for the Blue Rule (Most different colours).
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
                new Card(Colour.Red, Number.Seven, axiom),
                new Card(Colour.Red, Number.Six, axiom),
                new Card(Colour.Red, Number.Two, axiom),
                new Card(Colour.Green, Number.Seven, axiom),
                new Card(Colour.Blue, Number.Two, axiom)
            };

            IList<ICard> expectedScoringCards = new List<ICard>
            {
                new Card(Colour.Red, Number.Seven, axiom),
                new Card(Colour.Blue, Number.Five, axiom),
                new Card(Colour.Green, Number.Seven, axiom)
            };

            IRule blueRule = new BlueRule();

            IPalette palette = new Palette(cards);

            // ACT
            IList<ICard> scoringCards = blueRule.ScoringCards(palette);

            // ASSERT
            Assert.IsNotNull(scoringCards);
            Assert.AreEqual(expected: 3, scoringCards.Count);

            foreach (ICard card in expectedScoringCards)
            {
                Assert.IsTrue(scoringCards.Any(c => c.CompareTo(card) == 0), card.ToString());
            }
        }
    }
}