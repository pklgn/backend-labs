// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.AspNetCore.Mvc;
using ScrumBoardAPI.DTO;
using ScrumBoardWeb.DTO;
using ScrumBoardWeb.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScrumBoardWeb.Controllers;

[Route("api/boards")]
[ApiController]
public class BoardsController : ControllerBase
{
    private readonly IBoardService _boardService;

    public BoardsController(IBoardService boardService) => _boardService = boardService;


    // GET: api/boards
    [HttpGet]
    public IActionResult GetBoards()
    {
        List<BoardDTO> boards = _boardService.GetBoards();

        return Ok(boards);
    }

    // GET api/boards/boardIndex
    [HttpGet("{boardIndex}")]
    public IActionResult GetBoard(int index)
    {
        BoardDTO board;
        try
        {
            board = _boardService.GetBoard(index);
        }
        catch
        {
            return BadRequest("Request is incorrect. Check your index value");
        }

        return Ok(board);
    }

    // POST api/boards/create
    [HttpPost("create")]
    public IActionResult CreateBoard([FromBody] CreateBoardDTO createBoardDTO)
    {
        try
        {
            _boardService.CreateBoard(createBoardDTO.Title);
        }
        catch
        {
            return BadRequest("Couldn't create board with such parameters");
        }

        return Ok("Board was successfully created");
    }

    // DELETE api/boards/{boardIndex}/remove
    [HttpDelete("{boardIndex}/remove")]
    public IActionResult RemoveBoard(int boardIndex)
    {
        try
        {
            _boardService.RemoveBoard(boardIndex);
        }
        catch
        {
            return BadRequest("Couldn't remove board");
        }

        return Ok("Board was successfully removed");
    }
}
