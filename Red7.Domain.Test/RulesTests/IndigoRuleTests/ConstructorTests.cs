// <copyright file="ConstructorTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Axioms;
using Red7.Domain.DomainObjects.Rules;
using Red7.Domain.ValueObjects;

namespace Red7.Domain.Test.RulesTests.IndigoRuleTests
{
    /// <summary>
    /// Test Indigo Rule.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(IndigoRule) + "/Constructor")]
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
            IRule indigoRule = new IndigoRule(axiom);

            // ASSERT
            Assert.AreEqual("Most cards in a run", indigoRule.Description);
            Assert.AreEqual(Colour.Indigo, indigoRule.Colour);
        }
    }
}