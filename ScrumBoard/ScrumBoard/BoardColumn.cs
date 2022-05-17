using System.Collections.Generic;
using System.Linq;

namespace ScrumBoard
{
    public class BoardColumn
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
            Title = title;
        }

        public void AppendCard(BoardCard card)
        {
            _cardList.Add(card);
        }

        public BoardCard RetrieveCard(int cardIndex)
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
