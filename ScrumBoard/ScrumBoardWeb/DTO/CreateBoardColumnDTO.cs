// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace ScrumBoardWeb.DTO;

public class CreateBoardColumnDTO
{
    public string Name { get; }

    public CreateBoardColumnDTO(string name) => Name = name;
}
