using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.EMMA;
using Iron_Mountain_Coding_Challenge.Models;
using Iron_Mountain_Coding_Challenge.Repository;
using Iron_Mountain_Coding_Challenge.Utilities;
using Iron_Mountain_Coding_Challenge.Utilities.DTO;
using Serilog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Iron_Mountain_Coding_Challenge
{
    public partial class Form1 : Form
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMessageProvider _messageProvider;
        private readonly ILoggingService _logger;

        public Form1(IEmployeeRepository employeeRepository, 
                    IMessageProvider messageProvider, 
                    ILoggingService logger)
        {
            InitializeComponent();
            _employeeRepository = employeeRepository;
            _messageProvider = messageProvider;
            _logger = logger;
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
                e.Handled = true;
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
                    MessageBox.Show(_messageProvider.Messages.Errors.EmployeeIdRequired);
                    _logger.Error(_messageProvider.Messages.Errors.EmployeeIdRequired);
                    return;
                }

                // Reformat to 00000000
                if (employeeIdTxtBox.Text.Length < 8)
                {
                    int num = Convert.ToInt32(employeeIdTxtBox.Text);
                    string id = num.ToString("00000000");

                    employeeIdTxtBox.Text = id;
                }

                if (lastNameTxtBox.Text == String.Empty && String.IsNullOrWhiteSpace(employeeIdTxtBox.Text))
                {
                    MessageBox.Show(_messageProvider.Messages.Errors.LastNameRequired);
                    _logger.Error(_messageProvider.Messages.Errors.LastNameRequired);
                    return;
                }

                bool isDateValid = DateTime.TryParseExact(DobTxtBox.Text, "MMddyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dob);

                if (DobTxtBox.Text == String.Empty && String.IsNullOrWhiteSpace(DobTxtBox.Text) && isDateValid)
                {
                    MessageBox.Show(_messageProvider.Messages.Errors.DOBRequired);
                    _logger.Error(_messageProvider.Messages.Errors.DOBRequired);
                    return;
                }

                if(dob > DateTime.Today)
                {
                    MessageBox.Show(_messageProvider.Messages.Errors.DOBGreaterThanToday);
                    _logger.Error(_messageProvider.Messages.Errors.DOBGreaterThanToday);
                    return;
                }

                var employee = new Employee
                {
                    EmployeeID = employeeIdTxtBox.Text,
                    FirstName = firstNameTxtBox.Text.Trim(),
                    LastName = lastNameTxtBox.Text.Trim(),
                    DOB = dob
                };

                // Add to repository
                _employeeRepository.Add(employee);
                _employeeRepository.Save();

                MessageBox.Show(_messageProvider.Messages.Info.EmployeeSaved);
                _logger.Info(_messageProvider.Messages.Info.EmployeeSaved);
                ClearFields();

            }
            catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
                Log.Error($"Error: {ex.Message}");
            }
        }

        private void createTxtFileBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var employees = new List<Employee>(_employeeRepository.GetAll());

                if (employees.Count == 0)
                {
                    MessageBox.Show(_messageProvider.Messages.Errors.EmployeesNotFound);
                    _logger.Error(_messageProvider.Messages.Errors.EmployeesNotFound);
                    return;
                }

                //Create new text file
                TextFileDto txtFileDto = TextExporter.ExportEmployeesToTextFile(employees);

                //Put new text file into folder
                ZipFileDto zipFileDto = ZipExporter.ExportFilesToZipFolder(new List<TextFileDto>() { txtFileDto });

                MessageBox.Show($"{_messageProvider.Messages.Info.TextFileExported}{zipFileDto.ZipFilePath}");
                _logger.Info($"{_messageProvider.Messages.Info.TextFileExported}{zipFileDto.ZipFilePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{_messageProvider.Messages.Errors.ErrorExportingTextFile}{ex.Message}");
                _logger.Error($"{_messageProvider.Messages.Errors.ErrorExportingTextFile}{ex.Message}");
            }
        }

        private void createXmlFileBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var employees = _employeeRepository.GetAll();

                if (employees == null)
                {
                    MessageBox.Show(_messageProvider.Messages.Errors.EmployeesNotFound);
                    _logger.Error(_messageProvider.Messages.Errors.EmployeesNotFound);
                    return;
                }

                string xmlPath = XmlExporter.ExportEmployeesToXml(new List<Employee>(employees));

                MessageBox.Show($"{_messageProvider.Messages.Info.XMLFileCreated}{xmlPath}");
                _logger.Info($"{_messageProvider.Messages.Info.XMLFileCreated}{xmlPath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{_messageProvider.Messages.Errors.ErrorExportingTextFile}{ex.Message}");
                _logger.Error($"{_messageProvider.Messages.Errors.ErrorExportingTextFile}{ex.Message}");
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
                MessageBox.Show($"{_messageProvider.Messages.Errors.InvalidDateFormat}");
                _logger.Error($"{_messageProvider.Messages.Errors.InvalidDateFormat}");
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
