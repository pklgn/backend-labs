// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using ScrumBoardWeb.DTO;

namespace ScrumBoardWeb.Services;

public interface IBoardService
{
    public void CreateBoard(string title);

    public void RemoveBoard(int index);

    public List<BoardDTO> GetBoards();

    public BoardDTO GetBoard(int index);

    public void CreateBoardColumn(int boardIndex, string name);

    public void RemoveBoardColumn(int boardIndex, int columnIndex);

    public void CreateBoardCard(int boardIndex, int columnIndex, string name, string description, string priority);

    public void RemoveBoardCard(int boardIndex, int columnIndex, int cardIndex);
}
