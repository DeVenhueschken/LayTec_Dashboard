namespace LayTec_Dashboard.Data
{
    public class DashBoard
    {
        public string type { get; set; }
    }

    public class Roomtemperature : DashBoard
    {
        public float roomTemperature { get; set; }
    }

    public class CurrentDateTime : DashBoard
    {
        public DateTime dateTime { get; set; }
    }
}
