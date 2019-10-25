// <copyright file="ConstructorTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Axioms;
using Red7.Domain.DomainObjects.Cards;
using Red7.Domain.DomainObjects.Hands;
using Red7.Domain.ValueObjects;

namespace Red7.Domain.Test.Hands
{
    /// <summary>
    /// Test Constructor.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(Hands) + "/Constructor")]
    [TestClass]
    public class ConstructorTests
    {
        /// <summary>
        /// Tests the constructor with valid parameters works.
        /// </summary>
        [TestMethod]
        public void TestConstructorWithValidParameters()
        {
            // ARRANGE
            IAxiom axiom = new Axiom();
            IList<ICard> cards = new List<ICard>
            {
                new Card(Colour.Red, Number.Seven, axiom),
                new Card(Colour.Blue, Number.Five, axiom),
                new Card(Colour.Green, Number.Two, axiom),
            };

            // ACT
            IHand actualHand = new Hand(cards);

            // ASSERT
            Assert.IsNotNull(actualHand.Cards);
            Assert.AreEqual(expected: 3, actualHand.Cards.Count);
        }

        /// <summary>
        /// Test Constructor with null cards throws exception.
        /// </summary>
        /// <exception cref="System.IO.IOException">Ignore.</exception>
        [TestMethod]
        public void TestConstructorWithNullCardsThrowsException()
        {
            // ACT
            ArgumentNullException argumentNullException = null;
            IHand actualHand = null;
            try
            {
                actualHand = new Hand(cards: null);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex);
                argumentNullException = ex;
            }

            // ASSERT
            Assert.IsNull(actualHand);
            Assert.IsNotNull(argumentNullException);
        }
    }
}