namespace MinervaPlugin.Character.Status
{
    internal class Debuff : IStatus
    {
        public uint Id { get; }
        public string Name { get; }

        public Debuff(uint id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
