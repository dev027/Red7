// <copyright file="ConstructorTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Rules;
using Red7.Domain.ValueObjects;

namespace Red7.Domain.Test.RulesTests.RedRuleTests
{
    /// <summary>
    /// Test Red Rule.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(RedRule) + "/Constructor")]
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
            IRule redRule = new RedRule();

            // ASSERT
            Assert.AreEqual("Highest card wins", redRule.Description);
            Assert.AreEqual(Colour.Red, redRule.Colour);
        }
    }
}