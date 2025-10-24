
using Iron_Mountain_Coding_Challenge.Utilities.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.IO.Compression;

namespace Iron_Mountain_Coding_Challenge.Utilities
{
    public static class ZipExporter
    {
        public static ZipFileDto ExportFilesToZipFolder(List<TextFileDto> txtFileList)
        {
            string outputPath = ConfigurationManager.AppSettings["ZipOutputPath"];
            
            if (!Directory.Exists(outputPath))
                Directory.CreateDirectory(outputPath);

            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture);
            
            string zipFileName = $"EmployeeData_{timestamp}.zip";
            
            string zipFilePath = Path.Combine(outputPath, zipFileName);

            try
            {
                // Compress the text file into a zip file
                using (var zip = ZipFile.Open(zipFilePath, ZipArchiveMode.Create))
                {
                    foreach (var file in txtFileList)
                    {
                        zip.CreateEntryFromFile(file.TxtFilePath, file.TxtFileName, CompressionLevel.Optimal);

                        // Delete the original text file (optional, since it’s inside the zip)
                        File.Delete(file.TxtFilePath);
                    }
                }

                ZipFileDto zipFileDto = new ZipFileDto()
                {
                    ZipFileName = zipFileName,
                    ZipFilePath = zipFilePath
                };

                return zipFileDto;
            }
            catch (Exception ex) {
                throw new ApplicationException("Error while exporting zip file: " + ex.Message, ex);
            }
        }
    }
}
