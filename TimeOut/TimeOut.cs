public class TimeOut
{
    /// <param name="TaskAction">Function delegate for task to perform</param>
    /// <param name="TimeoutSeconds">Time to allow before task times out</param>
    /// <returns></returns>
    public static T? RunTaskWithTimeout<T>(Func<T> TaskAction, int TimeoutSeconds)
    {
        Task<T> backgroundTask;

        try
        {
            backgroundTask = Task.Factory.StartNew(TaskAction);
            backgroundTask.Wait(new TimeSpan(0, 0, TimeoutSeconds));
        }
        catch (AggregateException ex)
        {
            // task failed
            var failMessage = ex.Flatten().InnerException.Message;
            return default(T);
        }
        catch (Exception ex)
        {
            // task failed
            var failMessage = ex.Message;
            return default(T);
        }

        if (!backgroundTask.IsCompleted)
        {
            // task timed out
            return default(T);
        }

        // task succeeded
        return backgroundTask.Result;
    }

}
