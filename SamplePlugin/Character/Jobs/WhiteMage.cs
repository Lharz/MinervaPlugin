using MinervaPlugin.Character.Action;
using System.Collections.Generic;

namespace MinervaPlugin.Character.Jobs
{
    internal class WhiteMage : IJob
    {
        public string Abbreviation { get; } = "WHM";
        public string ActionFileName { get; } = "white_mage.js";
        public List<IAction> Skills { get; }

        public WhiteMage()
        {
            Skills = new List<IAction>()
            {
                new Skill(
                    133,
                    "medica_ii"
                ),
                new Ability(
                    3571,
                    "assize"
                ),
                new Ability(
                    3569,
                    "asylum"
                ),
                new Ability(
                    136,
                    "presence_of_mind"
                )
            };
        }
    }
}
