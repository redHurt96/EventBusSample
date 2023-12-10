namespace _Project.Domain.Implementation
{
    public readonly struct UpdateHealthMessage
    {
        public readonly string ID;
        public readonly float Value;
        public readonly float MaxValue;

        public UpdateHealthMessage(string id, float value, float maxValue)
        {
            ID = id;
            Value = value;
            MaxValue = maxValue;
        }
    }
}