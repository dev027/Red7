// <copyright file="DefaultRuleTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Axioms;
using Red7.Domain.DomainObjects.Rules;
using Red7.Domain.ValueObjects;

namespace Red7.Domain.Test.Axioms
{
    /// <summary>
    /// Test DefaultRule.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(Axiom) + "/" + nameof(Axiom.DefaultRule))]
    [TestClass]
    public class DefaultRuleTests
    {
        /// <summary>
        /// Tests that the Default Rule is Red.
        /// </summary>
        [TestMethod]
        public void TestDefaultRuleIsRed()
        {
            // ARRANGE
            const Colour expectedColour = Colour.Red;

            // ACT
            IAxiom axiom = new Axiom();
            IRule actualDefaultRule = axiom.DefaultRule;

            // ASSERT
            Assert.IsNotNull(actualDefaultRule);
            Assert.AreEqual(expectedColour, actualDefaultRule.Colour);
        }
    }
}