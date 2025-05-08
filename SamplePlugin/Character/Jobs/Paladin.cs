using MinervaPlugin.Character.Action;
using System.Collections.Generic;

namespace MinervaPlugin.Character.Jobs
{
    internal class Paladin : IJob
    {
        public string Abbreviation { get; } = "PLD";
        public string ActionFileName { get; } = "paladin.js";
        public List<IAction> Skills { get; }

        public Paladin()
        {
            Skills = new List<IAction>()
            {
                new Skill(
                    3539,
                    "royal_authority"
                ),
                new Skill(
                    3538,
                    "goring_blade"
                ),
                new Skill(
                    16458,
                    "holy_circle"
                ),
                new Ability(
                    25747,
                    "expiacion"
                ),
                new Ability(
                    23,
                    "circle_of_scorn"
                ),
                new Ability(
                    7383,
                    "requiescat"
                )
            };
        }
    }
}
