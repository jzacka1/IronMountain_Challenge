using Iron_Mountain_Coding_Challenge.Models;
using Iron_Mountain_Coding_Challenge.Utilities.DTO;
using Iron_Mountain_Coding_Challenge.Utilities.Helpers;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Text;

namespace Iron_Mountain_Coding_Challenge.Utilities
{
    public static class TextExporter
    {
        public static TextFileDto ExportEmployeesToTextFile(List<Employee> employees)
        {
            if (employees == null || employees.Count == 0) {
                Log.Error(AppConfig.AppMessages.Messages.Errors.EmployeesNotFound);
                throw new ApplicationException(AppConfig.AppMessages.Messages.Errors.EmployeesNotFound);
            }

            string outputPath = ConfigurationManager.AppSettings["TxtOutputPath"];
            if (!Directory.Exists(outputPath))
                Directory.CreateDirectory(outputPath);

            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture);
            string txtFileName = $"EmployeeData_{timestamp}.txt";
            string txtFilePath = Path.Combine(outputPath, txtFileName);

            try
            {
                // Write all employee data to the text file
                using (var writer = new StreamWriter(txtFilePath, false, Encoding.UTF8))
                {
                    foreach (var emp in employees)
                    {
                        string line = $"{emp.EmployeeID}|{emp.LastName}|{emp.FirstName}|{emp.DOB:MM/dd/yyyy}";
                        writer.WriteLine(line);
                    }
                }

                TextFileDto txtFileDto = new TextFileDto()
                {
                    TxtFileName = txtFileName,
                    TxtFilePath = txtFilePath
                };

                Log.Information($"{AppConfig.AppMessages.Messages.Info.TextFileExported}{txtFilePath}");

                return txtFileDto;
            }
            catch (Exception ex)
            {
                Log.Error($"{AppConfig.AppMessages.Messages.Errors.ErrorExportingTextFile}{ex.Message}");
                throw new ApplicationException($"{AppConfig.AppMessages.Messages.Errors.ErrorExportingTextFile}\n\n{ex.Message}");
            }
        }
    }
}
