namespace CTrue.FsConnect.TestConsole
{
    public enum Requests
    {
        PlaneInfo=0,
        ContineousPlaneInfo=1,
        SimObjects=2,
        PlanePosition=3,
        /// <summary>
        /// Requests done by the aircraft manager
        /// </summary>
        AircraftManager=4
    }

    public enum Definitions
    {
        PlaneInfo=0,
        PlanePosition = 1,
    }
}