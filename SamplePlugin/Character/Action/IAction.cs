using FFXIVClientStructs.FFXIV.Client.Game;

namespace MinervaPlugin.Character.Action
{
    internal interface IAction
    {
        public uint Id { get; }
        public string Name { get; }
        public bool OffGCD { get; }
        public ActionType Type { get; }
    }
}
