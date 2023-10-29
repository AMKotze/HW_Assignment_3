using System;
using HW_Assignment_3.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;
using System.Globalization;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace HW_Assignment_3.Controllers
{
    public class ReportController : Controller
    {
        private LibraryEntities db = new LibraryEntities();
        // GET: Report
        public ActionResult ReportIndex()
        {
            var mostBorrowed = db.borrows
            .GroupBy(b => b.books.typeId)
            .Select(group => new
            {
                TypeId = group.Key,
                BorrowCount = group.Count()
            })
            .OrderByDescending(b => b.BorrowCount)
            .Take(5)
            .ToList();

            var typeNames = mostBorrowed
            .Select(type =>
            {
                var typeResult = db.types.FirstOrDefault(t => t.typeId == type.TypeId);
                return typeResult != null ? typeResult.name : "Unknown";
            })
            .ToList();

            var borrowCounts = mostBorrowed.Select(type => type.BorrowCount).ToList();


            var topStudents = db.students
            .OrderByDescending(s => s.point)
            .Take(10)
            .ToList();

            var studentNames = topStudents.Select(s => s.name).ToList();
            var studentSurnames = topStudents.Select(s => s.surname).ToList();
            var studentClasses = topStudents.Select(s => s.@class).ToList();
            var points = topStudents.Select(s => s.point ?? 0).ToList();

            var viewModel = new CombinedReport
            {
                StudentNames = studentNames,
                StudentSurnames = studentSurnames,
                StudentClasses = studentClasses,
                Points = points,
                TypeNames = typeNames,
                BorrowCounts = borrowCounts
            };


            return View(viewModel);
        }

        public ActionResult DownloadPdf(string fileName)
        {
            string filePath = Server.MapPath("~/pdfs/" + fileName);

            if (System.IO.File.Exists(filePath))
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                return File(fileBytes, "application/pdf", fileName);
            }
            else
            {
                return HttpNotFound("File not found");
            }
        }


    }

}