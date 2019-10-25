// <copyright file="ListExtensions.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace Red7.Utilities
{
    /// <summary>
    /// Extension methods for Lists.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Shuffles the specified list.
        /// </summary>
        /// <typeparam name="T">Type of the list.</typeparam>
        /// <param name="list">The list.</param>
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}