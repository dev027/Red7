// <copyright file="LowestCardNumberTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Axioms;

namespace Red7.Domain.Test.Axioms
{
    /// <summary>
    /// Test LowestCardNumber.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(Axiom) + "/" + nameof(Axiom.LowestCardNumber))]
    [TestClass]
    public class LowestCardNumberTests
    {
        /// <summary>
        /// Tests the Lowest Card Number axiom.
        /// </summary>
        [TestMethod]
        public void TestLowestCardNumber()
        {
            // ARRANGE
            const int expectedLowestCardNumber = 1;

            // ACT
            IAxiom axiom = new Axiom();
            int actualLowestCardNumber = axiom.LowestCardNumber;

            // ASSERT
            Assert.AreEqual(expectedLowestCardNumber, actualLowestCardNumber);
        }
    }
}