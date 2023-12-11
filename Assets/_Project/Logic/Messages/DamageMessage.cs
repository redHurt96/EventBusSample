namespace _Project.Messages
{
    public readonly struct DamageMessage
    {
        public readonly string ID;
        public readonly float Amount;

        public DamageMessage(string id, float amount)
        {
            ID = id;
            Amount = amount;
        }
    }
}