using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace webapp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            ViewData["BUILDID"] = Environment.GetEnvironmentVariable("BUILDID") ?? "0";
	    ViewData["Version"] = GetVersion();

            ViewData["APPENV"] = Environment.GetEnvironmentVariable("APP_ENVIRONMENT") ?? "NONE";
        }

	private string GetVersion()
        {
            return FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;
        }
    }
}
