using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A1
{
    abstract class Worker
    {
        protected string _name;

        public string Name
        {
            set
            {
                this._name = value;
            }
            get
            {
                return this._name;
            }
        }
    }
}
