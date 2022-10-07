namespace TimeOutFramwork4_0
{
    public class TimeOutFramwork4_0
    {

        public static void CallTimedOutMethod(Action method, Action callBackMethod, int milliseconds)
        {
            new Thread(new ThreadStart(() =>
            {
                Thread actionThread = new Thread(new ThreadStart(() =>
                {
                    ActualMethodWrapper(method, callBackMethod);
                }));

                actionThread.Start();
                Thread.Sleep(milliseconds);
                if (actionThread.IsAlive)
                {
                    actionThread.Interrupt();
                    actionThread.Join();
                    //actionThread.Abort();
                }

            })).Start();
        }

        static void ActualMethodWrapper(Action method, Action callBackMethod)
        {
            try
            {
                method.Invoke();
            }
            catch (ThreadAbortException)
            {
                Console.WriteLine("Method aborted early");
            }
            finally
            {
                //callBackMethod.Invoke();
            }
        }

        public static bool TST()
        {
            var task = Task.Factory.StartNew(() => LongRunningMethod());//you can pass parameters to the method as well
            if (task.Wait(TimeSpan.FromSeconds(30)))
                return task.IsCompleted; //the method returns elegantly
            else
                throw new TimeoutException();//the method timed-out
        }

        private static void LongRunningMethod()
        {
            throw new NotImplementedException();
        }
    }

    //public static class CancellationTokenSourceExtensions
    //{
    //    //        var tokeSource = new CancellationTokenSource();
    //    //        Task.Run(() => { Console.WriteLine("processing"); }, tokenSource.Token);
    //    //tokenSource.CancelAfter(TimeSpan.FromSeconds(30));
    //    public static Task Delay(double milliseconds)
    //    {
    //        var tcs = new TaskCompletionSource<bool>();
    //        System.Timers.Timer timer = new System.Timers.Timer();
    //        timer.Elapsed += (o, e) => tcs.TrySetResult(true);
    //        timer.Interval = milliseconds;
    //        timer.AutoReset = false;
    //        timer.Start();
    //        return tcs.Task;
    //    }
    //    //public static Task CancelAfter(this CancellationTokenSource cts, TimeSpan timeout)
    //    //{

    //    //    //return Task.Delay(timeout).ContinueWith(t => cts.Cancel());
    //    //}


    //}

}