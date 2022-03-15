using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Management;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows;

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

            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

            foreach (ManagementObject wmi_HD in moSearcher.Get())
            {
                ArrayList hardDriveDetails = new ArrayList();

                HardDrive hd = new HardDrive();  // User Defined Class
                hd.Model = wmi_HD["Model"].ToString();  //Model Number
                hd.Type = wmi_HD["InterfaceType"].ToString();  //Interface Type
                hd.SerialNo = wmi_HD["SerialNumber"].ToString(); //Serial Number
                hardDriveDetails.Add(hd);

            }
        }

        protected override void OnStart(string[] args)
        {
            EventLog.WriteEntry("Shut down service is started");

            System.Timers.Timer T1 = new System.Timers.Timer();
            T1.Interval = timerIntervalInSeconds;
            T1.AutoReset = true;
            T1.Enabled = true;
            T1.Start();
            T1.Elapsed += new System.Timers.ElapsedEventHandler(RunTasks);
        }

        public void RunTasks(object sender, ElapsedEventArgs e)
        {
            DataTable dt = DBHelper.GetDataTable("GetActiveGeneralEntites", null, null, true);

            string[] startTime = timeToShutDown.Split(':');
            string[] endTime = startTime;
            int increaseHour = Convert.ToInt32(endTime[0]);
            increaseHour++;
            endTime[0] = increaseHour.ToString();
            string alertMessage = "המחשב יכבה בעוד 15 דקות";

            try
            {
                if (dt.Rows.Count > 0)
                {
                    string[] times = dt.Rows[1]["entity_value"].ToString().Split(',');
                    startTime = times[0].Split(':');
                    endTime = times[1].Split(':');
                    daysToSkip = dt.Rows[0]["entity_value"].ToString();
                    alertMessage = !string.IsNullOrEmpty(dt.Rows[0]["message"].ToString()) ? dt.Rows[0]["message"].ToString() : alertMessage;
                }
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Message: " + ex.Message + Environment.NewLine);
                sb.Append("StackTrace: " + ex.StackTrace + Environment.NewLine);
                sb.Append("Source: " + ex.Source + Environment.NewLine);

                WriteEventLog(sb.ToString());
            }

            int startResults = TimeSpan.Compare(DateTime.Now.TimeOfDay, new TimeSpan(Convert.ToInt32(startTime[0]), Convert.ToInt32(startTime[1]), Convert.ToInt32(startTime[2])));
            int endResults = TimeSpan.Compare(new TimeSpan(Convert.ToInt32(endTime[0]), Convert.ToInt32(endTime[1]), Convert.ToInt32(endTime[2])), DateTime.Now.TimeOfDay);
            int stratResultsAlertTime = TimeSpan.Compare(DateTime.Now.AddMinutes(-15).TimeOfDay, new TimeSpan(Convert.ToInt32(startTime[0]), Convert.ToInt32(startTime[1]), Convert.ToInt32(startTime[2])));

            if (stratResultsAlertTime == 1)
            {
                int leftTime = Math.Abs(Convert.ToInt32(startTime[1]) - DateTime.Now.Minute);
                alertMessage = string.Format(dt.Rows[0]["message"].ToString(), leftTime);

                WriteEventLog(alertMessage, EventLogEntryType.Information);
            }

            if (startResults == 1 && endResults == 1 && !daysToSkip.ToLower().Contains(DateTime.Now.DayOfWeek.ToString().ToLower()))
            {
                ComputerShutDown.ShutDown();
            }
        }

        private void WriteEventLog(string alertMessage, EventLogEntryType eventLogEntryType = EventLogEntryType.Error)
        {
            if (!EventLog.SourceExists(this.ServiceName))
            {
                EventLog.CreateEventSource("Application", this.ServiceName);
            }

            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = this.ServiceName;
                eventLog.WriteEntry(alertMessage, eventLogEntryType);
            }
        }

        protected override void OnStop()
        {
            EventLog.WriteEntry("Shut down service is ended");
        }
    }
}
