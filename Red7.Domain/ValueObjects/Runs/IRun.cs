// <copyright file="IRun.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace Red7.Domain.ValueObjects.Runs
{
    /// <summary>
    /// Run of Numbers.
    /// </summary>
    public interface IRun
    {
        /// <summary>
        /// Gets Numbers in a Run in descending order.
        /// </summary>
        IList<Number> Numbers { get; }

        /// <summary>
        /// Gets the Length of the Run.
        /// </summary>
        int Length { get; }
    }
}