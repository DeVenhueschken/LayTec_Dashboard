namespace LayTec_Dashboard.Services
{
    public interface IGetCurrentDateTimeService
    {
        Task<string> GetCurrentDateTimeAsync();

        delegate void UiChangedEventHandler(object source, EventArgs args);

        event UiChangedEventHandler UiChanged; //Handler
    }

    public class GetCurrentDateTimeService : IGetCurrentDateTimeService
    {
        private string Data;
        private static System.Timers.Timer _timer;
        public event IGetCurrentDateTimeService.UiChangedEventHandler UiChanged; //Event from the base Interface

        protected virtual void OnUiChanged()
        {
            UiChanged?.Invoke(this, EventArgs.Empty);
        }




        public void CountDownTimer(Object source, System.Timers.ElapsedEventArgs e)
        {
            Random rnd = new Random();
            Double num = rnd.Next();
            Data = DateTime.Now.ToString();
            OnUiChanged();

        }

        public void Dispose()
        {
            _timer?.Dispose();
        }










        public GetCurrentDateTimeService()
        {
            Data = DateTime.Now.ToString();
            _timer = new System.Timers.Timer(3000);
            _timer.Elapsed += CountDownTimer;
            _timer.Enabled = true;
            //_injectableService = injectableService;
        }

        public Task<string> GetCurrentDateTimeAsync() => Task.FromResult(Data);
    }
}
