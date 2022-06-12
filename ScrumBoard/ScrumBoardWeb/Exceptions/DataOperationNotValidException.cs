// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace ScrumBoardWeb.Exceptions;

public class DataOperationNotValidException : System.Exception
{
    public DataOperationNotValidException() : base("Cannot perform such data conversion")
    {
    }
}
