// <copyright file="ConstructorTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Rules;
using Red7.Domain.ValueObjects;

namespace Red7.Domain.Test.RulesTests.YellowRuleTests
{
    /// <summary>
    /// Test DefaultRule.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(YellowRule) + "/Constructor")]
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
            IRule yellowRule = new YellowRule();

            // ASSERT
            Assert.AreEqual("Most of one colour wins", yellowRule.Description);
            Assert.AreEqual(Colour.Yellow, yellowRule.Colour);
        }
    }
}