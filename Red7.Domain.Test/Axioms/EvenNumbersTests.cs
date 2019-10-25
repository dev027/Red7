// <copyright file="EvenNumbersTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Axioms;
using Red7.Domain.ValueObjects;

namespace Red7.Domain.Test.Axioms
{
    /// <summary>
    /// Test EvenNumbers.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(Axiom) + "/" + nameof(Axiom.EvenNumbers))]
    [TestClass]
    public class EvenNumbersTests
    {
        /// <summary>
        /// Tests that the list has the correct number of even numbers.
        /// </summary>
        [TestMethod]
        public void TestCorrectNumberOfEvenNumbers()
        {
            // ARRANGE
            const int expectedCount = 3;

            // ACT
            IAxiom axiom = new Axiom();
            IReadOnlyList<Number> actualEvenNumbers = axiom.EvenNumbers;

            // ASSERT
            Assert.IsNotNull(actualEvenNumbers);
            Assert.AreEqual(expectedCount, actualEvenNumbers.Count);
        }

        /// <summary>
        /// Tests that the numbers are even.
        /// </summary>
        [TestMethod]
        public void TestNumbersAreEven()
        {
            // ACT
            IAxiom axiom = new Axiom();
            IReadOnlyList<Number> actualEvenNumbers = axiom.EvenNumbers;

            // ASSERT
            foreach (Number evenNumber in actualEvenNumbers)
            {
                int value = (int)evenNumber;

                Assert.IsTrue(value % 2 == 0, evenNumber.ToString());
            }
        }

        /// <summary>
        /// Tests that the numbers are unique.
        /// </summary>
        [TestMethod]
        public void TestNumbersAreUnique()
        {
            // ACT
            IAxiom axiom = new Axiom();
            IReadOnlyList<Number> actualEvenNumbers = axiom.EvenNumbers;

            // ASSERT
            foreach (Number evenNumber in actualEvenNumbers)
            {
                int count = actualEvenNumbers.Count(n => n == evenNumber);
                Assert.AreEqual(1, count, evenNumber.ToString());
            }
        }

        /// <summary>
        /// Tests that the numbers are in descending order.
        /// </summary>
        [TestMethod]
        public void TestNumbersAreInDescendingOrder()
        {
            // ACT
            IAxiom axiom = new Axiom();
            IReadOnlyList<Number> evenNumbers = axiom.EvenNumbers;

            // ASSERT
            for (int i = 0; i < evenNumbers.Count - 1; i++)
            {
                Assert.IsTrue(
                    evenNumbers[i] > evenNumbers[i + 1],
                    evenNumbers[i].ToString());
            }
        }
    }
}