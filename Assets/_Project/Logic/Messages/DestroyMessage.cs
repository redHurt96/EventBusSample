namespace _Project.Messages
{
    public readonly struct DestroyMessage
    {
        public readonly string ID;

        public DestroyMessage(string id) => 
            ID = id;
    }
}