// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace ScrumBoardWeb.DTO;

public class CreateBoardColumnDTO
{
    public int Id { get; set; }
    public string Name { get; }

    public CreateBoardColumnDTO(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
