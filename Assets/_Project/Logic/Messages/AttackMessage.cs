namespace _Project.Messages
{
    public readonly struct AttackMessage
    {
        public readonly string ID;

        public AttackMessage(string id) => 
            ID = id;
    }
}