// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace ScrumBoardWeb.Services;

public interface IBoardService
{
    public void CreateBoard();
    public void RemoveBoard();

    public void CreateBoardColumn();

    public void CreateBoardCard();

}
