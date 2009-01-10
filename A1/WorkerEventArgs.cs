using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A1
{
    class WorkerEventArgs : EventArgs
    {
        public WorkerEventArgs()
        {
        }

        public WorkerEventArgs(string name)
        {
            this._name = name;
        }

        private string _name;
        public string Name
        {
            get
            {
                return this.Name;
            }
            set { }
        }    
    }
}
