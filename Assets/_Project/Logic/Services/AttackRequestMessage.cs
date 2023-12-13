using _Project.Messages;

namespace _Project.Services
{
    public struct AttackRequestMessage : IActorMessage
    {
        public string ID { get; }

        public AttackRequestMessage(string id) => 
            ID = id;
    }
}