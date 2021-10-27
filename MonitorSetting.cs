using System;

namespace Task_NET02_4
{
    public class MonitorSetting : ICloneable
    {
        public int CheckInterval { get; set; }
        public int ExpectedTime { get; set; }
        public string WebsiteURL{ get; set; }
        public string AdminPassword { get; set; }
        public string EmailAdmin { get; set; }

        public object Clone()
        {
            return new MonitorSetting()
            {
                CheckInterval = this.CheckInterval,
                ExpectedTime = this.ExpectedTime,
                WebsiteURL = this.WebsiteURL,
                AdminPassword = this.AdminPassword,
                EmailAdmin = this.EmailAdmin
            };
        }
    }
}