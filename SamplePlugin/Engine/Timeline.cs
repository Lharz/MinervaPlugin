using FFXIVClientStructs.FFXIV.Client.Game;
using ImGuiNET;
using MinervaPlugin.Character;
using MinervaPlugin.Character.Action;
using MinervaPlugin.Character.Jobs;
using MinervaPlugin.Logger;
using System;
using System.IO;
using System.Numerics;

namespace MinervaPlugin.Engine
{
    internal class Timeline
    {
        private bool visible = false;
        public bool Visible
        {
            get { return this.visible; }
            set { this.visible = value; }
        }

        internal string? ActionsFileCode { get; private set; }
        internal Actions Actions { get; private set; }

        internal ILogger Logger { get; private set; }
        internal Player Player { get; private set; }
        internal Target Target { get; private set; }

        internal long LastExecutedTimestamp { get; private set; }

        public Timeline(ILogger logger)
        {
            Actions = new Actions();
            Player = new Player();
            Target = new Target();
            Logger = logger;
            LastExecutedTimestamp = 0;
        }

        public unsafe void Update()
        {
            var timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

            if (timestamp - LastExecutedTimestamp < 1)
            {
                return;
            }

            Logger.Debug("Updating...");

            LastExecutedTimestamp = timestamp;

            Player.Update();
            Target.Update();

            RefreshActionsFile();

            if (ActionsFileCode == null) return;

            Actions.Default.Clear();

            var engine = new Jint.Engine()
                .SetValue("actions", Actions)
                .SetValue("player", Player)
                .SetValue("target", Target)
                .Execute(ActionsFileCode);
        }

        public unsafe void Display()
        {
            foreach (var name in ResourceHelper.GetAllResourcesNames())
            {
                Logger.Debug(name);
            }

            if (Player.Job == null) return;

            ActionManager* actionManager = ActionManager.Instance();

            foreach (IAction skill in Player.Job.Skills)
            {
                Logger.Debug($"{skill.Name}: {actionManager->GetRecastTimeElapsed(ActionType.Spell, skill.Id)} / {actionManager->GetRecastTime(ActionType.Spell, skill.Id)}");
            }

            foreach (string action in Actions.Default)
            {
                Logger.Debug($"Action listed: {action}");
            }
        }

        internal void RefreshActionsFile()
        {
            if (Player.Job == null)
            {
                ActionsFileCode = null;
                return;
            }

            try
            {
                ActionsFileCode = ResourceHelper.GetEmbeddedResourceContent(Player.Job.ActionFileName);
            }
            catch (FileNotFoundException exception)
            {
                Logger.Debug($"There was an error loading actions file {Player.Job.ActionFileName}: {exception.Message}");
            }
        }
    }
}
