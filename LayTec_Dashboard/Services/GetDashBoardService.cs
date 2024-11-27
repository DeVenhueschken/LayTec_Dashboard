using LayTec_Dashboard.Data;





namespace LayTec_Dashboard.Services
{
    public interface IGetCurrentDashBoard
    {
        Task<IEnumerable<DashBoard>> GetCurrentDascboardAsync();
    }

    public class GetCurrentDashBoard : IGetCurrentDashBoard
    {
        private readonly IEnumerable<DashBoard> Data;

        public GetCurrentDashBoard()
        {
            Data = new DashBoard[]
            {
        new DashBoard {type = "Roomtemperature"},
        new DashBoard { type = "CurrentDateTime"},
            };
        }

        public Task<IEnumerable<DashBoard>> GetCurrentDascboardAsync() => Task.FromResult(Data);
    }
}
