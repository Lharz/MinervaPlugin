using MinervaPlugin.Character.Action;
using System.Collections.Generic;

namespace MinervaPlugin.Character.Jobs
{
    internal class Machinist : IJob
    {
        public string Abbreviation { get; } = "MCH";
        public string ActionFileName { get; } = @"MinervaPlugin.Engine.Actions.machinist.js";
        public List<IAction> Skills { get; }

        public Machinist()
        {
            Skills = new List<IAction>()
            {
                new Ability(
                    16498,
                    "drill"
                )
            };
        }
    }
}
