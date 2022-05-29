using System.Collections.Generic;

namespace ScrumBoard
{
    public class Board
    {
        public static readonly int MAX_COLUMN_AMOUNT = 10;
        public string Title { get; private set; }
        private List<BoardColumn> _columnList = new List<BoardColumn>();

        public Board(string title)
        {
            Title = title;
        }

        public bool AppendColumn(BoardColumn column)
        {
            if (_columnList.Count < MAX_COLUMN_AMOUNT)
            {
                _columnList.Add(column);

                return true;
            }

            return false;
        }

        public bool MoveColumn(int oldIndex, int newIndex)
        {
            if ((oldIndex == newIndex) || !IsReachable(oldIndex) || !IsReachable(newIndex))
            {
                return false;
            }

            BoardColumn tempColumn = _columnList[oldIndex];

            _columnList.RemoveAt(oldIndex);
            _columnList.Insert(newIndex, tempColumn);

            return true;
        }
        
        public bool RemoveColumn(string columnTitle)
        {
            int columnIndex = _columnList.FindIndex(column => column.Title == columnTitle);

            if (columnIndex == -1)
            {
                return false;
            }

            _columnList.RemoveAt(columnIndex);

            return true;
        }

        private bool IsReachable(int index)
        {
            if (index < 0 || index >= _columnList.Count)
            {
                return false;
            }

            return true;
        }

        public bool RenameColumn(string currName, string newName)
        {
            BoardColumn selectedColumn = _columnList.Find(column => column.Title == currName);

            if  (selectedColumn == null)
            {
                return false;
            }

            int newColumnNameIndex = _columnList.FindIndex(column => column.Title == newName);
            if (newColumnNameIndex != -1)
            {
                return false;
            }

            selectedColumn.RenameColumn(newName);

            return true;
        }

        public List<BoardColumn> GetBoardColumns()
        {
            return _columnList;
        }

        public bool AppendCardToColumn(BoardCard card, string columnTitle = "")
        {
            if (columnTitle == "")
            {
                if (_columnList.Count > 0)
                {
                    _columnList[0].AppendCard(card);

                    return true;
                }

                return false;
            }

            int columnIndex = _columnList.FindIndex(column => column.Title == columnTitle);
            if (columnIndex == -1)
            {
                return false;
            }

            _columnList[columnIndex].AppendCard(card);

            return true;
        }

        public BoardColumn? FindBoardColumn(string title)
        {
            return _columnList.Find(column => column.Title == title);
        }

        public BoardCard? FindBoardCard(string columnTitle, string cardTitle)
        {
            BoardColumn? column = FindBoardColumn(columnTitle);
            if (column == null)
            {
                return null;
            }

            return column.GetBoardCards().Find(card => card.Name == cardTitle);
        }
    }
}
