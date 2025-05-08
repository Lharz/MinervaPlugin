using MinervaPlugin.Character.Action;
using System.Collections.Generic;

namespace MinervaPlugin.Character.Jobs
{
    internal interface IJob
    {
        public string Abbreviation { get; }
        public string ActionFileName { get; }
        public List<IAction> Skills { get; }
    }
}
