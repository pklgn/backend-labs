// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace ScrumBoardWeb.Exception;

public class BoardCardIndexOutOfRangeException : System.Exception
{
    public BoardCardIndexOutOfRangeException() : base("Board card index is out of range")
    {
    }
}
