using System.Reflection;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;

namespace SignalMechanical
{
    [ApiVersion(2, 1)]
    public class SignalMechanicalMain : TerrariaPlugin
    {
        public SignalMechanicalMain(Main game) : base(game)
        {
        }

        public override string Author => "Miyabi";
        public override string Description => "Send signal to any wires / mechanicals. May cause bug.";
        public override string Name => "SignalMechanical";
        public override Version Version => Assembly.GetExecutingAssembly().GetName().Version;

        public override void Initialize()
        {
            TShockAPI.Commands.ChatCommands.Add(new Command(Permissions.godmode, SendSignal, "sendsignal"));
        }

        // Placeholder for feature update.
        /*
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }

            base.Dispose(disposing);
        }
        */

        private void SendSignal(CommandArgs args)
        {
            if (args.Parameters.Count != 2)
            {
                args.Player.SendErrorMessage(string.Format("Invalid parameters! Usage: {0}sendsignal <x> <y>", new object[] { TShock.Config.Settings.CommandSpecifier }));
                return;
            }
            int x, y;
            if (!int.TryParse(args.Parameters[0], out x) || !int.TryParse(args.Parameters[1], out y))
            {
                args.Player.SendErrorMessage(string.Format("Invalid parameters! Usage: {0}sendsignal <x> <y>", new object[] { TShock.Config.Settings.CommandSpecifier }));
                return;
            }

            Wiring.TripWire(x, y, 1, 1);
        }
    }
}