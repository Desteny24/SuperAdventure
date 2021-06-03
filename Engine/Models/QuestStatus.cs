namespace Engine.Models
{
    public class QuestStatus
    {
        public Quest PlayerQuest { get; set; }
        public bool IsCompleted { get; set; }

        public QuestStatus(Quest playerQuest)
        {
            PlayerQuest = playerQuest;
            IsCompleted = false;
        }
    }
}