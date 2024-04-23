using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class OfficeRoom : Room
    {
        internal static bool isKeyFound;

        internal override string CreateDescription() =>
@"You enter the office, with a heavy dusty air, cluttered with old papers and furniture.
There's a large oak [desk] in the center and a [window] overlooking the front yard. There's a menacing [portrait] of an old woman hanged on the wall.
The can return to [living room].
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "desk":
                    if (!isKeyFound)
                    {
                        Console.WriteLine("You search through the drawers of the desk and discover a hidden compartment.");
                        Console.WriteLine("Inside, you find a small rusted key with a letter 'G' engraved on it.");
                        isKeyFound = true;
                    }
                    else
                    {
                        Console.WriteLine("You've already found the key in the desk.");
                    }
                    break;
                case "window":
                    Console.WriteLine("You peer out the window, but the view is obscured by the darkness of the night, and you can't help but feel like someone is watching you very closely");
                    Player.DecreaseSanity(15);
                    break;
                case "portrait":
                    Console.WriteLine("You go to take a closer look to the portrait. As you watch the old lady in the painting you almost can swear as if her eyes are following you.");
                    Player.DecreaseSanity(10);
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
                case "living room":
                    Console.WriteLine("You return to the living room.");
                    Game.Transition<LivingRoom>();
                    return;
            }
        }
    }
}
