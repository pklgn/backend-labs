using System.Collections.Generic;
using System.Linq;

namespace ScrumBoard
{
    public class BoardColumn
    {
        public List<BoardCard> CardList = new List<BoardCard>();
        public string Title { get; protected set; }

        public BoardColumn(string title)
        {
            Title = title;
        }

        public void AppendCard(BoardCard card)
        {
            CardList.Add(card);
        }   

        public bool RemoveCard(string cardName)
        {
            BoardCard boardCard = CardList.Find(card => card.Name == cardName);
            if (boardCard != null)
            {
                CardList.Remove(boardCard);

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
            return CardList;
        }
    }
}
