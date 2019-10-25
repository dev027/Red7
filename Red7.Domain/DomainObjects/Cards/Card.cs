// <copyright file="Card.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Red7.Domain.DomainObjects.Axioms;
using Red7.Domain.DomainObjects.Rules;
using Red7.Domain.ValueObjects;

namespace Red7.Domain.DomainObjects.Cards
{
    /// <summary>
    /// Card.
    /// </summary>
    public class Card : ICard
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="colour">Colour.</param>
        /// <param name="number">Card.</param>
        /// <param name="axiom">Game Axioms.</param>
        public Card(Colour colour, Number number, IAxiom axiom)
        {
            if (axiom == null)
            {
                throw new ArgumentNullException(nameof(axiom));
            }

            this.Colour = colour;
            this.Number = number;
            this.Rule = axiom.GetRule(colour);
        }

        #endregion Constructors

        #region Public Properties

        /// <inheritdoc/>
        public Colour Colour { get; }

        /// <inheritdoc/>
        public Number Number { get; }

        /// <inheritdoc/>
        public IRule Rule { get; }

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
        public static bool operator ==(Card left, Card right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
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
        public static bool operator !=(Card left, Card right)
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
        public static bool operator <(Card left, Card right)
        {
            return left is null
                ? !(right is null)
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
        public static bool operator <=(Card left, Card right)
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
        public static bool operator >(Card left, Card right)
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
        public static bool operator >=(Card left, Card right)
        {
            return left is null
                ? right is null
                : left.CompareTo(right) >= 0;
        }

        #endregion Public Operators

        #region Public Static Methods

        /// <summary>
        /// Determine which is the top card in the supplied list of cards.
        /// </summary>
        /// <param name="cards">List of cards to check for the top card.</param>
        /// <returns>The top card OR null if the list is empty.</returns>
        ///
        public static ICard TopCard(IEnumerable<ICard> cards)
        {
            if (cards == null)
            {
                throw new ArgumentNullException(nameof(cards));
            }

            ICard topCard = null;

            foreach (ICard card in cards)
            {
                if (topCard == null || card.CompareTo(topCard) > 0)
                {
                    topCard = card;
                }
            }

            return topCard;
        }

        #endregion Public Static Methods

        #region Public Methods

        /// <summary>
        /// Compares this card to another card.
        /// </summary>
        /// <param name="card">The other card.</param>
        /// <returns>
        /// -1 if less than the other card
        /// 0 if equal to the other card
        /// 1 if greater than the other card.
        /// </returns>
        public int CompareTo(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            // Colour takes precedence
            if (this.Colour > card.Colour)
            {
                return 1;
            }

            if (this.Colour < card.Colour)
            {
                return -1;
            }

            // If colours are the same then check the number
            if (this.Number > card.Number)
            {
                return 1;
            }

            if (this.Number < card.Number)
            {
                return -1;
            }

            // Same colour and number
            return 0;
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"{this.Colour} {this.Number}";
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

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (!(obj is Card))
            {
                return false;
            }

            Card that = (Card)obj;

            if (this.Colour != that.Colour)
            {
                return false;
            }

            if (this.Number != that.Number)
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

        #endregion Public Methods
    }
}