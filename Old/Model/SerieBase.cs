using System;
using System.Data;

namespace ValueLens.Model
{
    public abstract class SerieBase : IObserver<DataTable>
    {

        public string Name { get; set; }
        public bool DataUpdated { get; set; }
        public SerieBase(string name)
        {
            Name = name;
            DataUpdated = false;
        }
        public double[] XValues { get; set; }
        public double[] YValues { get; set; }

        public virtual void Subscribe(IObservable<DataTable> provider)
        {
            if (provider != null)
                unsubscriber = provider.Subscribe(this);
        }

        private IDisposable unsubscriber;
        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }

        public virtual void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public virtual void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public virtual void OnNext(DataTable dt)
        {

        }

    }
}
