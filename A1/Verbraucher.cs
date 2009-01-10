using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace A1
{
    class Verbraucher : Worker
    {
        protected dPop _pop;
        protected int _speed = 2;
        protected bool _active = true;

        public Verbraucher(string name, dPop pop)
        {
            this._name = name;
            this._pop = pop;
        }
    }
}
