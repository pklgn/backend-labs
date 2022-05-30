// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using ScrumBoardAPI.DTO;

namespace ScrumBoardWeb.DTO;

public class BoardDTO
{
    public string Title { get; set; }

    public IEnumerable<BoardColumnDTO> Columns { get; set; }

    public BoardDTO(string title, IEnumerable<BoardColumnDTO> columns)
    {
        Title = title;
        Columns = columns;
    }
}
