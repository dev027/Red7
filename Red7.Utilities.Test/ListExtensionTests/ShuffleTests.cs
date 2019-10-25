// <copyright file="ShuffleTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Red7.Utilities.Test.ListExtensionTests
{
    /// <summary>
    /// Test ThreadSafeRandom.ThisThreadsRandom property.
    /// </summary>
    [TestCategory(nameof(Utilities) + "/" + nameof(ListExtensions) + "/" + nameof(ListExtensions.Shuffle))]
    [TestClass]
    public class ShuffleTests
    {
        /// <summary>
        /// Tests that shuffle rearranges the list.
        /// </summary>
        [TestMethod]
        public void TestShuffleRearrangesTheList()
        {
            // ARRANGE
            // Create a list of numbers where the value is the same as its index
            const int listSize = 50;

            IList<int> actualList = new List<int>();

            for (int i = 0; i < listSize; i++)
            {
                actualList.Add(i);
            }

            // ACT
            actualList.Shuffle();

            // ASSERT
            int countOfNumbersInSamePosition = 0;
            for (int i = 0; i < listSize; i++)
            {
                if (actualList[i] == i)
                {
                    countOfNumbersInSamePosition++;
                }
            }

            Assert.AreNotEqual(notExpected: listSize, actual: countOfNumbersInSamePosition);
        }

        /// <summary>
        /// Tests that shuffle returns the same list size.
        /// </summary>
        [TestMethod]
        public void TestShuffleReturnsSameListSize()
        {
            // ARRANGE
            // Create a list of numbers where the value is the same as its index
            const int listSize = 50;

            IList<int> actualList = new List<int>();

            for (int i = 0; i < listSize; i++)
            {
                actualList.Add(i);
            }

            // ACT
            actualList.Shuffle();

            // ASSERT
            int newListSize = actualList.Count;
            Assert.AreEqual(expected: listSize, actual: newListSize);
        }

        /// <summary>
        /// Tests the shuffle returns the same items.
        /// </summary>
        [TestMethod]
        public void TestShuffleReturnsTheSameItems()
        {
            // ARRANGE
            // Create a list of numbers where the value is the same as its index
            const int listSize = 50;

            IList<int> actualList = new List<int>();

            for (int i = 0; i < listSize; i++)
            {
                actualList.Add(i);
            }

            // ACT
            actualList.Shuffle();

            // ASSERT
            int countOfItemsFound = 0;
            for (int i = 0; i < listSize; i++)
            {
                if (actualList.Any(x => x == i))
                {
                    countOfItemsFound++;
                }
            }

            Assert.AreEqual(expected: listSize, actual: countOfItemsFound);
        }
    }
}