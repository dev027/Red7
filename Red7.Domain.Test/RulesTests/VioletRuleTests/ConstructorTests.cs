// <copyright file="ConstructorTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Rules;
using Red7.Domain.ValueObjects;

namespace Red7.Domain.Test.RulesTests.VioletRuleTests
{
    /// <summary>
    /// Test Violet Rule.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(VioletRule) + "/Constructor")]
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
            IRule violetRule = new VioletRule();

            // ASSERT
            Assert.AreEqual("Most cards below 4 wins", violetRule.Description);
            Assert.AreEqual(Colour.Violet, violetRule.Colour);
        }
    }
}