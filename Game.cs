using NarrativeProject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace NarrativeProject
{
    internal class Game
    {
        private const string SaveFilePath = "save.json";
        private SaveData currentSaveData;
        private List<Room> rooms = new List<Room>();
        private Room currentRoom;
        private static bool isFinished;
        private static string nextRoom = "";

        internal bool IsGameOver() => isFinished;

        internal void Add(Room room)
        {
            rooms.Add(room);
            if (currentRoom == null)
            {
                currentRoom = room;
            }
        }

        internal string CurrentRoomDescription => currentRoom.CreateDescription();

        internal void SaveGame()
        {

            // Serialize and save game data
            using (var stream = File.Open(SaveFilePath, FileMode.Create))
            {
                var serializer = new DataContractJsonSerializer(typeof(SaveData));
                serializer.WriteObject(stream, currentSaveData);
            }

            Console.WriteLine("Game saved successfully.");
        }

        internal void LoadGame()
        {
            if (File.Exists(SaveFilePath))
            {
                // Deserialize and load saved game data
                using (var stream = File.Open(SaveFilePath, FileMode.Open))
                {
                    var serializer = new DataContractJsonSerializer(typeof(SaveData));
                    currentSaveData = (SaveData)serializer.ReadObject(stream);
                }

                // Set the game state based on the loaded data
                currentRoom = GetRoomByName(currentSaveData.CurrentRoom);
                Player.Sanity = currentSaveData.CurrentHealth;

                Console.WriteLine("Game loaded successfully.");
            }
            else
            {
                Console.WriteLine("No saved game found.");
            }
        }

        internal void HandleSanityEvent(GameEvents.SanityEvents sanityEvent)
        {
            switch (sanityEvent)
            {
                case GameEvents.SanityEvents.EncounterGhost:
                case GameEvents.SanityEvents.MysteriousWhispers:
                case GameEvents.SanityEvents.ParanormalActivity:
                    Player.DecreaseSanity(20);
                    break;
                case GameEvents.SanityEvents.StandInLight:
                    Player.IncreaseSanity(10);
                    break;
                default:
                    Console.WriteLine("Invalid event.");
                    break;
            }
        }

        internal void ReceiveChoice(string choice)
        {
            currentRoom.ReceiveChoice(choice);
            CheckTransition();
        }

        internal static void Transition<T>() where T : Room
        {
            nextRoom = typeof(T).Name;
        }

        internal static void Finish()
        {
            isFinished = true;
        }

        internal void CheckTransition()
        {
            foreach (var room in rooms)
            {
                if (room.GetType().Name == nextRoom)
                {
                    nextRoom = "";
                    currentRoom = room;
                    break;
                }
            }
        }

        private Room GetRoomByName(string roomName)
        {
            // Implement logic to get room instance by name
            return null;
        }
        internal Game()
        {
            currentSaveData = new SaveData
            {
                CurrentRoom = string.Empty,
                CurrentHealth = 100,
                CollectedItems = new string[0]
            };
        }
    }

    internal class GameEvents
    {
        internal enum SanityEvents
        {
            EncounterGhost,
            MysteriousWhispers,
            ParanormalActivity,
            StandInLight
        }
    }

    internal class Player
    {
        public static int Sanity { get; set; } = 100;

        internal static void DecreaseSanity(int amount)
        {
            Sanity -= amount;
            if (Sanity <= 0)
            {
                Sanity = 0;
                Console.WriteLine("Your sanity has reached zero. You have lost your mind. Game over.");
                Game.Finish();
            }
        }

        internal static void IncreaseSanity(int amount)
        {
            Sanity += amount;
            if (Sanity > 100)
            {
                Sanity = 100;
            }
        }
    }

    [DataContract]
    internal class SaveData
    {
        [DataMember]
        public string CurrentRoom { get; set; }

        [DataMember]
        public int CurrentHealth { get; set; }

        [DataMember]
        public string[] CollectedItems { get; set; }
    }
}

internal abstract class Room
{
    internal abstract string CreateDescription();
    internal abstract void ReceiveChoice(string choice);
}

public class Item
{
    public string Name { get; }
    public string Description { get; }

    public Item(string name, string description)
    {
        Name = name;
        Description = description;
    }
}