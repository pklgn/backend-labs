// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using ScrumBoard;
using System.ComponentModel.DataAnnotations;


namespace ScrumBoardInfrastructure.Models;

public class BoardCardModel : BoardCard
{
    [Key]
    public int CardId { get; set; }

    public int ColumnId { get; set; }

    public BoardCardModel(int cardId, int columnId, string name, string description = "", PriorityType priority = PriorityType.NotImportant) : base(name, description, priority)
    {
        CardId = cardId;
        ColumnId = columnId;
    }
}
