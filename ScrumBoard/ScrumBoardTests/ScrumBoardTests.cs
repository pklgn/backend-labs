using System;
using Xunit;
using ScrumBoard;
using System.Collections.Generic;

namespace ScrumBoardTests
{
    public class ScrumBoardTests
    {
        private string _testBoardTitle = "board";
        private string _testColumnTitle = "column";
        private string _testCardTitle = "card";
        private string _testCardDescription = "description";
        private BoardCard.PriorityType _testCardPriority = BoardCard.PriorityType.Common;

        [Fact]
        public void CreateBoard_ConstructorHasTitleArgument()
        {
            //Arrange
            Board board = new Board(_testBoardTitle);

            //Act

            //Assert
            Assert.Equal(_testBoardTitle, board.Title);
        }

        [Fact]
        public void CreateColumn_ArgumentIsColumnName_AddColumnToBoard()
        {
            //Arrange
            Board board = new Board(_testBoardTitle);
            BoardColumn column = new BoardColumn(_testColumnTitle);

            //Act
            bool isSuccessful = board.AppendColumn(column);

            //Assert
            Assert.True(isSuccessful);
            Assert.Single(board.GetBoardColumns());
            Assert.Equal(_testColumnTitle, board.GetBoardColumns()[0].Title);
        }

        [Fact]
        public void CreateColumn_ArgumentHasExistingColumnName()
        {
            //Arrange
            Board board = new Board(_testBoardTitle);
            BoardColumn firstColumn = new BoardColumn(_testColumnTitle);
            BoardColumn secondColumn = new BoardColumn(_testColumnTitle);

            //Act
            bool isFirstSuccessful = board.AppendColumn(firstColumn);
            bool isSecondSuccessful = board.AppendColumn(secondColumn);

            //Assert
            Assert.True(isFirstSuccessful);
            Assert.True(isSecondSuccessful);
            Assert.Equal(2, board.GetBoardColumns().Count);
            Assert.Collection(board.GetBoardColumns(),
                firstColumn => Assert.Equal(_testColumnTitle, firstColumn.Title),
                secondColumn => Assert.Equal(_testColumnTitle, secondColumn.Title)
            );
        }

        [Fact]
        public void AppendColumn_AddMoreThanLimitColumnAmount()
        {
            //Arrange
            Board board = new Board(_testBoardTitle);
            List<BoardColumn> boardColumns = new List<BoardColumn>();

            for (int i = 0; i < Board.MAX_COLUMN_AMOUNT + 1; ++i)
            {
                boardColumns.Add(new BoardColumn("column" + i));
            }

            //Act
            bool isSuccessful = true;
            foreach (BoardColumn column in boardColumns)
            {
                isSuccessful = board.AppendColumn(column);
            }

            //Assert
            Assert.Equal(Board.MAX_COLUMN_AMOUNT, board.GetBoardColumns().Count);
            Assert.False(isSuccessful);
        }
    }
}
