namespace ScrumBoard
{
    class BoardCard
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }

        public BoardCard(string name, string description = "", int priority = 1)
        {
            this.Name = name;
            this.Description = description;
            this.Priority = priority;
        }

        public void ChangeDescription(string description)
        {
            this.Description = description;
        }

        public void ChangeName(string name)
        {
            this.Name = name;
        }

        public void ChangePriority(int priority)
        {
            this.Priority = priority;
        }
    }
}
