// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.Extensions.Caching.Memory;
using ScrumBoard;
using ScrumBoardWeb.DTO;

namespace ScrumBoardWeb.Repository;

public class ScrumBoardRepository
{
    private readonly IMemoryCache _memoryCache;
    private const string _memoryCacheBoardKey = "boards";

    public ScrumBoardRepository(IMemoryCache memoryCache) => _memoryCache = memoryCache;

    public void CreateBoard(BoardDTO boardDTO)
    {
        List<Board> boards = GetBoards();

        boards.Add(new Board(boardDTO.Title));

        _memoryCache.Set(_memoryCacheBoardKey, boards);
    }

    public BoardDTO GetBoard(int index)
    {
        List<Board> boards = GetBoards();

        if (boards.Count == 0 || index < 0 || index >= boards.Count)
        {
            
        }
    }

    private List<Board> GetBoards()
    {
        List<Board>? boards = _memoryCache.Get<List<Board>>(_memoryCacheBoardKey);

        if (boards == null)
        {
            boards = new List<Board>();
        }

        return boards;
    }
}
