using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class Kitchen : Room
    {
        internal override string CreateDescription() =>
@"You step into the kitchen, the air heavy with a foul stench.
There's a half-opened [pantry], a rusty [knife] on the counter, and a door leading back to the [living room].
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "pantry":
                    Console.WriteLine("You cautiously open the pantry and find some spoiled and rotten food");
                    Player.DecreaseSanity(10);
                    break;
                case "knife":
                    Console.WriteLine("You pick up the rusty knife, its edge dulled with age, yet you still safer with it.");
                    Player.IncreaseSanity(5);
                    break;
                case "living room":
                    Console.WriteLine("You return to the living room.");
                    Game.Transition<LivingRoom>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
