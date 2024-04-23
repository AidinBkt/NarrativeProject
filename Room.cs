using System.Collections.Generic;

namespace NarrativeProject
{
    internal abstract class Room
    {
        private List<Item> items;

        internal Room()
        {
            items = new List<Item>();
            InitializeItems(); // Initialize items in each room
        }

        internal abstract string CreateDescription();
        internal abstract void ReceiveChoice(string choice);

        protected virtual void InitializeItems()
        {
            // Initialize items specific to each room
        }

        protected void AddItem(Item item)
        {
            items.Add(item);
        }

        protected void RemoveItem(Item item)
        {
            items.Remove(item);
        }
    }
}
