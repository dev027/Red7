// <copyright file="RuleScore.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using Red7.Domain.DomainObjects.Cards;
using Red7.Domain.Resources;

namespace Red7.Domain.ValueObjects.RuleScores
{
    /// <summary>
    /// Score for a Rule.
    /// </summary>
    public class RuleScore : IRuleScore
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleScore"/> class.
        /// </summary>
        /// <param name="numberOfCards">Number of cards that match the rule.</param>
        /// <param name="topCard">Top card of those that match the rule.</param>
        public RuleScore(int numberOfCards, ICard topCard)
        {
            if (numberOfCards < 0 || numberOfCards > 49)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(numberOfCards),
                    numberOfCards,
                    ExceptionResource.InvalidNumberOfCards);
            }

            if (numberOfCards == 0 && topCard != null)
            {
                throw new ArgumentException(
                    ExceptionResource.CannotHaveZeroScardWithANonNullTopCard);
            }

            if (numberOfCards > 0 && topCard == null)
            {
                throw new ArgumentException(
                    ExceptionResource.CannotHavePositiveScoreWithNullTopCard);
            }

            this.NumberOfCards = numberOfCards;
            this.TopCard = topCard;
        }

        #endregion Constructors

        #region Public Properties

        /// <inheritdoc/>
        public int NumberOfCards { get; }

        /// <inheritdoc/>
        public ICard TopCard { get; }

        #endregion Public Properties

        #region Public Operators

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(RuleScore left, RuleScore right)
        {
            if (left is null)
            {
                return right is null;
            }

            return left.Equals(right);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(RuleScore left, RuleScore right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Implements the operator &lt;.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator <(RuleScore left, RuleScore right)
        {
            return left is null ?
                !(right is null)
                : left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Implements the operator &lt;=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator <=(RuleScore left, RuleScore right)
        {
            return left is null || left.CompareTo(right) <= 0;
        }

        /// <summary>
        /// Implements the operator &gt;.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator >(RuleScore left, RuleScore right)
        {
            return !(left is null) && left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Implements the operator &gt;=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator >=(RuleScore left, RuleScore right)
        {
            return left is null
                ? right is null
                : left.CompareTo(right) >= 0;
        }

        #endregion Public Operators

        #region Public Methods

        /// <summary>
        /// Compare this Rule Score to another.
        /// </summary>
        /// <param name="other">Rule Score to compare to.</param>
        /// <returns>-1 if lower, 1 if higher and 0 if the same.</returns>
        public int CompareTo(IRuleScore other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            if (this.NumberOfCards > other.NumberOfCards)
            {
                return 1;
            }

            if (this.NumberOfCards < other.NumberOfCards)
            {
                return -1;
            }

            // When the number of cards is zero then then top card will be null.
            // Hence there is no top card to compare with.
            if (this.NumberOfCards == 0)
            {
                return 0;
            }

            return this.TopCard.CompareTo(other.TopCard);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is null)
            {
                return false;
            }

            if (!(obj is RuleScore))
            {
                return false;
            }

            RuleScore that = (RuleScore)obj;

            if (this.NumberOfCards != that.NumberOfCards)
            {
                return false;
            }

            if (this.TopCard != that.TopCard)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"Score: {this.NumberOfCards} with Top Card: {this.TopCard}";
        }

        #endregion Public Methods
    }
}