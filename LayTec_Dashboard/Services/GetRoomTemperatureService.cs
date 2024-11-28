namespace LayTec_Dashboard.Services
{
    public interface IGetRoomTemperatureService
    {
        Task<decimal> GetRoomTemperatureAsync();

        delegate void UiChangedEventHandler(object source, EventArgs args);

        event UiChangedEventHandler UiChanged; //Handler
    }


    public class GetRoomTemperatureService : IGetRoomTemperatureService //BackgroundService, IGetRoomTemperatureService 
    {
        private decimal Data;
        private static System.Timers.Timer _timer;

        public event IGetRoomTemperatureService.UiChangedEventHandler UiChanged; //Event from the base Interface

        protected virtual void OnUiChanged()
        {
            UiChanged?.Invoke(this, EventArgs.Empty);
        }



        public GetRoomTemperatureService()//InjectableService injectableService)
        {
            Data = new decimal();
            Random rnd = new Random();
            Double num = rnd.Next();
            Data = (decimal)num;
            _timer = new System.Timers.Timer(3000);
            _timer.Elapsed += CountDownTimer;
            _timer.Enabled = true;
            //_injectableService = injectableService;

        }

        public void CountDownTimer(Object source, System.Timers.ElapsedEventArgs e)
        {
            Random rnd = new Random();
            Double num = rnd.Next();
            Data = (decimal)num;
            OnUiChanged();

        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task<decimal> GetRoomTemperatureAsync() => Task.FromResult(Data);



    }
}