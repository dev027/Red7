// <copyright file="ConstructorTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Rules;
using Red7.Domain.ValueObjects;

namespace Red7.Domain.Test.RulesTests.OrangeRuleTests
{
    /// <summary>
    /// Test Orange Rule.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(OrangeRule) + "/Constructor")]
    [TestClass]
    public class ConstructorTests
    {
        /// <summary>
        /// Tests the constructor.
        /// </summary>
        [TestMethod]
        public void TestConstructor()
        {
            // ACT
            IRule orangeRule = new OrangeRule();

            // ASSERT
            Assert.AreEqual("Most of one number wins", orangeRule.Description);
            Assert.AreEqual(Colour.Orange, orangeRule.Colour);
        }
    }
}