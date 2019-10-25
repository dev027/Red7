// <copyright file="HighestCardNumberTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Axioms;

namespace Red7.Domain.Test.Axioms
{
    /// <summary>
    /// Test HighestCardNumber.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(Axiom) + "/" + nameof(Axiom.HighestCardNumber))]
    [TestClass]
    public class HighestCardNumberTests
    {
        /// <summary>
        /// Tests the Highest Card Number axiom.
        /// </summary>
        [TestMethod]
        public void TestHighestCardNumber()
        {
            // ARRANGE
            const int expectedHighestCardNumber = 7;

            // ACT
            IAxiom axiom = new Axiom();
            int actualHighestCardNumber = axiom.HighestCardNumber;

            // ASSERT
            Assert.AreEqual(expectedHighestCardNumber, actualHighestCardNumber);
        }
    }
}