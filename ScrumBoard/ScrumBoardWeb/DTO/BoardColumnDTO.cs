using ScrumBoard;

namespace ScrumBoardAPI.DTO;

public class BoardColumnDTO
{
    public string Title { get; set; }

    public IEnumerable<BoardCardDTO> BoardCards { get; set; }

    public BoardColumnDTO(BoardColumn column)
    {
        Title = column.Title;
        BoardCards = column.GetBoardCards().Select(card => new BoardCardDTO(card.Name, card.Description, BoardCard.GetPriorityTypeToString(card.Priority)));
    }
}
