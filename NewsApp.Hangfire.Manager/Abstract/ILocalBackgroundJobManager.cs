using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Hangfire.Manager.Abstract
{
    public interface ILocalBackgroundJobManager
    {
        string Enqueue();
        string Schedule();
        void ContinueWithSchedule(string jobId);
        void ContinueWithEnqueue(string jobId);
    }
}
