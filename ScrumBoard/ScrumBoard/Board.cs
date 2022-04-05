using System.Collections.Generic;

namespace ScrumBoard
{
    class Board
    {
        public readonly static int MAX_COLUMN_AMOUNT = 10;
        public string Title { get; private set; }
        private List<BoardColumn> _columnList;

        public Board(string title)
        {
            this.Title = title;
        }

        private int _columnIndex = 0;
        public void AppendColumn(BoardColumn column)
        {
            if (_columnIndex < MAX_COLUMN_AMOUNT)
            {
                _columnList.Add(column);
                _columnIndex++;
            }

            return;
        }

        public void MoveColumn(int oldIndex, int newIndex)
        {
            if ((oldIndex == newIndex) || (0 > oldIndex) || (oldIndex >= _columnList.Count) || (0 > newIndex) ||
                (newIndex >= _columnList.Count))
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
    }
}
