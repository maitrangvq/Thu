using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Manage(Student sv, string command)
        {
            //demo chạy thử
            //return Content($"vừa nhập {sv.HoTen} - {sv.Diem}");

            //Lưu thông tin xuồng file wwwrot//data/Student.json
            
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "Student.json");
            if(command =="Lưu")
            {
                string json = JsonConvert.SerializeObject(sv);
                System.IO.File.WriteAllText(fullPath, json);
            }
            else if(command =="Mở")
            {
                string json = System.IO.File.ReadAllText(fullPath);
                sv = JsonConvert.DeserializeObject<Student>(json);
            }

            ViewBag.Ma = sv.MaSV;
            ViewBag.Ten = sv.HoTen;
            ViewBag.Diem = sv.Diem;
            ViewBag.Loai = sv.XepLoai;

            //string json = JsonConvert.SerializeObject(sv);
            //System.IO.File.WriteAllText(fullPath, json);
            return View("Index");
        }

        public IActionResult Upload()
        {
            return View();
        }

        public IActionResult UploadFile(IFormFile myfile)
        {
            if(myfile !=null)
            {
                string url = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", myfile.FileName);
                using (var f = new FileStream(url, FileMode.Create))
                {
                    myfile.CopyTo(f);
                }
            }
            return RedirectToAction("Upload");
        }

        public IActionResult UploadFiles(IFormFile[] myfile)
        {
            if (myfile != null)
            {

                foreach (var item in myfile)
                {
                    string url = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", item.FileName);
                    using (var f = new FileStream(url, FileMode.Create))
                    {
                        item.CopyTo(f);
                    }
                }
            }
            return RedirectToAction("Upload");
        }
    }
}