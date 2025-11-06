using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iron_Mountain_Coding_Challenge.Models
{
    public class AppMessages
    {
        public Messages Messages{ get; set; }
    }
    public class Messages
    {
        public Errors Errors { get; set; }
        public Info Info { get; set; }
    }

    public class Errors
    {
        public string InvalidEmployeeId { get; set; }
        public string EmployeeIdRequired { get; set; }
        public string LastNameRequired { get; set; }
        public string DatabaseSaveFailure { get; set; }
        public string DOBRequired { get; set; }
        public string DOBGreaterThanToday { get; set; }
        public string EmployeesNotFound { get; set; }
        public string ErrorExportingTextFile { get; set; }
        public string ErrorExportingXml { get; set; }
        public string InvalidDateFormat { get; set; }
        public string XMLFileExportFailed { get; set; }
        public string ZippedFolderExportFailed { get; set; }
    }

    public class Info
    {
        public string EmployeeDeleted { get; set; }
        public string EmployeeSaved { get; set; }
        public string EmployeesNotFound { get; set; }
        public string ExportComplete { get; set; }
        public string TextFileExported { get; set; }
        public string TextFileExportedAndCompressed { get; set; }
        public string XMLFileCreated { get; set; }
        public string XMLFileExported { get; set; }
        public string FilesZipped { get; set; }
    }

}
