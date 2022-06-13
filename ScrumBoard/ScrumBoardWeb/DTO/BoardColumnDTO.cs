using ScrumBoard;


namespace ScrumBoardWeb.DTO;

public class BoardColumnDTO
{
    public string Title { get; set; }

    public IEnumerable<BoardCardDTO> BoardCards { get; set; }

    public BoardColumnDTO(string title, List<BoardCardDTO> cards)
    {
        Title = title;
        BoardCards = cards;
    }
}
