using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iron_Mountain_Coding_Challenge.Models
{
    public class ApplicationMessages
    {
        public ErrorMessageGroup Errors { get; set; }
        public InfoMessageGroup Info { get; set; }
    }

    public class ErrorMessageGroup
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
    }

    public class InfoMessageGroup
    {
        public string EmployeeSaved { get; set; }
        public string EmployeesNotFound { get; set; }
        public string ExportComplete { get; set; }
        public string TextFileExported { get; set; }
        public string XMLFileCreated { get; set; }
    }

}
