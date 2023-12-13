namespace _Project.Messages
{
    public struct DestroyMessage : IActorMessage
    {
        public string ID { get; }

        public DestroyMessage(string id) => 
            ID = id;
    }
}