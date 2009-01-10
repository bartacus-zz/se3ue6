using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace A1
{
    delegate void dPush(object o);
    delegate object dPop();

    class Lager
    {
        protected Stack<object> _storage;
        protected int _capacity;

        protected Erzeuger[] _erzeuger;
        protected Verbraucher[] _verbraucher;

        protected Logger _logger = new Logger();

        public Lager(int capacity)
        {
            this.setUp(capacity, 1, 2);
        }

        public Lager(int capacity, int erzeuger, int verbraucher)
        {
            this.setUp(capacity, erzeuger, verbraucher);
        }

        public void setUp(int capacity, int erzeuger, int verbraucher)
        {
            this._capacity = capacity;

            this._storage = new Stack<object>(capacity);

            /*this._erzeuger = new Erzeuger[erzeuger];
            for (int i = 0; i < this._erzeuger.Length; i++)
                this._erzeuger[i] = new Erzeuger("Erzeuger " + i, this.Push);
            
            this._verbraucher = new Verbraucher[verbraucher];
            for (int j = 0; j < this._verbraucher.Length; j++)
                this._verbraucher[j] = new Verbraucher("Verbraucher " + j, this.Pop);*/
        }

        public void Run()
        {
            Erzeuger erz = new Erzeuger("Testerzeuger", this.Push);
            erz.eStart += new WorkerLogHandler(this._logger.Log);
            erz.eStop += new WorkerLogHandler(this._logger.Log);
            erz.eSleep += new WorkerLogHandler(this._logger.Log);
            erz.eCreate += new WorkerLogHandler(this._logger.Log);
            erz.Start();
        }

        protected void Push(object o)
        {
            this._storage.Push(o);
        }

        protected object Pop()
        {
            return this._storage.Pop();
        }

    }
}
