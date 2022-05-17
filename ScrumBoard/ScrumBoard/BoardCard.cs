namespace ScrumBoard
{
    public class BoardCard
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public enum PriorityType
        {
            NotImportant = 0,
            Minor,
            Common,
            Major,
        }

        public PriorityType Priority { get; private set; }

        public BoardCard(string name, string description = "", PriorityType priority = PriorityType.Common)
        {
            Name = name;
            Description = description;
            Priority = priority;
        }

        public void ChangeDescription(string description)
        {
            Description = description;
        }

        public void ChangeName(string name)
        {
            Name = name;
        }

        public void ChangePriority(PriorityType priority)
        {
            Priority = priority;
        }
    }
}
