using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace A1
{
    delegate void ErzeugerEventHandler(object o, EventArgs e);

    class Erzeuger : Worker
    {
        internal event ErzeugerEventHandler Create;
        internal event ErzeugerEventHandler Start;
        internal event ErzeugerEventHandler Stop;

        protected dPush _push;
        protected int _speed = 5;
        protected bool _active = true;

        public Erzeuger(string name, dPush push)
        {
            this._name = name;
            this._push = push;
        }

        protected void Start()
        {
            this._active = true;
            while (this._active == true)
            {
                for (int i = 0; i < this._speed; i++)
                {
                    this._push(new object());
                }

                Thread.Sleep(1000);
            }
        }

        protected void Stop()
        {
            this.OnStop();
            this._active = false;
        }

        protected WorkerEventArgs getEventArgs()
        {
            WorkerEventArgs args = new WorkerEventArgs();
            args.Name = this.Name;
            return args;
        }

        private void OnCreate()
        {
            if (Create != null)
                Create(this, this.getEventArgs());
        }

        private void OnStart()
        {
            if (Start != null)
                Start(this, this.getEventArgs());
        }

        private void OnStop()
        {
            if (Stop != null)
                Stop(this, this.getEventArgs());
        }

    }
}
