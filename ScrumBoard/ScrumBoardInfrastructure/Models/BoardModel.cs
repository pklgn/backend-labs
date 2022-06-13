// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using ScrumBoard;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ScrumBoardInfrastructure.Models;

public class BoardModel : Board
{
    [Key, Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BoardId { get; set; }

    public BoardModel(string title) : base(title)
    {
    }
}
