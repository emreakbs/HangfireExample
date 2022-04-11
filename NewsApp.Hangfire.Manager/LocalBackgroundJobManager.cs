using Hangfire;
using NewsApp.Hangfire.Manager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Hangfire.Manager
{
    public class LocalBackgroundJobManager : ILocalBackgroundJobManager
    {

        public void ContinueWithEnqueue(string jobId)
        {
            BackgroundJob.ContinueWith(jobId, () => Console.WriteLine("ContinueWithEnqueue Job Running..."));
        }

        public void ContinueWithSchedule(string jobId)
        {
            BackgroundJob.ContinueWith(jobId, () => Console.WriteLine("ContinueWithSchedule Job Running..."));
        }

        public string Enqueue()
        {
            return BackgroundJob.Enqueue(() => Console.WriteLine("Enqueue Job Running..."));
        }

        public string Schedule()
        {
            Console.WriteLine("Wait for 20 second..");
            return BackgroundJob.Schedule(() => Console.WriteLine("Schedule Job Running..."), TimeSpan.FromSeconds(20));
        }
    }
}
