// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.AspNetCore.Mvc;
using ScrumBoardAPI.DTO;
using ScrumBoardWeb.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScrumBoardWeb.Controllers;

[Route("api/boards")]
[ApiController]
public class BoardCardsController : ControllerBase
{
    private readonly IBoardService _boardService;

    public BoardCardsController(IBoardService boardService) => _boardService = boardService;

    // POST api/boards/{boardIndex}/column/{columnIndex}/create
    [HttpPost("{boardIndex}/column/{columnIndex}/create")]
    public IActionResult CreateBoardCard(int boardIndex, int columnIndex, [FromBody] BoardCardDTO cardDTO)
    {
        try
        {
            _boardService.CreateBoardCard(boardIndex, columnIndex, cardDTO.Name, cardDTO.Description, cardDTO.Priority);
        }
        catch
        {
            return BadRequest("Couldn't create board card with such parameters");
        }

        return Ok("Board card was successfully created");
    }

    // DELETE api/boards/{boardIndex}/column/{columnIndex}/card/{cardIndex}/remove
    [HttpDelete("{boardIndex}/column/{columnIndex}/card/{cardIndex}/remove")]
    public IActionResult RemoveBoardCard(int boardIndex, int columnIndex, int cardIndex)
    {
        try
        {
            _boardService.RemoveBoardCard(boardIndex, columnIndex, cardIndex);
        }
        catch
        {
            return BadRequest("Couldn't remove board card");
        }

        return Ok("Board card was successfully removed");
    }
}
