using _Project.Domain;

namespace _Project.Messages
{
    public struct DamageMessage : IActorMessage
    {
        public string ID { get; }
        public readonly float Amount;

        public DamageMessage(string id, float amount)
        {
            ID = id;
            Amount = amount;
        }

    }
}