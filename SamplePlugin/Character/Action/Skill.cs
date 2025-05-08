using FFXIVClientStructs.FFXIV.Client.Game;

namespace MinervaPlugin.Character.Action
{
    internal class Skill : IAction
    {
        public uint Id { get; }
        public string Name { get; }
        public bool OffGCD { get; } = false;
        public ActionType Type { get; } = ActionType.Spell;

        public Skill(uint id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
