using _3D_Journal_Statistics.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace _3D_Journal_Statistics.Controllers
{
    public class SoftwareController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();

            string URL = "https://localhost:44379/api/Statistics/GetSoftware";

            HttpResponseMessage response = client.GetAsync(URL).Result;

            var result = response.Content.ReadAsAsync<List<Software>>().Result;

            return View(result);
        }
        public IActionResult Filter(Guid? software)
        {
            HttpClient client = new HttpClient();

            string URL = "";
            if (software == null)
                URL = "https://localhost:44379/api/Statistics/GetProjectsBySoftware";
            else
                URL = "https://localhost:44379/api/Statistics/GetProjectsBySoftware?softwareId=" + software.ToString();

            HttpResponseMessage response = client.GetAsync(URL).Result;
            var result = response.Content.ReadAsAsync<List<Project>>().Result;
            //var result = response.Content.ReadAsStringAsync().Result;

            string fileName = "ProjectsByCategory.xlsx";
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            using (var workBook = new XLWorkbook())
            {
                IXLWorksheet worksheet = workBook.Worksheets.Add("All Orders");

                worksheet.Cell(1, 1).Value = "Project ID";
                worksheet.Cell(1, 2).Value = "Project Name";
                worksheet.Cell(1, 3).Value = "Description";
                worksheet.Cell(1, 4).Value = "Time Stamp";

                for (int i = 1; i <= result.Count(); i++)
                {
                    var item = result[i - 1];

                    worksheet.Cell(i + 1, 1).Value = item.Id.ToString();
                    worksheet.Cell(i + 1, 2).Value = item.Name;
                    worksheet.Cell(i + 1, 3).Value = item.Description;
                    worksheet.Cell(i + 1, 4).Value = item.TimeStamp.ToString();
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);

                    var content = stream.ToArray();

                    return File(content, contentType, fileName);
                }
            }
        }
    }
}
