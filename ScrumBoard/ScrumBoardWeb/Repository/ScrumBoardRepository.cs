// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Linq;
using Microsoft.Extensions.Caching.Memory;
using ScrumBoard;
using ScrumBoardAPI.DTO;
using ScrumBoardWeb.DTO;
using ScrumBoardWeb.Exception;
using ScrumBoardInfrastructure;
using Microsoft.EntityFrameworkCore;
using ScrumBoardInfrastructure.Models;

namespace ScrumBoardWeb.Repository;

public class ScrumBoardRepository : IScrumBoardRepository
{
    private readonly ScrumBoardContext _dbContext;

    public ScrumBoardRepository(ScrumBoardContext dbContext) => _dbContext = dbContext;

    public void CreateBoard(CreateBoardDTO boardDTO)
    {
        _dbContext.Boards.Add(new BoardModel(boardDTO.Id, boardDTO.Title));

        _dbContext.SaveChanges();
    }

    public void RemoveBoard(int id)
    {
        try
        {
            var board = _dbContext.Boards.First(x => x.BoardId == id);
            _dbContext.Boards.Remove(board);
        }
        catch
        {
            throw new BoardIndexOutOfRangeException();
        }

        _dbContext.SaveChanges();
    }

    public BoardDTO GetBoardDTO(int index)
    {
        List<BoardDTO> boards = GetBoardsDTO();

        if (boards.Count == 0 || index < 0 || index >= boards.Count)
        {
            throw new BoardIndexOutOfRangeException();
        }

        return boards[index];
    }

    public List<BoardDTO> GetBoardsDTO()
    {
        List<BoardModel> boards = _dbContext.Boards.ToList();
        List<BoardColumnModel> columns = _dbContext.BoardColumns.ToList();
        List<BoardCardModel> cards = _dbContext.BoardCards.ToList();

        List<BoardDTO> boardsDTO = new List<BoardDTO>();

        if (boards == null || boards.Count == 0)
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

    public void CreateColumn(int boardId, CreateBoardColumnDTO column)
    {
        _dbContext.BoardColumns.Add(new BoardColumnModel(column.Id, boardId, column.Name));

        _dbContext.SaveChanges();
    }

    public void RemoveColumn(uint columnId)
    {
        try
        {
            var column = _dbContext.BoardColumns.First(c => c.ColumnId == columnId);
            _dbContext.Remove(column);
        }
        catch
        {
            throw new BoardColumnIndexOutOfRangeException();
        }

        _dbContext.SaveChanges();
    }

    public void AddCard(int id, int columnId, BoardCardDTO card)
    {
        _dbContext.BoardCards.Add(new BoardCardModel(id, columnId, card.Name, card.Description, BoardCard.GetPriorityTypeFromString(card.Priority)));

        _dbContext.SaveChanges();
    }

    public void RemoveCard(uint cardId)
    {
        try
        {
            var card = _dbContext.BoardCards.First(x => x.CardId == cardId);
            _dbContext.BoardCards.Remove(card);
        }
        catch
        {
            throw new BoardCardIndexOutOfRangeException();
        }

        _dbContext.SaveChanges();
    }
}
