using Iron_Mountain_Coding_Challenge.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Iron_Mountain_Coding_Challenge.Utilities
{
    public static class XmlExporter
    {
        [XmlRoot("Employees")]
        public class EmployeeListWrapper
        {
            [XmlElement("Employee")]
            public List<EmployeeXml> Employees { get; set; } = new List<EmployeeXml>();
        }

        public class EmployeeXml
        {
            [XmlAttribute("ID")]
            public int EmployeeID { get; set; }

            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string DateOfBirth { get; set; }
        }

        public static string ExportEmployeesToXml(List<Employee> employees)
        {
            try
            {
                // Convert to serializable wrapper
                var wrapper = new EmployeeListWrapper();
                foreach (var emp in employees)
                {
                    wrapper.Employees.Add(new EmployeeXml
                    {
                        EmployeeID = emp.EmployeeID,
                        LastName = emp.LastName,
                        FirstName = emp.FirstName,
                        DateOfBirth = emp.DOB.ToString("MM/dd/yyyy")
                    });
                }

                string outputPath = ConfigurationManager.AppSettings["XmlOutputPath"];
                if (!Directory.Exists(outputPath))
                    Directory.CreateDirectory(outputPath);

                string fileName = $"EmployeeData_{DateTime.Now:yyyyMMdd_HHmmss}.xml";
                string fullPath = Path.Combine(outputPath, fileName);

                var serializer = new XmlSerializer(typeof(EmployeeListWrapper));
                using (var writer = new StreamWriter(fullPath, false, Encoding.UTF8))
                {
                    serializer.Serialize(writer, wrapper);
                }

                return fullPath;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to export XML: " + ex.Message, ex);
            }
        }
    }
}
