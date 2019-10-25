// <copyright file="RunsTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Red7.Domain.DomainObjects.Axioms;
using Red7.Domain.ValueObjects.Runs;

namespace Red7.Domain.Test.Axioms
{
    /// <summary>
    /// Test for the Runs property.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(Axiom) + "/" + nameof(Axiom.Runs))]
    [TestClass]
    public class RunsTests
    {
        /// <summary>
        /// Tests that Runs is populated correctly.
        /// </summary>
        [TestMethod]
        public void TestRunsPopulated()
        {
            // ARRANGE
            const int expectedRunCount = 21;

            // ACT
            IAxiom axiom = new Axiom();

            // ASSERT
            Assert.IsTrue(axiom.Runs.Any());
            Assert.AreEqual(expectedRunCount, axiom.Runs.Count);
        }

        /// <summary>
        /// Tests the length of the runs are correct.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="expectedLength">The expected length.</param>
        [TestMethod]
        [DataRow(0, 7)]
        [DataRow(1, 6)]
        [DataRow(2, 6)]
        [DataRow(3, 5)]
        [DataRow(4, 5)]
        [DataRow(5, 5)]
        [DataRow(6, 4)]
        [DataRow(7, 4)]
        [DataRow(8, 4)]
        [DataRow(9, 4)]
        [DataRow(10, 3)]
        [DataRow(11, 3)]
        [DataRow(12, 3)]
        [DataRow(13, 3)]
        [DataRow(14, 3)]
        [DataRow(15, 2)]
        [DataRow(16, 2)]
        [DataRow(17, 2)]
        [DataRow(18, 2)]
        [DataRow(19, 2)]
        [DataRow(20, 2)]
        public void TestRunsAreOfCorrectLength(int index, int expectedLength)
        {
            // ACT
            IAxiom axiom = new Axiom();

            // ASSERT
            Assert.IsTrue(index < axiom.Runs.Count);
            Assert.AreEqual(expectedLength, axiom.Runs[index].Length);
        }

        /// <summary>
        /// Tests that cards in run are in descending order.
        /// </summary>
        [TestMethod]
        public void TestCardsInRunAreInDescendingOrder()
        {
            // ACT
            IAxiom axiom = new Axiom();
            IReadOnlyList<IRun> actualRuns = axiom.Runs;

            // ASSERT
            foreach (IRun run in actualRuns)
            {
                for (int i = 0; i < run.Length - 1; i++)
                {
                    Assert.IsTrue(
                        run.Numbers[i] > run.Numbers[i + 1],
                        $"Run: {run}, Card Index {i}");
                }
            }
        }

        /// <summary>
        /// Tests that runs of the same length are unique.
        /// </summary>
        /// <param name="runLength">Length of the run.</param>
        [TestMethod]
        [DataRow(7)]
        [DataRow(6)]
        [DataRow(5)]
        [DataRow(4)]
        [DataRow(3)]
        [DataRow(2)]
        public void TestRunsAreUnique(int runLength)
        {
            // ACT
            IAxiom axiom = new Axiom();
            IReadOnlyList<IRun> actualRuns = axiom.Runs;

            // ASSERT
            List<IRun> runsToCheck = actualRuns
                .Where(r => r.Length == runLength)
                .ToList();

            foreach (IRun run1 in runsToCheck)
            {
                string run1Serialized = JsonConvert.SerializeObject(run1);

                foreach (IRun run2 in runsToCheck)
                {
                    if (ReferenceEquals(run1, run2))
                    {
                        continue;
                    }

                    string run2Serialized = JsonConvert.SerializeObject(run2);
                    Assert.AreNotEqual(
                        run1Serialized,
                        run2Serialized,
                        $"Run1: {run1}, Run2: {run2}");
                }
            }
        }
    }
}