// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using ScrumBoardWeb.DTO;


namespace ScrumBoardWeb.Services;

public interface IBoardService
{
    public void CreateBoard(string title);

    public void RemoveBoard(int boardId);

    public List<BoardDTO> GetBoards();

    public BoardDTO GetBoard(int boardId);

    public void CreateBoardColumn(int boardId, string name);

    public void RemoveBoardColumn(int columnId);

    public void CreateBoardCard(int columnId, string name, string description, string priority);

    public void RemoveBoardCard(int cardId);
}
