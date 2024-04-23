using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class LivingRoom : Room
    {
        private Game gameInstance;

        public LivingRoom()
        {
        }

        internal LivingRoom(Game game)
        {
            gameInstance = game;
        }

        internal override string CreateDescription() =>
@"You are in the living room, dimly lit by a flickering [fireplace]. There's a [tv] on the wall, on top of fireplace.
There's a door leading to the [kitchen], an entrance to the [office], and the front [yard] outside.
You can go back to [bedroom].
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "tv":
                    Console.WriteLine("You turn the TV on to be greeted with statics and some very unnerving noises coming out of it.");
                    gameInstance?.HandleSanityEvent(GameEvents.SanityEvents.MysteriousWhispers); // Hear mysterious whispers
                    break;
                case "fireplace":
                    Console.WriteLine("You stand by the lamp and feel a little bit better");
                    Player.IncreaseSanity(10);
                    break;
                case "kitchen":
                    Console.WriteLine("You enter the kitchen.");
                    Game.Transition<Kitchen>();
                    break;
                case "office":
                    Console.WriteLine("You enter the office.");
                    Game.Transition<OfficeRoom>();
                    break;
                case "yard":
                    Console.WriteLine("You step outside into the front yard.");
                    Game.Transition<Yard>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
                case "bedroom":
                    Console.WriteLine("You return to the bedroom.");
                    Game.Transition<Bedroom>();
                    return;
            }
        }
    }
}