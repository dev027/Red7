// <copyright file="ThisThreadsRandomTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Red7.Utilities.Test.ThreadSafeRandomTests
{
    /// <summary>
    /// Test ThreadSafeRandom.ThisThreadsRandom property.
    /// </summary>
    [TestCategory(nameof(Utilities) + "/" + nameof(ThreadSafeRandom) + "/" + nameof(ThreadSafeRandom.ThisThreadsRandom))]
    [TestClass]
    public class ThisThreadsRandomTests
    {
        /// <summary>
        /// Test that the property returns a non-null object.
        /// </summary>
        [TestMethod]
        public void TestThatThisThreadsRandomReturnsNonNullObject()
        {
            // ACT
            Random random = ThreadSafeRandom.ThisThreadsRandom;

            // ASSERT
            Assert.IsNotNull(random);
        }

        /// <summary>
        /// Test that calling the property multiple times returns the same object.
        /// </summary>
        [TestMethod]
        public void TestThatThisThreadsRandomReturnsTheSameObjectEveryTime()
        {
            // ACT
            Random random1 = ThreadSafeRandom.ThisThreadsRandom;
            Random random2 = ThreadSafeRandom.ThisThreadsRandom;

            // ASSERT
            Assert.AreSame(random1, random2);
        }
    }
}