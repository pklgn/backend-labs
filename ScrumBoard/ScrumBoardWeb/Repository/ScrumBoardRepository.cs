// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using ScrumBoard;
using ScrumBoardWeb.DTO;
using ScrumBoardWeb.Exceptions;
using ScrumBoardInfrastructure;
using ScrumBoardInfrastructure.Models;

namespace ScrumBoardWeb.Repository;

public class ScrumBoardRepository : IScrumBoardRepository
{
    private readonly ScrumBoardContext _dbContext;

    public ScrumBoardRepository(ScrumBoardContext dbContext) => _dbContext = dbContext;

    public void CreateBoard(string title)
    {
        try
        {
            _dbContext.Boards.Add(new BoardModel(title));
        }
        catch
        {
            throw new DataOperationNotValidException();
        }

        _dbContext.SaveChanges();
    }

    public void RemoveBoard(int boardId)
    {
        var board = _dbContext.Boards.First(x => x.BoardId == boardId);

        try
        {
            _dbContext.Boards.Remove(board);
        }
        catch
        {
            throw new BoardNotFoundException();
        }

        _dbContext.SaveChanges();
    }

    public BoardDTO GetBoardDTO(int boardId)
    {
        List<BoardDTO> boards = GetBoardsDTO();

        var rawBoardsList = _dbContext.Boards.ToList();
        int index = rawBoardsList.FindIndex(b => b.BoardId == boardId);

        return boards[index];
    }

    public List<BoardDTO> GetBoardsDTO()
    {
        List<BoardModel> boards = _dbContext.Boards.ToList();
        List<BoardColumnModel> columns = _dbContext.BoardColumns.ToList();
        List<BoardCardModel> cards = _dbContext.BoardCards.ToList();

        List<BoardDTO> boardsDTO = new List<BoardDTO>();

        if (boards.Count == 0)
        {
            return boardsDTO;
        }

        foreach (var board in boards)
        {
            List<BoardColumnDTO> boardColumnsDTO = new List<BoardColumnDTO>();
            foreach (var column in columns)
            {
                List<BoardCardDTO> columnCardsDTO = new List<BoardCardDTO>();
                foreach (var card in cards)
                {
                    if (card.ColumnId == column.ColumnId)
                    {
                        columnCardsDTO.Add(new BoardCardDTO(card.Name, card.Description, BoardCard.GetPriorityTypeToString(card.Priority)));
                    }
                }
                BoardColumnDTO currColumn = new BoardColumnDTO(column.Title, columnCardsDTO);
                if (column.BoardId == board.BoardId)
                {
                    boardColumnsDTO.Add(currColumn);
                }
            }
            boardsDTO.Add(new BoardDTO(board.Title, boardColumnsDTO));
        }

        return boardsDTO;
    }

    public void CreateColumn(int boardId, string columnTitle)
    {
        _dbContext.BoardColumns.Add(new BoardColumnModel(boardId, columnTitle));

        _dbContext.SaveChanges();
    }

    public void RemoveColumn(int columnId)
    {
        var column = _dbContext.BoardColumns.First(c => c.ColumnId == columnId);

        try
        {
            _dbContext.Remove(column);
        }
        catch
        {
            throw new BoardColumnNotFoundException();
        }

        _dbContext.SaveChanges();
    }

    public void AddCard(int columnId, string name, string description, string priority)
    {
        try
        {
            _dbContext.BoardCards.Add(new BoardCardModel(columnId, name, description, BoardCard.GetPriorityTypeFromString(priority)));
        }
        catch
        {
            throw new DataOperationNotValidException();
        }

        _dbContext.SaveChanges();
    }

    public void RemoveCard(uint cardId)
    {
        var card = _dbContext.BoardCards.First(x => x.CardId == cardId);

        try
        {
            _dbContext.BoardCards.Remove(card);
        }
        catch
        {
            throw new BoardCardNotFoundException();
        }

        _dbContext.SaveChanges();
    }
}
