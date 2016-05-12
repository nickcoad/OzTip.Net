using OzTip.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzTip.Core.Publishers
{
    public class OzTipPublisher : IObservable<OzTipContext>
    {
        private readonly List<IObserver<OzTipContext>> _observers = new List<IObserver<OzTipContext>>();

        public IDisposable Subscribe(IObserver<OzTipContext> observer)
        {
            if (_observers.Contains(observer))
                return new Unsubscriber<OzTipContext>(_observers, observer);

            _observers.Add(observer);

            return new Unsubscriber<OzTipContext>(_observers, observer);
        }
    }
}
