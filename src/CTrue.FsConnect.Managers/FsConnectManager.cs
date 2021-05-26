using System;
using System.Threading;

namespace CTrue.FsConnect.Managers
{
    public interface IFsConnectManager
    {
        void Update();
    }

    public abstract class FsConnectManager : IFsConnectManager
    {
        protected readonly IFsConnect _fsConnect;
        protected AutoResetEvent _resetEvent = new AutoResetEvent(false);
        private int _timeout = 5_000;

        protected FsConnectManager(IFsConnect fsConnect)
        {
            _fsConnect = fsConnect;

            _fsConnect.FsDataReceived += OnFsDataReceived;
        }

        public virtual void Initialize()
        {
            RegisterSimVars();
            RegisterEvents();
        }

        protected virtual void OnFsDataReceived(object sender, FsDataReceivedEventArgs e)
        {
        }

        protected virtual void RegisterSimVars()
        {
        }

        protected virtual void RegisterEvents()
        {
        }

        protected void WaitForUpdate()
        {
            bool resetRes = _resetEvent.WaitOne(_timeout);
            
            if (!resetRes)
                throw new TimeoutException("Updated data was not returned from MSFS within timeout");
        }

        public virtual void Update()
        {
        }
    }
}