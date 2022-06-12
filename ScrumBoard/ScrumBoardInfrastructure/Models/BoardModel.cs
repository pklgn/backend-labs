// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using ScrumBoard;
using System.ComponentModel.DataAnnotations;

namespace ScrumBoardInfrastructure.Models;

public class BoardModel : Board
{
    [Key]
    public int BoardId { get; set; }

    public BoardModel(int boardId, string title) : base(title)
    {
        BoardId = boardId;
    }
}
