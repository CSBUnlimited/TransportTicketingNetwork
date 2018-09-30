namespace Modules.Main.Models
{
    public class SubRoute
    {
        public int Id { get; set; }

        public Route Route { get; set; }
        public string RouteId { get; set; }
        public BusStop EndBusStop { get; set; }
        public string EndBusStopId { get; set; }
        public int Distance { get; set; }
        public int Fare { get; set; }
    }
}
