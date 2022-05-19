namespace ScrumBoard
{
    public class BoardCard
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public enum PriorityType
        {
            NoPriority = 0,
            NotImportant,
            Minor,
            Common,
            Major,
        }

        public PriorityType Priority { get; private set; }

        public BoardCard(string name, string description = "", PriorityType priority = PriorityType.NoPriority)
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

        public static PriorityType GetPriorityTypeFromString(string priority)
        {
            switch (priority)
            {
                case "not important":
                    return PriorityType.NotImportant;
                case "minor":
                    return PriorityType.Minor;
                case "common":
                    return PriorityType.Common;
                case "major":
                    return PriorityType.Major;
                default:
                    return PriorityType.NoPriority;
            }
        }

        public static string GetPriorityTypeToString(PriorityType priority)
        {
            switch (priority)
            {
                case PriorityType.NotImportant:
                    return "not important";
                case PriorityType.Minor:
                    return "minor";
                case PriorityType.Common:
                    return "common";
                case PriorityType.Major:
                    return "major";
                default:
                    return "no priority";
            }
        }
    }
}
