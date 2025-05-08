namespace MinervaPlugin.Character.Status
{
    internal class Buff : IStatus
    {
        public uint Id { get; }
        public string Name { get; }

        public Buff(uint id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
