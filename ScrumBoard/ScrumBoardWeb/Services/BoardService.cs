// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using ScrumBoardWeb.Repository;

namespace ScrumBoardWeb.Services;

public class BoardService : IBoardService
{
    private readonly ScrumBoardRepository _repository;

    public BoardService(ScrumBoardRepository repository) => _repository = repository;

    public void CreateBoard()
    {


        return;
    }
    public void CreateBoardCard() => throw new NotImplementedException();
    public void CreateBoardColumn() => throw new NotImplementedException();
    public void RemoveBoard() => throw new NotImplementedException();
}
