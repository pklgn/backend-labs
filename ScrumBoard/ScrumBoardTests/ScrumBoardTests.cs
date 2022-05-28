using System;
using Xunit;
using ScrumBoard;

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

        
    }
}
