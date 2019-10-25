// <copyright file="ThreadSafeRandom.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Threading;

namespace Red7.Utilities
{
    /// <summary>
    /// Thread safe version of Random.
    /// </summary>
    public static class ThreadSafeRandom
    {
        [ThreadStatic]
        private static Random local;

        /// <summary>
        /// Gets the Random number generator.
        /// </summary>
        public static Random ThisThreadsRandom => local ?? (local = new Random(
                                                      unchecked(
                                                          (Environment.TickCount * 31) +
                                                          Thread.CurrentThread.ManagedThreadId)));
    }
}