// <copyright file="GetRuleTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Axioms;
using Red7.Domain.DomainObjects.Rules;
using Red7.Domain.ValueObjects;

namespace Red7.Domain.Test.Axioms
{
    /// <summary>
    /// Test GetRule.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(Axiom) + "/" + nameof(Axiom.GetRule))]
    [TestClass]
    public class GetRuleTests
    {
        /// <summary>
        /// Test that requesting a rule for a specific colour returns the correct rule.
        /// </summary>
        /// <param name="colour">Colour.</param>
        [TestMethod]
        [DataRow(Colour.Red)]
        [DataRow(Colour.Orange)]
        [DataRow(Colour.Yellow)]
        [DataRow(Colour.Green)]
        [DataRow(Colour.Blue)]
        [DataRow(Colour.Indigo)]
        [DataRow(Colour.Violet)]
        public void TestForEachColourReturnsCorrectRule(Colour colour)
        {
            // ARRANGE
            IAxiom axiom = new Axiom();

            // ACT
            IRule actualRule = axiom.GetRule(colour);

            // ASSERT
            Assert.IsNotNull(actualRule);
            Assert.AreEqual(colour, actualRule.Colour);
        }
    }
}