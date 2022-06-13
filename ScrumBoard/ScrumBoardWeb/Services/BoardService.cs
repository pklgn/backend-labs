// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using ScrumBoardWeb.DTO;
using ScrumBoardWeb.Repository;


namespace ScrumBoardWeb.Services;

public class BoardService : IBoardService
{
    private readonly IScrumBoardRepository _repository;

    public BoardService(IScrumBoardRepository repository) => _repository = repository;

    public void CreateBoard(string title)
    {

        _repository.CreateBoard(title);

        return;
    }

    public void RemoveBoard(int boardId)
    {
        _repository.RemoveBoard(boardId);

        return;
    }

    public List<BoardDTO> GetBoards()
    {
        return _repository.GetBoardsDTO();
    }

    public BoardDTO GetBoard(int boardId)
    {
        return _repository.GetBoardDTO(boardId);
    }

    public void CreateBoardCard(int columnId, string name, string description, string priority)
    {
        _repository.AddCard(columnId, name, description, priority);

        return;
    }

    public void RemoveBoardCard(int cardId)
    {
        _repository.RemoveCard(cardId);

        return;
    }

    public void CreateBoardColumn(int boardId, string columnTitle)
    {
        _repository.CreateColumn(boardId, columnTitle);

        return;
    }

    public void RemoveBoardColumn(int columnId)
    {
        _repository.RemoveColumn(columnId);

        return;
    }
}
