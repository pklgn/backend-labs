// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using ScrumBoard;
using ScrumBoardAPI.DTO;
using ScrumBoardWeb.DTO;

namespace ScrumBoardWeb.Repository;

public interface IScrumBoardRepository
{
    public void CreateBoard(CreateBoardDTO boardDTO);

    public void RemoveBoard(int index);

    public BoardDTO GetBoardDTO(int index);

    public List<BoardDTO> GetBoardsDTO();

    public List<Board> GetBoards();

    public void CreateColumn(int boardIndex, CreateBoardColumnDTO column);

    public void RemoveColumn(int boardIndex, int columnIndex);

    public void AddCard(int boardIndex, int columnIndex, BoardCardDTO card);

    public void RemoveCard(int boardIndex, int columnIndex, int cardIndex);
}
