using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
        string HDUniqueIdentity = string.Empty;

        string action = "";
        string[] startTime = null;
        string[] endTime = null;
        int increaseHour = 0;
        string alertMessage = "המחשב יכבה בעוד 15 דקות";
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

            HDUniqueIdentity = Utilities.Utilities.GetHDUniqueIdentity();
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

            startTime = timeToShutDown.Split(':');
            endTime = startTime;
            increaseHour = Convert.ToInt32(endTime[0]);
            increaseHour++;
            endTime[0] = increaseHour.ToString();
        }

        public void RunTasks(object sender, ElapsedEventArgs e)
        {
            string[] param = new string[1] { "Identifier" };
            object[] paramValue = new object[1] { HDUniqueIdentity };
            DataTable dt = DBHelper.GetDataTable("GetActiveGeneralEntites", param, paramValue, true);
            WriteEventLog(HDUniqueIdentity, EventLogEntryType.Warning);

            LockComputer(dt);

            BlockUrl(dt);

            ComputerShutDown(dt);
        }

        private void LockComputer(DataTable dt)
        {
            WriteEventLog("Start LockScreen", EventLogEntryType.Information);
            try
            {
                action = System.Reflection.MethodBase.GetCurrentMethod().Name;
                RunTaskByTime(dt, ref startTime, ref endTime, ref alertMessage, action);
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Message: " + ex.Message + Environment.NewLine);
                sb.Append("StackTrace: " + ex.StackTrace + Environment.NewLine);
                sb.Append("Source: " + ex.Source + Environment.NewLine);

                WriteEventLog(sb.ToString());
            }
            WriteEventLog("End LockScreen", EventLogEntryType.Information);
        }

        private void BlockUrl(DataTable dt)
        {
            WriteEventLog("Start BlockUrl", EventLogEntryType.Information);
            try
            {
                string hostsPath = @"C:\Windows\System32\drivers\etc\hosts";
                string localIp = "127.0.0.1";
                WriteEventLog("BlockUrl dt.rows=" + dt.Rows.Count.ToString(), EventLogEntryType.Information); ;

                if (dt.Rows.Count > 0)
                {

                    string[] urls = dt.Rows[2]["entity_value"].ToString().Split(',');
                    string[] times = dt.Rows[3]["entity_value"].ToString().Split(',');
                    string[] startTime = times[0].Split(':');
                    string[] endTime = times[1].Split(':');
                    string[] hosts = File.ReadAllLines(hostsPath);
                    List<string> hostsLines = hosts.ToList();
                    string hostsFileTxt = File.ReadAllText(hostsPath);

                    int startResults = TimeSpan.Compare(DateTime.Now.TimeOfDay, new TimeSpan(Convert.ToInt32(startTime[0]), Convert.ToInt32(startTime[1]), Convert.ToInt32(startTime[2])));
                    int endResults = TimeSpan.Compare(new TimeSpan(Convert.ToInt32(endTime[0]), Convert.ToInt32(endTime[1]), Convert.ToInt32(endTime[2])), DateTime.Now.TimeOfDay);

                    if (startResults == 1 && endResults == 1)
                    {
                        WriteEventLog("BlockUrl startResults=" + startResults.ToString() + " endResults=" + endResults.ToString(), EventLogEntryType.Information); ;

                        foreach (string url in urls)
                        {
                            if (hostsFileTxt.Contains(localIp + " " + url))
                            {
                                hostsFileTxt.Replace("#" + localIp + " " + url, localIp + " " + url);
                            }
                            else
                            {
                                hostsFileTxt += Environment.NewLine + localIp + " " + url;
                            }
                        }
                    }
                    else
                    {
                        foreach (string url in urls)
                        {
                            if (hostsFileTxt.Contains(localIp + " " + url))
                            {
                                hostsFileTxt = hostsFileTxt.Replace(localIp + " " + url, "");
                            }
                        }
                    }
                    File.WriteAllText(hostsPath, hostsFileTxt);
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
            WriteEventLog("End BlockUrl", EventLogEntryType.Information);

        }

        private void ComputerShutDown(DataTable dt)
        {
            //MessageBox.Show(alertMessage);
            action = System.Reflection.MethodBase.GetCurrentMethod().Name;
            RunTaskByTime(dt, ref startTime, ref endTime, ref alertMessage, action);
        }

        private void RunTaskByTime(DataTable dt, ref string[] startTime, ref string[] endTime, ref string alertMessage, string action)
        {
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
                switch (action)
                {
                    case "ComputerShutDown":
                        WindowsService.ComputerShutDown.ShutDown();
                        break;
                    case "LockComputer":
                        LockScreen.LockWorkStation();
                        break;
                    default:
                        // code block
                        break;
                }

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
