namespace LayTec_Dashboard.Services
{
    public interface IGetRoomTemperatureService
    {
        Task<decimal> GetRoomTemperatureAsync();

        delegate void UiChangedEventHandler(object source, EventArgs args);

        event UiChangedEventHandler UiChanged; //Handler
    }

    //public class InjectableService
    //{
    //    public decimal Value { get; set; }
    //    public event Func<Task> Notify;
    //    //public decimal Data { get; set; }

    //    public async Task RefreshAsync(decimal value)
    //    {
    //        if (Notify is { })
    //        {
    //            Value = value;
    //            await Notify.Invoke();
    //        }
    //    }
    //}

    public class GetRoomTemperatureService : IGetRoomTemperatureService //BackgroundService, IGetRoomTemperatureService 
    {
        private decimal Data;
        private static System.Timers.Timer _timer;
        //private readonly InjectableService _injectableService;

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




        //public async Task Update(decimal value)
        //{
        //    await _injectableService.RefreshAsync(value);
        //}

        //protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //    while (!stoppingToken.IsCancellationRequested)
        //    {
        //        await Update(Data).ConfigureAwait(false);
        //        await Task.Delay(1000).ConfigureAwait(false);
        //    }
        //}




    }
}