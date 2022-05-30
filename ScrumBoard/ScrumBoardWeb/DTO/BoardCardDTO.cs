namespace ScrumBoardAPI.DTO;

public class BoardCardDTO
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string Priority { get; set; }

    public BoardCardDTO(string name, string description, string priority)
    {
        Name = name;
        Description = description;
        Priority = priority;
    }
}
