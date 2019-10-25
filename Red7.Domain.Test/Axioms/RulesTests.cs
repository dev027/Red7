// <copyright file="RulesTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Axioms;
using Red7.Domain.DomainObjects.Rules;
using Red7.Domain.ValueObjects;

namespace Red7.Domain.Test.Axioms
{
    /// <summary>
    /// Test RedRule, OrangeRule, YellowRule, GreenRule, BlueRule, IndigoRule and VioletRule.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(Axiom) + "/<colour>Rule")]
    [TestClass]
    public class RulesTests
    {
        /// <summary>
        /// Tests the Red Rule axiom.
        /// </summary>
        [TestMethod]
        public void TestRedRule()
        {
            // ARRANGE
            const Colour expectedColour = Colour.Red;

            // ACT
            IAxiom axiom = new Axiom();
            IRule actualRedRule = axiom.RedRule;

            // ASSERT
            Assert.IsNotNull(actualRedRule);
            Assert.AreEqual(expectedColour, actualRedRule.Colour);
        }

        /// <summary>
        /// Tests the Orange Rule axiom.
        /// </summary>
        [TestMethod]
        public void TestOrangeRule()
        {
            // ARRANGE
            const Colour expectedColour = Colour.Orange;

            // ACT
            IAxiom axiom = new Axiom();
            IRule actualOrangeRule = axiom.OrangeRule;

            // ASSERT
            Assert.IsNotNull(actualOrangeRule);
            Assert.AreEqual(expectedColour, actualOrangeRule.Colour);
        }

        /// <summary>
        /// Tests the Yellow Rule axiom.
        /// </summary>
        [TestMethod]
        public void TestYellowRule()
        {
            // ARRANGE
            const Colour expectedColour = Colour.Yellow;

            // ACT
            IAxiom axiom = new Axiom();
            IRule actualYellowRule = axiom.YellowRule;

            // ASSERT
            Assert.IsNotNull(actualYellowRule);
            Assert.AreEqual(expectedColour, actualYellowRule.Colour);
        }

        /// <summary>
        /// Tests the Green Rule axiom.
        /// </summary>
        [TestMethod]
        public void TestGreenRule()
        {
            // ARRANGE
            const Colour expectedColour = Colour.Green;

            // ACT
            IAxiom axiom = new Axiom();
            IRule actualGreenRule = axiom.GreenRule;

            // ASSERT
            Assert.IsNotNull(actualGreenRule);
            Assert.AreEqual(expectedColour, actualGreenRule.Colour);
        }

        /// <summary>
        /// Tests the Blue Rule axiom.
        /// </summary>
        [TestMethod]
        public void TestBlueRule()
        {
            // ARRANGE
            const Colour expectedColour = Colour.Blue;

            // ACT
            IAxiom axiom = new Axiom();
            IRule actualBlueRule = axiom.BlueRule;

            // ASSERT
            Assert.IsNotNull(actualBlueRule);
            Assert.AreEqual(expectedColour, actualBlueRule.Colour);
        }

        /// <summary>
        /// Tests the Indigo Rule axiom.
        /// </summary>
        [TestMethod]
        public void TestIndigoRule()
        {
            // ARRANGE
            const Colour expectedColour = Colour.Indigo;

            // ACT
            IAxiom axiom = new Axiom();
            IRule actualIndigoRule = axiom.IndigoRule;

            // ASSERT
            Assert.IsNotNull(actualIndigoRule);
            Assert.AreEqual(expectedColour, actualIndigoRule.Colour);
        }

        /// <summary>
        /// Tests the Violet Rule axiom.
        /// </summary>
        [TestMethod]
        public void TestVioletRule()
        {
            // ARRANGE
            const Colour expectedColour = Colour.Violet;

            // ACT
            IAxiom axiom = new Axiom();
            IRule actualVioletRule = axiom.VioletRule;

            // ASSERT
            Assert.IsNotNull(actualVioletRule);
            Assert.AreEqual(expectedColour, actualVioletRule.Colour);
        }
    }
}