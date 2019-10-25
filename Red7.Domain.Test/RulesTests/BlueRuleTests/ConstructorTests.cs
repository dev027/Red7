// <copyright file="ConstructorTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Rules;
using Red7.Domain.ValueObjects;

namespace Red7.Domain.Test.RulesTests.BlueRuleTests
{
    /// <summary>
    /// Test Green Rule.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(BlueRule) + "/Constructor")]
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
            IRule blueRule = new BlueRule();

            // ASSERT
            Assert.AreEqual("Most different colours wins", blueRule.Description);
            Assert.AreEqual(Colour.Blue, blueRule.Colour);
        }
    }
}