using Dalamud.Game.ClientState;
using Dalamud.Game.Command;
using Dalamud.IoC;
using Dalamud.Plugin;
using ImGuiNET;
using MinervaPlugin.Character.Jobs;
using MinervaPlugin.Engine;
using MinervaPlugin.Logger;
using System.ComponentModel;
using System.IO;
using System.Numerics;

namespace MinervaPlugin
{
    public sealed class Plugin : IDalamudPlugin
    {
        public string Name => "Minerva Plugin";

        private const string commandName = "/minerva";

        private DalamudPluginInterface PluginInterface { get; init; }
        private CommandManager CommandManager { get; init; }
        private Configuration Configuration { get; init; }
        private Container Container { get; init; }

        public Plugin(
            [RequiredVersion("1.0")] DalamudPluginInterface pluginInterface,
            [RequiredVersion("1.0")] CommandManager commandManager)
        {
            this.PluginInterface = pluginInterface;
            this.CommandManager = commandManager;

            this.Configuration = PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
            this.Configuration.Initialize(this.PluginInterface);

            this.CommandManager.AddHandler(commandName, new CommandInfo(OnCommand)
            {
                HelpMessage = "A useful message to display in /xlhelp"
            });

            this.PluginInterface.UiBuilder.Draw += DrawUI;
            //this.PluginInterface.UiBuilder.Draw += UpdatePlayerState;
            this.PluginInterface.UiBuilder.Draw += UpdateTimeline;
            this.PluginInterface.UiBuilder.OpenConfigUi += DrawConfigUI;

            //var windowLogger = new WindowLogger();
            //windowLogger.Visible = true;

            var dalamudLogger = new DalamudLogger();

            Container = new Container();

            this.Timeline = new Timeline(dalamudLogger);
        }

        internal Timeline Timeline { get; private set; }

        private void UpdateTimeline()
        {
            Timeline.Update();
        }

        /* [PluginService]
        internal static ClientState? ClientState { get; private set; }
        internal IJob? Job { get; set; } = null;
        internal string CurrentJob { get; set; } = "";

        private void UpdatePlayerState()
        {
            if (ClientState == null) return;

            var player = ClientState.LocalPlayer;

            if (player == null || player.ClassJob == null || player.ClassJob.GameData == null) return;

            if (player.ClassJob.GameData.Abbreviation != CurrentJob)
            {
                CurrentJob = player.ClassJob.GameData.Abbreviation;

                switch (CurrentJob)
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

                Timeline.CurrentJob = Job;
                Timeline.RefreshActionsFile();
            }
        } */

        public void Dispose()
        {
            this.CommandManager.RemoveHandler(commandName);
        }

        private void OnCommand(string command, string args)
        {
            DrawConfigUI();
        }

        private void DrawUI()
        {
            if (!Timeline.Visible) return;

            Timeline.Display();
        }

        private void DrawConfigUI()
        {
            Timeline.Visible = true;
        }
    }
}
