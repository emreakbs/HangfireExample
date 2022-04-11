using Hangfire;
using Microsoft.AspNetCore.Mvc;
using NewsApp.Hangfire.Manager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.Hangfire.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController : Controller
    {
        private readonly IRecurringJobManager _reccuringJobManager;
        private readonly ILocalRecuringJobManager _localReccuringJobManager;
        private readonly ILocalBackgroundJobManager _localBackgroundJobManager;
        public JobController(ILocalRecuringJobManager localReccuringJobManager,
                             ILocalBackgroundJobManager localBackgroundJobManager,
                             IRecurringJobManager recurringJobManager)
        {
            _localBackgroundJobManager = localBackgroundJobManager;
            _localReccuringJobManager = localReccuringJobManager;
            _reccuringJobManager = recurringJobManager;
        }
        public IActionResult Index()
        {
            return Ok();
        }
        [HttpGet("CreateConsoleWriteJob")]
        public IActionResult CreateConsoleWriteJob()
        {
            _reccuringJobManager.AddOrUpdate("CreateConsoleWriteJob", () => _localReccuringJobManager.ReccuringJob(), Cron.MinuteInterval(2));
            return StatusCode(201, "Created !");
        }
        [HttpGet("BackgroundJobEnqueue")]
        public IActionResult BackgroundJobEnqueue()
        {
            var jobId = _localBackgroundJobManager.Enqueue();
            _localBackgroundJobManager.ContinueWithEnqueue(jobId);
            return StatusCode(200, "OK !");
        }
        [HttpGet("BackgroundJobSchedule")]
        public IActionResult BackgroundJobSchedule()
        {
            var jobId = _localBackgroundJobManager.Schedule();
            _localBackgroundJobManager.ContinueWithSchedule(jobId);
            return StatusCode(200, "OK !");
        }
    }
}
