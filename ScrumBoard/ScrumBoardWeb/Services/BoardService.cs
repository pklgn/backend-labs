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

    public void CreateBoard(string title)
    {
        CreateBoardDTO board = new CreateBoardDTO(title);

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

    public void CreateBoardCard(int boardIndex, int columnIndex, string name, string description, string priority)
    {
        BoardCardDTO card = new BoardCardDTO(name, description, priority);
        
        _repository.AddCard(boardIndex, columnIndex, card);

        return;
    }

    public void RemoveBoardCard(int boardIndex, int columnIndex, int cardIndex)
    {
        _repository.RemoveCard(boardIndex, columnIndex, cardIndex);

        return;
    }

    public void CreateBoardColumn(int boardIndex, string name)
    {
        CreateBoardColumnDTO column = new CreateBoardColumnDTO(name);

        _repository.CreateColumn(boardIndex, column);

        return;
    }

    public void RemoveBoardColumn(int boardIndex, int columnIndex)
    {
        _repository.RemoveColumn(boardIndex, columnIndex);

        return;
    }
}
