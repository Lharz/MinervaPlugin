using MinervaPlugin.Character.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinervaPlugin.Character
{
    internal class Target : ICharacter
    {
        public uint HP { get; set; }
        public uint MP { get; set; }
        public List<IStatus> Buffs { get; set; }
        public List<IStatus> Debuffs { get; set; }

        public Target()
        {
            HP = 0;
            MP = 0;
            Buffs = new List<IStatus>();
            Debuffs = new List<IStatus>();
        }

        public void Update()
        {

        }
    }
}
