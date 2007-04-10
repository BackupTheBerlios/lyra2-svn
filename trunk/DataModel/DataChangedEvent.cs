using System;

namespace Lyra2
{
    public delegate void DataChangedHandler(object sender, DataChangedEventArgs e);

    public enum DataChangedType
    {
        Changed, Deleted, New, Lost
    }

    public class DataChangedEventArgs : EventArgs
    {
        // changed data object
        private readonly object changedObject = null;
        public object ChangedObject
        {
            get { return this.changedObject; }
        }

        // type of update
        private readonly DataChangedType type;
        public DataChangedType UpdateType
        {
            get { return this.type; }
        }

        public DataChangedEventArgs(object changedObject, DataChangedType type)
        {
            this.changedObject = changedObject;
            this.type = type;
        }
    }
}
