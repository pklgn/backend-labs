// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using ScrumBoard;
using ScrumBoardWeb.DTO;
using ScrumBoardInfrastructure.Models;

namespace ScrumBoardWeb.Repository;

public interface IScrumBoardRepository
{
    public void CreateBoard(string title);

    public void RemoveBoard(int boardId);

    public BoardDTO GetBoardDTO(int boardId);

    public List<BoardDTO> GetBoardsDTO();

    public void CreateColumn(int boardId, string columnTitle);

    public void RemoveColumn(int columnId);

    public void AddCard(int columnId, string name, string description, string priority);

    public void RemoveCard(uint cardId);
}
