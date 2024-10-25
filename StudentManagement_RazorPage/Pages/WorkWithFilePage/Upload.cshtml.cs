using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentManagement_RazorPage.Pages.WorkWithFilePage
{
    public class UploadModel : PageModel
    {
        public static string DataFilePath { get; private set; } = Path.Combine(Directory.GetCurrentDirectory(), "Data", "default.txt");

        public async Task<IActionResult> OnPostAsync()
        {
            var file = Request.Form.Files["fileUpload"];

            if (file != null && file.Length > 0)
            {
                DataFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", file.FileName);

                using (var stream = new FileStream(DataFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                if (Path.GetExtension(file.FileName).ToLower() == ".json")
                {
                    using (var reader = new StreamReader(DataFilePath))
                    {
                        var fileContent = await reader.ReadToEndAsync();

                        if (fileContent.Contains("\"FullName\""))
                        {
                            return RedirectToPage("StudentFilePage");
                        }
                        else if (fileContent.Contains("\"CourseName\""))
                        {
                            return RedirectToPage("CourseFilePage");
                        }
                        else if (fileContent.Contains("\"EnrollmentDate\""))
                        {
                            return RedirectToPage("EnrollmentFilePage");
                        }
                    }
                }
                else if (Path.GetExtension(file.FileName).ToLower() == ".xml")
                {
                    var xmlDoc = XDocument.Load(DataFilePath);

                    if (xmlDoc.Descendants("FullName").Any())
                    {
                        return RedirectToPage("StudentFilePage");
                    }
                    else if (xmlDoc.Descendants("CourseName").Any())
                    {
                        return RedirectToPage("CourseFilePage");
                    }
                    else if (xmlDoc.Descendants("EnrollmentDate").Any())
                    {
                        return RedirectToPage("EnrollmentFilePage");
                    }
                }
            }

            return RedirectToPage("Upload");
        }
    }
}
