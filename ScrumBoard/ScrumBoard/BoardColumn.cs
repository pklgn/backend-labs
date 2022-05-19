using System.Collections.Generic;
using System.Linq;

namespace ScrumBoard
{
    public class BoardColumn
    {
        private List<BoardCard> _cardList = new List<BoardCard>();
        public string Title { get; private set; }

        public BoardColumn(string title)
        {
            Title = title;
        }

        public void AppendCard(BoardCard card)
        {
            _cardList.Add(card);
        }   

        public bool RemoveCard(string cardName)
        {
            BoardCard boardCard = _cardList.Find(card => card.Name == cardName);
            if (boardCard != null)
            {
                _cardList.Remove(boardCard);

                return true;
            }
            
            return false;
        }

        public bool RenameCard(string replacementName)
        {
            return true;
        }

        public void RenameColumn(string title)
        {
            Title = title;
        }

        public List<BoardCard> GetBoardCards()
        {
            return _cardList;
        }
    }
}
