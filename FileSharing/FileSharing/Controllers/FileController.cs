using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FileSharing.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileSharing.Controllers
{
    public class FileController : Controller
    {
        IHostingEnvironment _appEnvironment;
        MyDbContext db;

        public FileController(MyDbContext context, IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
            db = context;
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
            var key  = SaveSimpleFile(shortdescription, description, file.FileName, parh, path);

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
            var a = GetFile1(url);
            using (WebClient wc = new WebClient())
            {
                var byteArr = wc.DownloadData(a.FilePath);
                return File(byteArr, "multiple");
            }
        }

        private AplicationFile SaveSimpleFile(string shortdescription, string description, string filename, string path1, string path2)
        {
            string key = GetUniqueKey(6);
            bool b = Cheker(key);
            while (b)
            {
                key = GetUniqueKey(6);
            }

            AplicationFile file = new AplicationFile
            {
                NameFile = filename,
                DiscriptionFile = description,
                ShortDiscriptionFile = shortdescription,
                FileCountDownload = 0,
                Type = FileType.SimpleFile,
                FileShortKey = key,
                FilePath = path1 + key + path2
            };
            db.aplicationFiles.Add(file);
            return file;
        }

        public AplicationFile GetFile1(string key)
        {
            //var b = db.aplicationFiles.All(x=>x);
            var a = db.aplicationFiles.FirstOrDefault(x => x.FileShortKey == key);
            return a;
        }

        private string GetUniqueKey(int size)
        {
            char[] chars =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[size];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        private bool Cheker(string str)
        {
            var f = db.aplicationFiles.FirstOrDefault(x => x.FileShortKey == str);
            if (f != null && f.FileShortKey != str) { return true; }
            else return false;
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