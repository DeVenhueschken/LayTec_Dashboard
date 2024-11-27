namespace LayTec_Dashboard.Services
{
    public interface IGetCurrentDateTimeService
    {
        Task<DateTime> GetCurrentDateTimeAsync();
    }

    public class GetCurrentDateTimeService : IGetCurrentDateTimeService
    {
        private readonly DateTime Data;

        public GetCurrentDateTimeService()
        {
            Data = new DateTime();
        }

        public Task<DateTime> GetCurrentDateTimeAsync() => Task.FromResult(Data);
    }
}
