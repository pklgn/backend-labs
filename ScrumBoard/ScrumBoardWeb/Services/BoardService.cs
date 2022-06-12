// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using ScrumBoard;
using ScrumBoardAPI.DTO;
using ScrumBoardWeb.DTO;
using ScrumBoardWeb.Repository;

namespace ScrumBoardWeb.Services;

public class BoardService : IBoardService
{
    private readonly IScrumBoardRepository _repository;

    public BoardService(IScrumBoardRepository repository) => _repository = repository;

    public void CreateBoard(int id, string title)
    {
        CreateBoardDTO board = new CreateBoardDTO(id, title);

        _repository.CreateBoard(board);

        return;
    }

    public void RemoveBoard(int index)
    {
        _repository.RemoveBoard(index);

        return;
    }

    public List<BoardDTO> GetBoards()
    {
        return _repository.GetBoardsDTO();
    }

    public BoardDTO GetBoard(int index)
    {
        return _repository.GetBoardDTO(index);
    }

    public void CreateBoardCard(int id, int columnId, string name, string description, string priority)
    {
        BoardCardDTO card = new BoardCardDTO(name, description, priority);
        
        _repository.AddCard(id, columnId, card);

        return;
    }

    public void RemoveBoardCard(uint cardId)
    {
        _repository.RemoveCard(cardId);

        return;
    }

    public void CreateBoardColumn(int boardId, int columnId, string name)
    {
        CreateBoardColumnDTO column = new CreateBoardColumnDTO(columnId, name);

        _repository.CreateColumn(boardId, column);

        return;
    }

    public void RemoveBoardColumn(uint columnId)
    {
        _repository.RemoveColumn(columnId);

        return;
    }
}
