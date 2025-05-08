using System.Collections.Generic;

namespace MinervaPlugin.Engine
{
    internal class Actions
    {
        public List<string> Default { get; } = new List<string>();
        public List<string> Singletarget { get; } = new List<string>();
        public List<string> AoE { get; } = new List<string>();
    }
}
