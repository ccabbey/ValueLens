using System;
using System.Collections.Generic;
using System.Data;

namespace ValueLens.Model
{
    public struct MPoint
    {
        public string name;
        public bool isActive;
        public string direction;
    }

    public class DataRepo : IObservable<DataTable>
    {

        private List<IObserver<DataTable>> _observers;

        public DataRepo()
        {
            _observers = new List<IObserver<DataTable>>();

        }



        public DBHelper Helper { get { return service; } }

        private DBHelper service;

        public DataTable RawTable { get; private set; }


        public void UpdateRawDataTable()
        {
            if (RawTable == null)
            {
                RawTable = new DataTable();
            }
            RawTable = service.QuerySqlToDataTable(Helper.GetSqlString());
            NotifyRepoUpdated(RawTable);
        }

        public bool ConnectDB()
        {
            if (service == null)
            {
                service = new Model.DBHelper();
            }
            Helper.CreateConnection();
            return true;
        }





        public IDisposable Subscribe(IObserver<DataTable> observer)
        {
            _observers.Add(observer);
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return new Unsubscriber(_observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<DataTable>> _observers;
            private IObserver<DataTable> _observer;

            public Unsubscriber(List<IObserver<DataTable>> observers, IObserver<DataTable> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

        public void NotifyRepoUpdated(System.Data.DataTable dt)
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(dt);
            }
        }

        public List<MPoint> GetPointsList()
        {
            List<MPoint> pointNames = new List<MPoint>();
            var dt = Helper.QuerySqlToDataTable(Helper.GetSqlString());
            var str = Config.GetAppSettingsValueByKey("PointNameKeyword");
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if ((dt.Columns[i].ColumnName.IndexOf(str) != -1))
                {
                    pointNames.Add(new MPoint
                    {
                        name = dt.Columns[i].ColumnName,
                        isActive = false,
                        direction = dt.Columns[i].ColumnName.Substring(dt.Columns[i].ColumnName.Length - 1, 1)
                    });
                }
            }
            return pointNames;
        }

    }


}
