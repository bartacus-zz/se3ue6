using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace A1
{
    class Erzeuger : Worker
    {
        internal event WorkerLogHandler eCreate;
        internal event WorkerLogHandler eStart;
        internal event WorkerLogHandler eStop;
        internal event WorkerLogHandler eSleep;

        protected dPush _push;
        protected int _speed = 5;
        protected bool _active = true;

        protected int _counter = 0;

        public Erzeuger(string name, dPush push)
        {
            this._name = name;
            this._push = push;
        }

        public void Start()
        {
            this.OnStart("Starting...");
            this._active = true;
            while (this._active == true)
            {
                for (int i = 0; i < this._speed; i++)
                {
                    this._push(new object());
                    this.OnCreate("Created new object (" + ++this._counter + ")");
                }

                this.OnSleep("Sleeping for 1000 milliseconds");
                Thread.Sleep(1000);
            }
        }

        public void Stop()
        {
            this.OnStop("Stopped");
            this._active = false;
        }

        protected WorkerEventArgs getEventArgs(string message)
        {
            WorkerEventArgs args = new WorkerEventArgs();
            args.Name = this.Name;
            args.Message = message;
            return args;
        }

        private void OnCreate(string message)
        {
            if (eCreate != null)
                eCreate(this, this.getEventArgs(message));
        }

        private void OnStart(string message)
        {
            if (eStart != null)
                eStart(this, this.getEventArgs(message));
        }

        private void OnStop(string message)
        {
            if (eStop != null)
                eStop(this, this.getEventArgs(message));
        }

        private void OnSleep(string message)
        {
            if (eSleep != null)
                eSleep(this, this.getEventArgs(message));
        }
    }
}
