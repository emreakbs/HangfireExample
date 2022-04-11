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
        public JobController(ILocalRecuringJobManager localReccuringJobManager, IRecurringJobManager recurringJobManager)
        {
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
            return StatusCode(201,"Created !");
        }
    }
}
