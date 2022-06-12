using System.Collections.Generic;

namespace ScrumBoard
{
    public class Board
    {
        public static readonly int MAX_COLUMN_AMOUNT = 10;
        public string Title { get; protected set; }
        public List<BoardColumn> ColumnList = new List<BoardColumn>();

        public Board(string title)
        {
            Title = title;
        }

        public bool AppendColumn(BoardColumn column)
        {
            if (ColumnList.Count < MAX_COLUMN_AMOUNT)
            {
                ColumnList.Add(column);

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

            BoardColumn tempColumn = ColumnList[oldIndex];

            ColumnList.RemoveAt(oldIndex);
            ColumnList.Insert(newIndex, tempColumn);

            return true;
        }
        
        public bool RemoveColumn(string columnTitle)
        {
            int columnIndex = ColumnList.FindIndex(column => column.Title == columnTitle);

            if (columnIndex == -1)
            {
                return false;
            }

            ColumnList.RemoveAt(columnIndex);

            return true;
        }

        private bool IsReachable(int index)
        {
            if (index < 0 || index >= ColumnList.Count)
            {
                return false;
            }

            return true;
        }

        public bool RenameColumn(string currName, string newName)
        {
            BoardColumn selectedColumn = ColumnList.Find(column => column.Title == currName);

            if  (selectedColumn == null)
            {
                return false;
            }

            int newColumnNameIndex = ColumnList.FindIndex(column => column.Title == newName);
            if (newColumnNameIndex != -1)
            {
                return false;
            }

            selectedColumn.RenameColumn(newName);

            return true;
        }

        public List<BoardColumn> GetBoardColumns()
        {
            return ColumnList;
        }

        public bool AppendCardToColumn(BoardCard card, string columnTitle = "")
        {
            if (columnTitle == "")
            {
                if (ColumnList.Count > 0)
                {
                    ColumnList[0].AppendCard(card);

                    return true;
                }

                return false;
            }

            int columnIndex = ColumnList.FindIndex(column => column.Title == columnTitle);
            if (columnIndex == -1)
            {
                return false;
            }

            ColumnList[columnIndex].AppendCard(card);

            return true;
        }

        public BoardColumn? FindBoardColumn(string title)
        {
            return ColumnList.Find(column => column.Title == title);
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
