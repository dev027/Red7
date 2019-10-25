// <copyright file="InitialNumberOfCardsInPaletteTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red7.Domain.DomainObjects.Axioms;

namespace Red7.Domain.Test.Axioms
{
    /// <summary>
    /// Test InitialNumberOfCardsInPalette.
    /// </summary>
    [TestCategory(nameof(Domain) + "/" + nameof(Axiom) + "/" + nameof(Axiom.InitialNumberOfCardsInPalette))]
    [TestClass]
    public class InitialNumberOfCardsInPaletteTests
    {
        /// <summary>
        /// Tests the Initial Number of Cards in Palette axiom.
        /// </summary>
        [TestMethod]
        public void TestInitialNumberOfCardsInPalette()
        {
            // ASSERT
            const int expectedInitialNumberOfCardsInPalette = 1;

            // ACT
            IAxiom axiom = new Axiom();
            int actualInitialNumberOfCardsInPalette = axiom.InitialNumberOfCardsInPalette;

            // ASSERT
            Assert.AreEqual(expectedInitialNumberOfCardsInPalette, actualInitialNumberOfCardsInPalette);
        }
    }
}