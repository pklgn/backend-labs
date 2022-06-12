// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace ScrumBoardWeb.Exceptions;

public class BoardCardNotFoundException : System.Exception
{
    public BoardCardNotFoundException() : base("Board card wasn't found")
    {
    }
}
