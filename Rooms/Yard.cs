using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class Yard : Room
    {
        internal override string CreateDescription() =>
    @"You step out into the cold night air, facing the front yard of your house. You can go back to the [living room].
In the dim moonlight, you see a shadowy figure lurking in the darkness. There's no other way to escape this haunted house, you may only [approach].
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "approach":
                    if (Player.Sanity < 30)
                    {
                        Console.WriteLine("As you approach the shadowy figure, a terrifying demon emerges from the darkness.");
                        Console.WriteLine("Your sanity is too low to withstand the horror, and you are overwhelmed and devoured by the demon.");
                        Game.Finish();
                    }
                    else
                    {
                        Console.WriteLine("Summoning your courage, you sprint past the demon as fast as you can, narrowly avoiding its grasp.");
                        Console.WriteLine("You make it to the gate at the end of the yard.");
                        if (OfficeRoom.isKeyFound)
                        {
                            Console.WriteLine("You use the key you found in the office desk to unlock the gate.");
                            Console.WriteLine("With a sense of relief, you escape into the night.");
                            Game.Finish();
                        }
                        else
                        {
                            Console.WriteLine("The gate is locked. You need to find a key.");
                        }
                    }
                    break;
                case "living room":
                    Console.WriteLine("You return to the living room.");
                    Game.Transition<LivingRoom>();
                    return;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
