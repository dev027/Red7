// <copyright file="Run.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Red7.Domain.ValueObjects.Runs
{
    /// <summary>
    /// Run of Numbers.
    /// </summary>
    public class Run : IRun
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Run"/> class.
        /// </summary>
        /// <param name="start">Start Number.</param>
        /// <param name="end">End Number.</param>
        public Run(Number start, Number end)
        {
            this.Numbers = typeof(Number).GetEnumValues().Cast<Number>()
                .Where(n => n >= start && n <= end)
                .OrderByDescending(n => n)
                .ToList();
        }

        #endregion

        #region Public Properties

        /// <inheritdoc/>
        public IList<Number> Numbers { get; }

        /// <inheritdoc/>
        public int Length => this.Numbers.Count;

        #endregion

        #region Public Methods

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.Length);
            sb.Append(" cards: ");

            string prefix = string.Empty;
            foreach (Number number in this.Numbers)
            {
                sb.Append(prefix);
                sb.Append(number);

                prefix = ", ";
            }

            return sb.ToString();
        }

       #endregion
    }
}