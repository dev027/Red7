// <copyright file="ConstructorTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Axioms;
using Red7.Domain.DomainObjects.Decks;

namespace Red7.Domain.Test.Decks
{
    /// <summary>
    /// Test Constructor.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(Decks) + "/Constructor")]
    [TestClass]
    public class ConstructorTests
    {
        /// <summary>
        /// Test the constructor.
        /// </summary>
        [TestMethod]
        public void ConstructorTest()
        {
            // ARRANGE
            IAxiom axiom = new Axiom();
            const int numberOfColours = 7;
            const int numberOfNumbers = 7;
            const int expectedNumberOfCards = numberOfColours * numberOfNumbers;

            // ACT
            IDeck actualDeck = new Deck(axiom);

            // ASSERT
            Assert.IsNotNull(actualDeck);
            Assert.AreEqual(expectedNumberOfCards, actualDeck.Cards.Count);
        }
    }
}