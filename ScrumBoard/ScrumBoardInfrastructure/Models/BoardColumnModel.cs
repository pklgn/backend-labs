// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using ScrumBoard;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ScrumBoardInfrastructure.Models;

public class BoardColumnModel : BoardColumn
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ColumnId { get; set; }
    
    public int BoardId { get; set; }

    public BoardColumnModel(int boardId, string title) : base(title)
    {
        BoardId = boardId;
    }
}
