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

namespace Red7.Domain.Test.RulesTests.RedRuleTests
{
    /// <summary>
    /// Test ScoringCards for Red Rule.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(RedRule) + "/" + nameof(RedRule.ScoringCards))]
    [TestClass]
    public class ScoringCardsTests
    {
        /// <summary>
        /// Test that ScoringCards picks out the Red7 as the only scoring card
        /// for the Red Rule (Highest card wins).
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
                new Card(Colour.Green, Number.Seven, axiom),
                new Card(Colour.Blue, Number.Two, axiom),
            };

            IRule redRule = new RedRule();

            IPalette palette = new Palette(cards);

            // ACT
            IList<ICard> scoringCards = redRule.ScoringCards(palette);

            // ASSERT
            Assert.IsNotNull(scoringCards);
            Assert.AreEqual(expected: 1, scoringCards.Count);
            ICard card = scoringCards.Single();
            Assert.AreEqual(Colour.Red, card.Colour);
            Assert.AreEqual(Number.Seven, card.Number);
        }
    }
}