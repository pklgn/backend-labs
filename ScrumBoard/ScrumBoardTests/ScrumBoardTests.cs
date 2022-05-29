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

        [Fact]
        public void AppendCardToColumn_ColumnDoesntExist()
        {
            //Arrange
            Board board = new Board(_testBoardTitle);
            BoardCard card = new BoardCard(_testCardTitle, _testCardDescription, _testCardPriority);

            //Act
            bool isSuccessful = board.AppendCardToColumn(card);

            //Assert
            Assert.False(isSuccessful);
        }

        [Fact]
        public void AppendCardToColumn_ColumnDoesExistButNotSpecified()
        {
            //Arrange
            Board board = new Board(_testBoardTitle);
            BoardColumn column = new BoardColumn(_testColumnTitle);
            BoardCard card = new BoardCard(_testCardTitle, _testCardDescription, _testCardPriority);
            board.AppendColumn(column);

            //Act
            bool isSuccessful = board.AppendCardToColumn(card);

            //Assert
            Assert.True(isSuccessful);
            Assert.Single(board.GetBoardColumns()[0].GetBoardCards());
            Assert.Equal(_testCardTitle, board.GetBoardColumns()[0].GetBoardCards()[0].Name);
        }

        [Fact]
        public void AppendCardToColumn_ColumnDoesExistAndSpecified()
        {
            //Arrange
            Board board = new Board(_testBoardTitle);
            BoardColumn column = new BoardColumn(_testColumnTitle);
            BoardCard card = new BoardCard(_testCardTitle, _testCardDescription, _testCardPriority);
            board.AppendColumn(column);

            //Act
            bool isSuccessful = board.AppendCardToColumn(card, _testColumnTitle);

            //Assert
            Assert.True(isSuccessful);
            Assert.Single(board.GetBoardColumns()[0].GetBoardCards());
            Assert.Equal(_testCardTitle, board.GetBoardColumns()[0].GetBoardCards()[0].Name);
        }

        [Fact]
        public void CreateColumn_ContructorHasCardName()
        {
            //Arrange
            BoardCard card = new BoardCard(_testCardTitle);

            //Act

            //Assert
            Assert.Equal(_testCardTitle, card.Name);
            Assert.Equal("", card.Description);
            Assert.Equal(BoardCard.PriorityType.NoPriority, card.Priority);
        }

        [Fact]
        public void CreateColumn_ContructorHasCardNameAndDescription()
        {
            //Arrange
            BoardCard card = new BoardCard(_testCardTitle, _testCardDescription);

            //Act

            //Assert
            Assert.Equal(_testCardTitle, card.Name);
            Assert.Equal(_testCardDescription, card.Description);
            Assert.Equal(BoardCard.PriorityType.NoPriority, card.Priority);
        }

        [Fact]
        public void CreateColumn_ContructorHasCardNameAndDescriptionWithPriority()
        {
            //Arrange
            BoardCard card = new BoardCard(_testCardTitle, _testCardDescription, _testCardPriority);

            //Act

            //Assert
            Assert.Equal(_testCardTitle, card.Name);
            Assert.Equal(_testCardDescription, card.Description);
            Assert.Equal(_testCardPriority, card.Priority);
        }

        [Fact]
        public void RenameColumn_ColumnExists()
        {
            //Arrange
            Board board = new Board(_testBoardTitle);
            BoardColumn column = new BoardColumn(_testColumnTitle);
            board.AppendColumn(column);
            string newColumnName = _testColumnTitle + "1";

            //Act
            board.RenameColumn(_testColumnTitle, newColumnName);

            //Assert
            Assert.Equal(newColumnName, board.GetBoardColumns()[0].Title);
        }

        [Fact]
        public void RemoveColumn_ColumnExists()
        {
            //Arrange
            Board board = new Board(_testBoardTitle);
            BoardColumn column = new BoardColumn(_testColumnTitle);
            board.AppendColumn(column);

            //Act
            board.RemoveColumn(_testColumnTitle);

            //Assert
            Assert.Empty(board.GetBoardColumns());
        }

        [Fact]
        public void RenameColumn_ColumnDoesntExists()
        {
            //Arrange
            Board board = new Board(_testBoardTitle);
            BoardColumn column = new BoardColumn(_testColumnTitle);
            board.AppendColumn(column);
            string newColumnName = _testColumnTitle + "1";

            //Act
            bool isSuccessful = board.RenameColumn(newColumnName, newColumnName);

            //Assert
            Assert.False(isSuccessful);
        }

        [Fact]
        public void RemoveColumn_ColumnDoesntExists()
        {
            //Arrange
            Board board = new Board(_testBoardTitle);
            BoardColumn column = new BoardColumn(_testColumnTitle);
            board.AppendColumn(column);

            //Act
            bool isSuccessful = board.RemoveColumn(_testColumnTitle + "1");

            //Assert
            Assert.False(isSuccessful);
        }

        [Fact]
        public void MoveColumn_ColumnExist()
        {
            //Arrange
            Board board = new Board(_testBoardTitle);
            BoardColumn firstColumn = new BoardColumn(_testColumnTitle + "1");
            BoardColumn secondColumn = new BoardColumn(_testColumnTitle + "2");
            board.AppendColumn(firstColumn);
            board.AppendColumn(secondColumn);

            //Act
            bool isSuccessful = board.MoveColumn(0, 1);

            //Assert
            Assert.True(isSuccessful);
            Assert.Equal(_testColumnTitle + "2", board.GetBoardColumns()[0].Title);
        }

        [Fact]
        public void MoveColumn_ColumnOutOfRange()
        {
            //Arrange
            Board board = new Board(_testBoardTitle);
            BoardColumn firstColumn = new BoardColumn(_testColumnTitle + "1");
            board.AppendColumn(firstColumn);

            //Act
            bool isSuccessful = board.MoveColumn(0, 2);

            //Assert
            Assert.False(isSuccessful);
            Assert.Single(board.GetBoardColumns());
        }
    }
}
