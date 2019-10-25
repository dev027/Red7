// <copyright file="Player.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Red7.Domain.DomainObjects.Cards;
using Red7.Domain.DomainObjects.Hands;
using Red7.Domain.DomainObjects.Palettes;

namespace Red7.Domain.DomainObjects.Players
{
    /// <summary>
    /// Player.
    /// </summary>
    public class Player : IPlayer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="name">Player's name.</param>
        public Player(string name)
        {
            this.Name = name;

            this.Hand = null;
            this.Palette = new Palette(new List<ICard>());
            this.ScoringCardList = new List<ICard>();
            this.FoldedCardList = new List<ICard>().ToList();
        }

        /// <inheritdoc/>
        public string Name { get; }

        /// <inheritdoc/>
        public IHand Hand { get; }

        /// <inheritdoc/>
        public IPalette Palette { get; }

        /// <inheritdoc/>
        public IReadOnlyList<ICard> ScoringCards => (IReadOnlyList<ICard>)this.ScoringCardList;

        /// <inheritdoc/>
        public int Score => this.ScoringCards.Sum(c => (int)c.Number);

        /// <inheritdoc/>
        public IReadOnlyList<ICard> FoldedCards => (IReadOnlyList<ICard>)this.FoldedCardList;

        /// <inheritdoc/>
        public bool HasFolded => this.FoldedCards.Any();

        private IList<ICard> ScoringCardList { get; }

        private IList<ICard> FoldedCardList { get; }

        /// <inheritdoc/>
        public void Fold()
        {
            // Fold the Palette and add its Cards to the Folded Cards
            IList<ICard> paletteCards = this.Palette.Fold();
            ((List<ICard>)this.FoldedCardList).AddRange(paletteCards);

            // Fold the Hand and add its Cards to the Folded Cards
            IList<ICard> handCards = this.Hand.Fold();
            ((List<ICard>)this.FoldedCardList).AddRange(handCards);
        }

        ////public IList<ICard> EndOfRound()
        ////{
        ////    List<ICard> returnedCards = new List<ICard>();

        ////    if (this.HasFolded)
        ////    {
        ////        returnedCards.AddRange(this.FoldedCardList);
        ////        this.FoldedCardList.Clear();
        ////    }
        ////    else
        ////    {
        ////        foreach (var paletteCard in this.Palette.Cards)
        ////        {
        ////            if(this.ScoringCards.
        ////                )
        ////        }
        ////    }
        ////}
}
}