using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileSharing.Controllers
{
    public class FileController : Controller
    {
        IHostingEnvironment _appEnvironment;
        MyRepository repository;

        public FileController(IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
            repository = new MyRepository();
        }
        [HttpGet]
        public IActionResult ShareFile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ShareFile(string shortdescription, string description, IFormFile file)
        {
            var a = file.FileName.Split('.');
            var parh = _appEnvironment.WebRootPath + "/";// + key +
            string path = "." + a[a.Length - 1];
            var key = repository.SaveSimpleFile(shortdescription, description, file.FileName, parh, path);

            if (file != null)
            {
                using (var filestream = new FileStream(key.FilePath, FileMode.Create))
                {
                    await file.CopyToAsync(filestream);
                }
            }
            return RedirectToAction("ShowUrl", "File", new { url = key.FileShortKey });
        }

        public IActionResult ShowUrl(string url)
        {
            ViewData["shorturl"] = Request.Scheme + "://" + Request.Host + "/" + url;
            return View();
        }

        public FileResult GetFile(string url)
        {
            var a = repository.GetFile(url);
            using (WebClient wc = new WebClient())
            {
                var byteArr = wc.DownloadData(a.FilePath);
                return File(byteArr, "multiple");
            }
        }
            
        //[HttpGet]
        //public IActionResult GetFile(string url)
        //{
        //    var a = repository.GetFile(url);
        //    if (a.FileShortKey != url) { return NotFound(); }
        //    else return View();
        //}
        //[HttpPost]
        //public FileResult GetFile(string url)
        //{
        //    var a = repository.GetFile(url);
        //    using (WebClient wc = new WebClient())
        //    {
        //        var byteArr = wc.DownloadData(a.FilePath);
        //        return File(byteArr, "multiple");
        //    }
        //}
    }
}