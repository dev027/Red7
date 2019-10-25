// <copyright file="ConstructorTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Axioms;
using Red7.Domain.DomainObjects.Rules;
using Red7.Domain.ValueObjects;

namespace Red7.Domain.Test.RulesTests.GreenRuleTests
{
    /// <summary>
    /// Test Green Rule.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(GreenRule) + "/Constructor")]
    [TestClass]
    public class ConstructorTests
    {
        /// <summary>
        /// Tests the constructor.
        /// </summary>
        [TestMethod]
        public void TestConstructor()
        {
            // ARRANGE
            IAxiom axiom = new Axiom();

            // ACT
            IRule greenRule = new GreenRule(axiom);

            // ASSERT
            Assert.AreEqual("Most even cards wins", greenRule.Description);
            Assert.AreEqual(Colour.Green, greenRule.Colour);
        }
    }
}