using CommunityContentSubmissionPage.Business.Logic;
using CommunityContentSubmissionPage.Business.Model;
using CommunityContentSubmissionPage.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CommunityContentSubmissionPage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISubmissionSaver submissionSaver;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ISubmissionSaver submissionSaver, ILogger<HomeController> logger)
        {
            this.submissionSaver = submissionSaver;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(new SubmissionModel());
        }
        [HttpPost]
        public async Task<IActionResult> Index(SubmissionModel submissionModel)
        {
            if (ModelState.IsValid is false) return View(submissionModel);

            var submission = new SubmissionEntry
            {
                Url = submissionModel.Url,
                Type = submissionModel.Type,
                EMail = submissionModel.EMail,
                Description = submissionModel.Description
            };
            await submissionSaver.Save(submission);
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}