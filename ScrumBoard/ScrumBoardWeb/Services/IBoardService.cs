// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using ScrumBoardWeb.DTO;

namespace ScrumBoardWeb.Services;

public interface IBoardService
{
    public void CreateBoard(int id, string title);

    public void RemoveBoard(int index);

    public List<BoardDTO> GetBoards();

    public BoardDTO GetBoard(int boardId);

    public void CreateBoardColumn(int boardId, int columnId, string name);

    public void RemoveBoardColumn(uint columnId);

    public void CreateBoardCard(int id, int columnId, string name, string description, string priority);

    public void RemoveBoardCard(uint cardId);
}
