using System;

namespace NarrativeProject.Rooms
{
    internal class AtticRoom : Room
    {
        private Game gameInstance;

        internal AtticRoom(Game game)
        {
            gameInstance = game;
        }

        public AtticRoom()
        {
        }

        internal static bool isKeyCollected;

        internal override string CreateDescription() =>
@"In the attic, it's dark and cold, with a flickering light in which you can see a chest.
There is some faint unsettling noise coming from the darkness of the corner, you can [investigate noise] or [listen] to it.
A chest is locked with the code [????].
You can return to your [bedroom].
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "investigate noise":
                    Console.WriteLine("As you investigate the noise, you see a shadowy figure vanish into thin air.");
                    gameInstance?.HandleSanityEvent(GameEvents.SanityEvents.EncounterGhost); // Check if gameInstance is null
                    break;
                case "listen":
                    Console.WriteLine("You strain your ears and hear chilling whispers emanating from the darkness.");
                    gameInstance?.HandleSanityEvent(GameEvents.SanityEvents.MysteriousWhispers); // Check if gameInstance is null
                    break;
                case "bedroom":
                    Console.WriteLine("You return to your bedroom.");
                    Game.Transition<Bedroom>();
                    break;
                case "1378":
                    Console.WriteLine("The chest opens and you get a key.");
                    isKeyCollected = true;
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
