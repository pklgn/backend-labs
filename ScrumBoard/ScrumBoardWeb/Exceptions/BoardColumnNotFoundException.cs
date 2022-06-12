// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace ScrumBoardWeb.Exceptions;

public class BoardColumnNotFoundException : System.Exception
{
    public BoardColumnNotFoundException() : base("Board column wasn't found")
    {
    }
}
