// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace ScrumBoardWeb.Exception;

public class BoardIndexOutOfRangeException : System.Exception
{
    public BoardIndexOutOfRangeException() : base("Board index is out of range")
    {
    }
}
