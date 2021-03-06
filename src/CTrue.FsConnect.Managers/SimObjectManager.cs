using System;

namespace CTrue.FsConnect.Managers
{
    public class SimObjectManager
    {
        private readonly IFsConnect _fsConnect;

        public SimObjectManager(IFsConnect fsConnect)
        {
            _fsConnect = fsConnect;
        }
    }
}
