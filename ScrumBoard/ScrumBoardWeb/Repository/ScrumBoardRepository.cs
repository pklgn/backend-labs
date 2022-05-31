// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Linq;
using Microsoft.Extensions.Caching.Memory;
using ScrumBoard;
using ScrumBoardAPI.DTO;
using ScrumBoardWeb.DTO;
using ScrumBoardWeb.Exception;

namespace ScrumBoardWeb.Repository;

public class ScrumBoardRepository : IScrumBoardRepository
{
    private readonly IMemoryCache _memoryCache;
    private const string _memoryCacheBoardKey = "boards";

    public ScrumBoardRepository(IMemoryCache memoryCache) => _memoryCache = memoryCache;

    public void CreateBoard(CreateBoardDTO boardDTO)
    {
        List<Board> boards = GetBoards();

        boards.Add(new Board(boardDTO.Title));

        _memoryCache.Set(_memoryCacheBoardKey, boards);
    }

    public void RemoveBoard(int index)
    {
        List<Board> boards = GetBoards();

        try
        {
            boards.RemoveAt(index);
        }
        catch
        {
            throw new BoardIndexOutOfRangeException();
        }

        _memoryCache.Set(_memoryCacheBoardKey, boards);
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
        List<Board>? boards = _memoryCache.Get<List<Board>>(_memoryCacheBoardKey);

        List<BoardDTO> boardsDTO = new List<BoardDTO>();

        if (boards == null)
        {
            return boardsDTO;
        }

        foreach (var board in boards)
        {
            List<BoardColumnDTO> boardColumnsDTO = new List<BoardColumnDTO>();
            foreach (var column in board.GetBoardColumns())
            {
                boardColumnsDTO.Add(new BoardColumnDTO(column));
            }
            boardsDTO.Add(new BoardDTO(board.Title, boardColumnsDTO));
        }

        return boardsDTO;
    }

    public List<Board> GetBoards()
    {
        List<Board>? boards = _memoryCache.Get<List<Board>>(_memoryCacheBoardKey);

        if (boards == null)
        {
            return new List<Board>();
        }

        return boards;
    }

    public void CreateColumn(int boardIndex, CreateBoardColumnDTO column)
    {
        List<Board> boards = GetBoards();

        if (boards.Count == 0 || boardIndex < 0 || boardIndex >= boards.Count)
        {
            throw new BoardIndexOutOfRangeException();
        }

        boards[boardIndex].AppendColumn(new BoardColumn(column.Name));

        _memoryCache.Set(_memoryCacheBoardKey, boards);
    }

    public void RemoveColumn(int boardIndex, int columnIndex)
    {
        List<Board> boards = GetBoards();

        if (boards.Count == 0 || boardIndex < 0 || boardIndex >= boards.Count)
        {
            throw new BoardIndexOutOfRangeException();
        }

        Board board = boards[boardIndex];

        List<BoardColumn> columns = board.GetBoardColumns();

        if (columns.Count == 0 || boardIndex < 0 || boardIndex >= columns.Count)
        {
            throw new BoardColumnIndexOutOfRangeException();
        }

        columns.RemoveAt(columnIndex);

        _memoryCache.Set(_memoryCacheBoardKey, boards);
    }

    public void AddCard(int boardIndex, int columnIndex, BoardCardDTO card)
    {
        List<Board> boards = GetBoards();

        if (boards.Count == 0 || boardIndex < 0 || boardIndex >= boards.Count)
        {
            throw new BoardIndexOutOfRangeException();
        }

        Board board = boards[boardIndex];

        List<BoardColumn> columns = board.GetBoardColumns();

        if (columns.Count == 0 || boardIndex < 0 || boardIndex >= columns.Count)
        {
            throw new BoardColumnIndexOutOfRangeException();
        }

        columns[columnIndex].AppendCard(new BoardCard(card.Name, card.Description, BoardCard.GetPriorityTypeFromString(card.Priority)));

        _memoryCache.Set(_memoryCacheBoardKey, boards);
    }

    public void RemoveCard(int boardIndex, int columnIndex, int cardIndex)
    {
        List<Board> boards = GetBoards();

        if (boards.Count == 0 || boardIndex < 0 || boardIndex >= boards.Count)
        {
            throw new BoardIndexOutOfRangeException();
        }

        Board board = boards[boardIndex];

        List<BoardColumn> columns = board.GetBoardColumns();

        if (columns.Count == 0 || boardIndex < 0 || boardIndex >= columns.Count)
        {
            throw new BoardColumnIndexOutOfRangeException();
        }

        BoardColumn column = columns[columnIndex];

        try
        {
            column.GetBoardCards().RemoveAt(cardIndex);
        }
        catch
        {
            throw new BoardCardIndexOutOfRangeException();
        }

        _memoryCache.Set(_memoryCacheBoardKey, boards);
    }
}
