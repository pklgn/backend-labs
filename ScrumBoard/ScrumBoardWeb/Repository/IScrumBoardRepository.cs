﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using ScrumBoard;
using ScrumBoardWeb.DTO;
using ScrumBoardInfrastructure.Models;

namespace ScrumBoardWeb.Repository;

public interface IScrumBoardRepository
{
    public void CreateBoard(CreateBoardDTO boardDTO);

    public void RemoveBoard(int index);

    public BoardDTO GetBoardDTO(int boardId);

    public List<BoardDTO> GetBoardsDTO();

    public void CreateColumn(int boardId, CreateBoardColumnDTO column);

    public void RemoveColumn(uint columnId);

    public void AddCard(int cardId, int columnId, BoardCardDTO card);

    public void RemoveCard(uint cardId);
}
