// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.AspNetCore.Mvc;
using ScrumBoardWeb.DTO;
using ScrumBoardWeb.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScrumBoardWeb.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BoardColumnsController : ControllerBase
{
    private readonly IBoardService _boardService;

    public BoardColumnsController(IBoardService boardService) => _boardService = boardService;

    // POST api/boards/{boardId}/create/column
    [HttpPost("{boardId}/create/column")]
    public IActionResult CreateBoardColumn(int boardId, int columnId, [FromBody] CreateBoardColumnDTO columnDTO)
    {
        //try
        //{
        //    _boardService.CreateBoardColumn(boardId, columnId, columnDTO.Name);
        //}
        //catch
        //{
        //    return BadRequest("Couldn't create board column with such parameters");
        //}
        _boardService.CreateBoardColumn(boardId, columnId, columnDTO.Name);

        return Ok("Board column was successfully created");
    }

    // DELETE api/boards/{boardIndex}/column/{columnIndex}/remove
    [HttpDelete("{boardIndex}/column/{columnIndex}/remove")]
    public IActionResult RemoveBoardColumn(uint id)
    {
        try
        {
            _boardService.RemoveBoardColumn(id);
        }
        catch
        {
            return BadRequest("Couldn't remove board column");
        }

        return Ok("Board column was successfully removed");
    }
}
