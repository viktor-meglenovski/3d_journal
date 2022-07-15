using _3D_Journal_Statistics.Models;
using ExcelDataReader;
using GemBox.Document;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _3D_Journal_Statistics.Controllers
{
    public class UserController : Controller
    {
        public UserController()
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        }
        public IActionResult Import()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Import(IFormFile file)
        {

            //make a copy
            string pathToUpload = $"{Directory.GetCurrentDirectory()}\\files\\{file.FileName}";


            using (FileStream fileStream = System.IO.File.Create(pathToUpload))
            {
                file.CopyTo(fileStream);

                fileStream.Flush();
            }

            //read data from uploaded file

            List<AppUser> users = getUsersFromExcelFile(file.FileName);

            HttpClient client = new HttpClient();

            string URL = "https://localhost:44379/api/Statistics/ImportAllUsers";



            HttpContent content = new StringContent(JsonConvert.SerializeObject(users), Encoding.UTF8, "application/json");


            HttpResponseMessage response = client.PostAsync(URL, content).Result;

            var result = response.Content.ReadAsStringAsync().Result;
            //var result = response.Content.ReadAsAsync<bool>().Result;

            return RedirectToAction("Index", "Home");
        }

        private List<AppUser> getUsersFromExcelFile(string fileName)
        {

            string pathToFile = $"{Directory.GetCurrentDirectory()}\\files\\{fileName}";

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            List<AppUser> userList = new List<AppUser>();

            using (var stream = System.IO.File.Open(pathToFile, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        userList.Add(new AppUser
                        {
                            Name = reader.GetValue(0).ToString(),
                            LastName = reader.GetValue(1).ToString(),
                            Email = reader.GetValue(2).ToString(),
                            Password = reader.GetValue(3).ToString(),
                        });
                    }
                }
            }
            return userList;
        }

        public IActionResult Export()
        {
            //get all users
            HttpClient client = new HttpClient();

            string URL = "https://localhost:44379/api/Statistics/GetAllUsers";

            HttpResponseMessage response = client.GetAsync(URL).Result;

            var result = response.Content.ReadAsAsync<List<UserDTO>>().Result;

            return View(result);
        }

        public IActionResult ExportUser(string id)
        {
            //export to pdf
            HttpClient client = new HttpClient();

            string URL = "https://localhost:44379/api/Statistics/GetDetailsForUser?id="+id;

            HttpResponseMessage response = client.GetAsync(URL).Result;

            var result = response.Content.ReadAsAsync<UserDTOForExport>().Result;

            var templatePath = Path.Combine("./", "ExportUser.docx");
            var document = DocumentModel.Load(templatePath);

            document.Content.Replace("{{UserId}}", result.Id.ToString());
            document.Content.Replace("{{Email}}", result.Email);
            document.Content.Replace("{{FirstName}}", result.FirstName);
            document.Content.Replace("{{LastName}}", result.LastName);
            document.Content.Replace("{{Projects}}", result.Projects.ToString());
            document.Content.Replace("{{Likes}}", result.Likes.ToString());
            document.Content.Replace("{{Income}}", "$"+result.Income.ToString());


            var stream = new MemoryStream();
            document.Save(stream, new PdfSaveOptions());
            return File(stream.ToArray(), new PdfSaveOptions().ContentType, "ExportUser.pdf");

        }
    }
}
