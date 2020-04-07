//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using FileUpload.Models;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;

//namespace FileUpload.Controllers
//{
//    public class FileUploadController : Controller
//    {
//        private readonly IWebHostEnvironment _env;
//        private readonly ILogger<FileUploadController> _logger;
//        public FileUploadController(ILogger<FileUploadController> logger, IWebHostEnvironment env)
//        {
//            _logger = logger;
//            _env = env;
//        }
//        public IActionResult Index()
//        {
//            return View();
//        }
//        [HttpPost]
//        public IActionResult upload(File fileUpload)
//        {
//            if(fileUpload.formFile!=null)
//            {
//                string ext = System.IO.Path.GetExtension(fileUpload.formFile.FileName);
//                if (ext==".pdf")
//                {
//                    string filepath = $"{_env.WebRootPath}/images/{fileUpload.formFile.FileName}";
//                    var stream = System.IO.File.Create(filepath);
//                    fileUpload.formFile.CopyTo(stream);
//                    TempData["success"] = " submitted successfully";
//                }
//                else
//                {
//                    TempData["error"] = "Only pdf is allowed";
//                    return RedirectToAction("Index", "FileUpload");
//                }
//            }
           
//            return Redirect("/");


//        }
//    }
//}