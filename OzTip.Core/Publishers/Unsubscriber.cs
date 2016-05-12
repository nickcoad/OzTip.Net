using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzTip.Core.Publishers
{
    internal class Unsubscriber<TSubject> : IDisposable
    {
        private List<IObserver<TSubject>> _observers;
        private IObserver<TSubject> _observer;

        internal Unsubscriber(List<IObserver<TSubject>> observers, IObserver<TSubject> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}
