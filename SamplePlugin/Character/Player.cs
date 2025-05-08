using Dalamud.Game.ClientState;
using Dalamud.Game.ClientState.Objects.SubKinds;
using Dalamud.IoC;
using MinervaPlugin.Character.Action;
using MinervaPlugin.Character.Jobs;
using MinervaPlugin.Character.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinervaPlugin.Character
{
    internal class Player : ICharacter
    {
        [PluginService]
        internal static ClientState? ClientState { get; private set; }

        public uint HP { get; set; }
        public uint MP { get; set; }
        public List<IStatus> Buffs { get; set; }
        public List<IStatus> Debuffs { get; set; }
        public IJob? Job { get; set; }
        private PlayerCharacter? PlayerCharacter { get; set; }

        public Player()
        {
            HP = 0;
            MP = 0;
            Buffs = new List<IStatus>();
            Debuffs = new List<IStatus>();
            Job = null;

            if (ClientState == null) return;

            PlayerCharacter = ClientState.LocalPlayer;
        }

        public void Update()
        {
            if (PlayerCharacter == null) return; // ???

            HP = PlayerCharacter.CurrentHp;
            MP = PlayerCharacter.CurrentMp;

            UpdateJob();
            UpdateBuffs();
            UpdateDebuffs();
        }

        private void UpdateJob()
        {
            var playerJob = PlayerCharacter.ClassJob;

            if (playerJob == null) return; // ???

            if (Job == null || playerJob.GameData.Abbreviation != Job.Abbreviation)
            {
                switch (playerJob.GameData.Abbreviation)
                {
                    case "PLD":
                        Job = new Paladin();
                        break;
                    case "WHM":
                        Job = new WhiteMage();
                        break;
                    case "MCH":
                        Job = new Machinist();
                        break;
                    default:
                        Job = null;
                        break;
                }
            }
        }

        private void UpdateBuffs()
        {
            foreach (var status in PlayerCharacter.StatusList)
            {
                
            }
        }

        private void UpdateDebuffs()
        {
            throw new NotImplementedException();
        }

        public IStatus? GetBuff(string name)
        {
            throw new NotImplementedException();
        }

        public IStatus? GetDebuff(string name)
        {
            throw new NotImplementedException();
        }

        public IAction? GetAction(string name)
        {
            throw new NotImplementedException();
        }
    }
}
