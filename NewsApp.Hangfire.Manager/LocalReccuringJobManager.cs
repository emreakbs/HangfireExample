using NewsApp.Hangfire.Manager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Hangfire.Manager
{
    public class LocalReccuringJobManager : ILocalRecuringJobManager
    {
        public void ReccuringJob()
        {
            Console.WriteLine("Recurring Job Running...");
        }
    }
}
