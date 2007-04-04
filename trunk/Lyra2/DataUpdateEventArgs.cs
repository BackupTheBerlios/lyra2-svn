using System;

namespace Lyra2
{
    public delegate void DataUpdateHandler(object sender, DataUpdateEventArgs e);

    public enum DataUpdateType
    {
        Changed, Deleted, New, Lost
    }

    public class DataUpdateEventArgs : EventArgs
    {
        // updated data object
        private readonly object update = null;
        public object Update
        {
            get { return this.update; }
        }

        // type of update
        private readonly DataUpdateType type;
        public DataUpdateType UpdateType
        {
            get { return this.type; }
        }

        public DataUpdateEventArgs(object update, DataUpdateType type)
        {
            this.update = update;
            this.type = type;
        }
    }
}
