using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Hangfire.Manager.Abstract
{
    public interface ILocalRecuringJobManager
    {
        void ReccuringJob();
    }
}
