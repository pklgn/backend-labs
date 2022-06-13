// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using ScrumBoard;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ScrumBoardInfrastructure.Models;

public class BoardCardModel : BoardCard
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CardId { get; set; }

    public int ColumnId { get; set; }

    public BoardCardModel(int columnId, string name, string description = "", PriorityType priority = PriorityType.NotImportant) : base(name, description, priority)
    {
        ColumnId = columnId;
    }
}
