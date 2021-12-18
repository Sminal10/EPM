using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EPM.Models;

namespace EPM.ImgLib
{
    public class ImageLibrary
    {
        public string[] SaveBase64StringInFolder(string base64String, string filename, string folderName)
        {
            var vfilename = "";
            var filepath = "";
            try
            {
                if(base64String.Length > (filename.Length + folderName.Length + 8))
                {
                    int extensionStartIndex = base64String.IndexOf('/');
                    int extensionEndIndex = base64String.IndexOf(';');
                    int filetypeStartIndex = base64String.IndexOf(':');
                    extensionEndIndex = extensionEndIndex - extensionStartIndex;
                    string fileExtension = base64String.Substring(extensionStartIndex + 1, extensionEndIndex - 1);
                    string fileType = base64String.Substring(filetypeStartIndex + 1, extensionStartIndex);
                    if (filename.Length > 50 || filename.Length < 1) 
                    {
                        vfilename = Guid.NewGuid().ToString();
                    }
                    else
                    {
                        vfilename = filename;
                    }

                    filename = vfilename + "." + fileExtension;
                    base64String = base64String.Substring(base64String.IndexOf(",") + 1);
                    if(base64String.Length > 0 && base64String != "undefined")
                    {
                        byte[] bytes = Convert.FromBase64String(base64String);
                        var path = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot/" + folderName, filename);

                        using (var imageFile = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
                        {
                            imageFile.Write(bytes, 0, bytes.Length);
                            imageFile.Flush();
                        };
                    }
                    filepath = "\\" + folderName + "\\" + filename;
                }
                else
                {
                    filepath = base64String;
                    vfilename = filename;
                }

                return new[] { filepath, vfilename };
            }
            catch(Exception ex)
            {
                return new[] { "Error", ex.Message }; 
            }
        }
    }
}
