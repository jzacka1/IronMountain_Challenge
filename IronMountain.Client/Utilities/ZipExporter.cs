
using Iron_Mountain_Coding_Challenge.Utilities.DTO;
using Iron_Mountain_Coding_Challenge.Utilities.Helpers;
using Serilog;
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

                Log.Information($"{AppConfig.AppMessages.Messages.Info.FilesZipped}{zipFilePath}");

                return zipFileDto;
            }
            catch (Exception ex) {
                Log.Error($"{AppConfig.AppMessages.Messages.Errors.ZippedFolderExportFailed}{ex.Message}");
                throw new ApplicationException($"{AppConfig.AppMessages.Messages.Errors.ZippedFolderExportFailed}{ex.Message}");
            }
        }
    }
}
