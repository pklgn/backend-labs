// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.AspNetCore.Mvc;
using ScrumBoardWeb.DTO;
using ScrumBoardWeb.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScrumBoardWeb.Controllers;

[Route("api/boards")]
[ApiController]
public class BoardCardsController : ControllerBase
{
    private readonly IBoardService _boardService;

    public BoardCardsController(IBoardService boardService) => _boardService = boardService;

    // POST api/boards/{boardId}/column/{columnId}/create
    [HttpPost("{boardId}/column/{columnId}/create")]
    public IActionResult CreateBoardCard(int columnId, [FromBody] BoardCardDTO cardDTO)
    {
        try
        {
            _boardService.CreateBoardCard(columnId, cardDTO.Name, cardDTO.Description, cardDTO.Priority);
        }
        catch
        {
            return BadRequest("Couldn't create board card with such parameters");
        }

        return Ok("Board card was successfully created");
    }

    // DELETE api/boards/{boardId}/column/{columnId}/card/{cardId}/remove
    [HttpDelete("{boardId}/column/{columnId}/card/{cardId}/remove")]
    public IActionResult RemoveBoardCard(int cardId)
    {
        try
        {
            _boardService.RemoveBoardCard(cardId);
        }
        catch
        {
            return BadRequest("Couldn't remove board card");
        }

        return Ok("Board card was successfully removed");
    }
}
