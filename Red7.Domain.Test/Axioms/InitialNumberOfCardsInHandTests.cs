// <copyright file="InitialNumberOfCardsInHandTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Axioms;

namespace Red7.Domain.Test.Axioms
{
    /// <summary>
    /// Test InitialNumberOfCardsInHand.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(Axiom) + "/" + nameof(Axiom.InitialNumberOfCardsInHand))]
    [TestClass]
    public class InitialNumberOfCardsInHandTests
    {
        /// <summary>
        /// Tests the Initial Number of Cards in Hand axiom.
        /// </summary>
        [TestMethod]
        public void TestInitialNumberOfCardsInHand()
        {
            // ARRANGE
            const int expectedInitialNumberOfCardsInHand = 7;

            // ACT
            IAxiom axiom = new Axiom();
            int actualInitialNumberOfCardsInHand = axiom.InitialNumberOfCardsInHand;

            // ASSERT
            Assert.AreEqual(expectedInitialNumberOfCardsInHand, actualInitialNumberOfCardsInHand);
        }
    }
}