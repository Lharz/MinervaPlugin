using FFXIVClientStructs.FFXIV.Client.Game;

namespace MinervaPlugin.Character.Action
{
    internal class Ability : IAction
    {
        public uint Id { get; }
        public string Name { get; }
        public bool OffGCD { get; } = true;
        public ActionType Type { get; } = ActionType.Ability;

        public Ability(uint id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
