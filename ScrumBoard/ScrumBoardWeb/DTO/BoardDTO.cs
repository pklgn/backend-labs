// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace ScrumBoardWeb.DTO;

public class BoardDTO
{
    public string Title { get; }

    public List<BoardColumnDTO> Columns { get; set; }

    public BoardDTO(string title, List<BoardColumnDTO> columns)
    {
        Title = title;
        Columns = columns;
    }
}
