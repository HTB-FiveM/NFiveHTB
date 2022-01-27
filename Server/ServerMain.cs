using System;
using System.Threading.Tasks;
using CitizenFX.Core;

namespace HtbRp.Server
{
    public class ServerMain : BaseScript
    {
        public ServerMain()
        {
            Debug.WriteLine("Hi from htb_rp.Server!");

            //EventHandlers["playerConnecting"] += new Action<Player, string, dynamic, dynamic>(OnPlayerConnecting);

        }

        [Command("hello_server")]
        public void HelloServer()
        {
            Debug.WriteLine("Sure, hello.");
        }


        //[EventHandler]
        // Delegate method
        //private async void OnPlayerConnecting([FromSource] Player player, string playerName, dynamic setKickReason, dynamic deferrals)
        //{
        //    deferrals.defer();

        //    // mandatory wait!
        //    await Delay(0);

        //    var licenseIdentifier = player.Identifiers["license"];

        //    Debug.WriteLine($"A player with the name {playerName} (Identifier: [{licenseIdentifier}]) is connecting to the server.");

        //    deferrals.update($"Hello {playerName}, your license [{licenseIdentifier}] is being checked");

        //    // Checking ban list
        //    // - assuming you have a function called IsBanned of type Task<bool>
        //    // - normally you'd do a database query here, which might take some time
        //    if (await IsBanned(licenseIdentifier))
        //    {
        //        deferrals.done($"You have been kicked (Reason: [Banned])! Please contact the server administration (Identifier: [{licenseIdentifier}]).");
        //    }

        //    deferrals.done();
        //}


    }
}