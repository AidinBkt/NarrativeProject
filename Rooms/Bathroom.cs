using System;

namespace NarrativeProject.Rooms
{
    internal class Bathroom : Room
    {

        internal override string CreateDescription() =>
@"In the bathroom, there's a [cabinet] with sanity pills in it.
The [mirror] in front of you reflects your pale face.
You can return to your [bedroom].
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "cabinet":
                    Console.WriteLine("You take the sanity pills.");
                    Player.IncreaseSanity(10);
                    break;
                case "mirror":
                    Console.WriteLine("You see the numbers 1378 written on the fog on your mirror.");
                    break;
                case "bedroom":
                    Console.WriteLine("You return to your bedroom.");
                    Game.Transition<Bedroom>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
