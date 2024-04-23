using System;
using System.IO;

namespace NarrativeProject
{
    internal class DataContractJsonSerializer
    {
        private Type type;

        public DataContractJsonSerializer(Type type)
        {
            this.type = type;
        }

        internal SaveData ReadObject(FileStream stream)
        {
            throw new NotImplementedException();
        }

        internal void WriteObject(FileStream stream, SaveData currentSaveData)
        {
            throw new NotImplementedException();
        }
    }
}