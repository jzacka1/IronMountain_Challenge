using Iron_Mountain_Coding_Challenge.Models;
using Iron_Mountain_Coding_Challenge.Repository;
using Iron_Mountain_Coding_Challenge.Utilities;
using Iron_Mountain_Coding_Challenge.Utilities.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Iron_Mountain_Coding_Challenge
{
    public partial class Form1 : Form
    {
        private readonly IEmployeeRepository _employeeRepository;

        public Form1(IEmployeeRepository employeeRepository)
        {
            InitializeComponent();
            _employeeRepository = employeeRepository;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void employeeIdTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void DobTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block non-numeric input
            }
        }

        private void firstNameTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void lastNameTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = null;
                if (employeeIdTxtBox.Text == String.Empty && String.IsNullOrWhiteSpace(employeeIdTxtBox.Text))
                {
                    return;
                }

                if (lastNameTxtBox.Text == String.Empty && String.IsNullOrWhiteSpace(employeeIdTxtBox.Text))
                {
                    return;
                }

                bool isDateValid = DateTime.TryParseExact(DobTxtBox.Text, "MMddyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dob);

                if (DobTxtBox.Text == String.Empty && String.IsNullOrWhiteSpace(DobTxtBox.Text) && isDateValid)
                {
                    return;
                }

                if(dob > DateTime.Today)
                {
                    return;
                }

                var employee = new Employee
                {
                    EmployeeID = Int32.Parse(employeeIdTxtBox.Text),
                    FirstName = firstNameTxtBox.Text.Trim(),
                    LastName = lastNameTxtBox.Text.Trim(),
                    DOB = dob
                };

                // Add to repository
                _employeeRepository.Add(employee);
                _employeeRepository.Save();

                MessageBox.Show("Employee saved successfully!");
                ClearFields();

            }
            catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void createTxtFileBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var employees = new List<Employee>(_employeeRepository.GetAll());

                if (employees.Count == 0)
                {
                    MessageBox.Show("No employees found in the database to export.");
                    return;
                }

                //string zipPath = TextExporter.ExportEmployeesToTextFile(employees);

                //Create new text file
                TextFileDto txtFileDto = TextExporter.ExportEmployeesToTextFile(employees);

                //Put new text file into folder
                ZipFileDto zipFileDto = ZipExporter.ExportFilesToZipFolder(new List<TextFileDto>() { txtFileDto });

                MessageBox.Show($"Text file exported and compressed successfully!\n\nLocation:\n{zipFileDto.ZipFilePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting text file: " + ex.Message);
            }
        }

        private void createXmlFileBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var employees = _employeeRepository.GetAll();

                if (employees == null)
                {
                    MessageBox.Show("No employees found.");
                    return;
                }

                string xmlPath = XmlExporter.ExportEmployeesToXml(new List<Employee>(employees));

                MessageBox.Show($"XML file created successfully:\n{xmlPath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting XML: " + ex.Message);
            }
        }

        private void DobTxtBox_Leave(object sender, EventArgs e)
        {
            DateTime parsedDate;
            if (!DateTime.TryParseExact(DobTxtBox.Text, "MMddyyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out parsedDate) &&
                parsedDate <= DateTime.Today)
            {
                MessageBox.Show("Please enter a valid date in MMddyyyy format.");
            }
        }

        private void ClearFields()
        {
            employeeIdTxtBox.Clear();
            firstNameTxtBox.Clear();
            lastNameTxtBox.Clear();
            DobTxtBox.Clear();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }
    }
}
