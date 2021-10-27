using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using NLog;

namespace Task_NET02_4
{
    class Monitor
    {
        public MonitorSetting _setting;
        public System.Timers.Timer _timer;
        private Logger _log = LogManager.GetCurrentClassLogger();
        private readonly HttpClient _client = new HttpClient();
        private static object _locker = new object();
        private EmailService _emailService = new EmailService();

        public Monitor(MonitorSetting setting)
        {
            _setting = setting;
            _client.Timeout = TimeSpan.FromSeconds(_setting.ExpectedTime);
        }
        public void Start()
        {
            _timer = new System.Timers.Timer(_setting.CheckInterval * 1000);
            _timer.Elapsed += async (sender, e) => await CheckWebpage();
            _timer.Start();
        }
        private async Task CheckWebpage()
        {
            HttpResponseMessage response = null;
            try
            {
                response = await _client.GetAsync(_setting.WebsiteURL);
            }
            catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
            {
                await _emailService.SendEmailAsync($"NotFound: {_setting.WebsiteURL}");

                Console.WriteLine("TimeoutException");
            }
            catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
            {
                await _emailService.SendEmailAsync( $"NotFound: {_setting.WebsiteURL}");
            }
            catch (Exception)
            {
                Console.WriteLine("Exception");
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                await _emailService.SendEmailAsync($"NotFound: {_setting.WebsiteURL}");
            }
            else
            {
                lock (_locker)
                {
                    _log.Info(_setting.WebsiteURL);
                }
            }
        }
    }
}

