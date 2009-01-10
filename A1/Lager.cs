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

        protected Erzeuger[] _erzeuger;
        protected Verbraucher[] _verbraucher;

        public Lager(int capacity)
        {
            Lager(capacity, 1, 2);
        }

        public Lager(int capacity, int erzeuger, int verbraucher)
        {
            this._storage = new Stack<object>(capacity);
            this._erzeuger = new Erzeuger[erzeuger];
            this._verbraucher = new Verbraucher[verbraucher];
            this.init();
        }

        protected void init()
        {
            for(int i = 0; i < this._erzeuger.Length; i++)
                this._erzeuger[i] = new Erzeuger("Erzeuger " + i, this.Push);

            for(int j = 0; j < this._verbraucher.Length; j++)
                this._verbraucher[j] = new Verbraucher("Verbraucher " + j, this.Pop);
        }

        public Run()
        {

        }

        protected StartErzeuger()
        {

        }

        protected StartVerbraucher()
        {
            Thread myFirstThread= new Thread(new ThreadStart(MyProcedure));
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
