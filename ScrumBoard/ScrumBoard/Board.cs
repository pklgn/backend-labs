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

        public void AppendColumn(BoardColumn column)
        {
            if (_columnList.Count < MAX_COLUMN_AMOUNT)
            {
                _columnList.Add(column);
            }

            return;
        }

        public void MoveColumn(int oldIndex, int newIndex)
        {
            if ((oldIndex == newIndex) || !IsReachable(oldIndex) || !IsReachable(newIndex))
            {
                return;
            }

            BoardColumn tempColumn = _columnList[oldIndex];

            _columnList.RemoveAt(oldIndex);

            if (newIndex > oldIndex)
            {
                newIndex--;
            }

            _columnList.Insert(newIndex, tempColumn);
        }
        
        public void RemoveColumn(int columnIndex)
        {
            _columnList.RemoveAt(columnIndex);
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
            foreach (BoardColumn column in _columnList)
            {
                if (column.Title == currName)
                {
                    column.RenameColumn(newName);
                }

                return true;
            }

            return false;
        }

        public List<BoardColumn> GetBoardColumns()
        {
            return _columnList;
        }
    }
}
