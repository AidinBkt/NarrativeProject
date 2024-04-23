using System;

namespace NarrativeProject.Rooms
{
    internal class Bedroom : Room
    {

        internal override string CreateDescription() =>
@"You are in a bedroom.The room is shrouded in darkness.
There's a [window] , with only faint moonlight piercing through the curtains of it.
The [door] in front of you leads to your living room.
A private [bathroom] is to your left.
From the closet, you see a staircase leading to the [attic].
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "window":
                    Console.WriteLine("You stand in the moonlight filtering through the window, feeling a sense of calm.");
                    Player.IncreaseSanity(10); // Increase sanity by 10 when standing in light
                    break;
                case "bathroom":
                    Console.WriteLine("You enter the bathroom.");
                    Game.Transition<Bathroom>();
                    break;
                case "door":
                    if (!AtticRoom.isKeyCollected)
                    {
                        Console.WriteLine("The door is locked.");
                    }
                    else
                    {
                        Console.WriteLine("You open the door with the key and enter the Living Room.");
                        Game.Transition<LivingRoom>();
                    }
                    break;
                case "attic":
                    Console.WriteLine("You go up and enter your attic.");
                    Game.Transition<AtticRoom>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
