using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace PreventDeskTool
{
    public class UploadFile
    {
        public static string SaveFile(IFormFile file, string webRootPath,string foldername)
        {
            try
            {
                string Folderpath = Path.Combine(webRootPath, foldername);
                string File = Guid.NewGuid().ToString() + '-' + file.FileName;
                string CompletePath = Path.Combine(Folderpath, File);
                FileStream fileStream = System.IO.File.Create(CompletePath);
                file.CopyTo(fileStream);
                fileStream.Dispose();
                return File;

            }

            catch (Exception e)
            {
                return "Failed";
            }

        }

    }
}
