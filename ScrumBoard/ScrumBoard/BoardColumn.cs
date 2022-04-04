// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumBoard
{
    class BoardColumn
    {
        private List<BoardCard> _cardList;
        public string Title
        {
            get
            {
                return Title;
            }
            private set
            {
                Title = value;
            }
        }

        public BoardColumn(string title)
        {
            this.Title = title;
        }

        public void AppendCard(BoardCard card)
        {
            _cardList.Add(card);
        }

        public BoardCard? RetrieveCard(int cardIndex)
        {
            if (cardIndex > _cardList.Count || cardIndex < 0)
            {
                return null;
            }

            return _cardList.ElementAt(cardIndex);
        }

        public void RemoveCard(int cardIndex)
        {
            if (cardIndex > _cardList.Count || cardIndex < 0)
            {
                return;
            }

            _cardList.RemoveAt(cardIndex);
        }
    }
}
