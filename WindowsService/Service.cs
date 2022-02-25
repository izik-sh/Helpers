using System;
using System.Configuration;
using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;

namespace WindowsService
{
    public partial class Service : ServiceBase
    {
        #region Params
        string timeToShutDown = "21:00:00";
        int timerIntervalInSeconds = 60000;
        string daysToSkip = DayOfWeek.Friday.ToString();
        #endregion

        public Service()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            timeToShutDown = ConfigurationManager.AppSettings["TimeToShutDown"] != null ? ConfigurationManager.AppSettings["TimeToShutDown"] : timeToShutDown;
            timerIntervalInSeconds = ConfigurationManager.AppSettings["TimerIntervalInSeconds"] != null ? Convert.ToInt32(ConfigurationManager.AppSettings["TimerIntervalInSeconds"]) * 1000 : timerIntervalInSeconds;
            daysToSkip = ConfigurationManager.AppSettings["DaysToSkip"] ?? daysToSkip;
        }

        protected override void OnStart(string[] args)
        {
            EventLog.WriteEntry("Shut down service is started");

            System.Timers.Timer T1 = new System.Timers.Timer();
            T1.Interval = (timerIntervalInSeconds);
            T1.AutoReset = true;
            T1.Enabled = true;
            T1.Start();
            T1.Elapsed += new System.Timers.ElapsedEventHandler(RunTasks);
        }

        public void RunTasks(object sender, ElapsedEventArgs e)
        {
            string[] time = timeToShutDown.Split(':');

            int results = TimeSpan.Compare(DateTime.Now.TimeOfDay, new TimeSpan(Convert.ToInt32(time[0]), Convert.ToInt32(time[1]), Convert.ToInt32(time[2])));

            if (results == 1 && !DateTime.Now.DayOfWeek.ToString().ToLower().Contains(daysToSkip.ToLower()))
            {
                ComputerShutDown.ShutDown();
            }
        }

        protected override void OnStop()
        {
            EventLog.WriteEntry("Shut down service is ended");
        }
    }
}
