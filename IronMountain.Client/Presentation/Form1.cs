using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.EMMA;
using Iron_Mountain_Coding_Challenge.Models;
using Iron_Mountain_Coding_Challenge.Repository;
using Iron_Mountain_Coding_Challenge.Services;
using Iron_Mountain_Coding_Challenge.Utilities;
using Iron_Mountain_Coding_Challenge.Utilities.DTO;
using Iron_Mountain_Coding_Challenge.Utilities.Helpers;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Windows.Forms;

namespace Iron_Mountain_Coding_Challenge
{
    public partial class Form1 : Form
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILoggingService _logger;
        private Lazy<INlpClient> _nlpClient;

        public Form1(IEmployeeRepository employeeRepository,
            ILoggingService logger, INlpClient nlpClient)
        {
            InitializeComponent();
            _employeeRepository = employeeRepository;
            _logger = logger;
            _nlpClient = new Lazy<INlpClient>(() => nlpClient);
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

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = null;
                if (employeeIdTxtBox.Text == String.Empty && String.IsNullOrWhiteSpace(employeeIdTxtBox.Text))
                {
                    MessageBox.Show(AppConfig.AppMessages.Messages.Errors.EmployeeIdRequired);
                    _logger.Error(AppConfig.AppMessages.Messages.Errors.EmployeeIdRequired);
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
                    MessageBox.Show(AppConfig.AppMessages.Messages.Errors.LastNameRequired);
                    _logger.Error(AppConfig.AppMessages.Messages.Errors.LastNameRequired);
                    return;
                }

                bool isDateValid = DateTime.TryParseExact(DobTxtBox.Text, "MMddyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dob);

                if (DobTxtBox.Text == String.Empty && String.IsNullOrWhiteSpace(DobTxtBox.Text) && isDateValid)
                {
                    MessageBox.Show(AppConfig.AppMessages.Messages.Errors.DOBRequired);
                    _logger.Error(AppConfig.AppMessages.Messages.Errors.DOBRequired);
                    return;
                }

                if(dob > DateTime.Today)
                {
                    MessageBox.Show(AppConfig.AppMessages.Messages.Errors.DOBGreaterThanToday);
                    _logger.Error(AppConfig.AppMessages.Messages.Errors.DOBGreaterThanToday);
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
                await _employeeRepository.AddAsync(employee);
                _employeeRepository.Save();

                MessageBox.Show(AppConfig.AppMessages.Messages.Info.EmployeeSaved);
                _logger.Info(AppConfig.AppMessages.Messages.Info.EmployeeSaved);
                ClearFields();

            }
            catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
                Log.Error($"Error: {ex.Message}");
            }
        }

        private async void createTxtFileBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var employees = new List<Employee>(await _employeeRepository.GetAllAsync());

                if (employees.Count == 0)
                {
                    MessageBox.Show(AppConfig.AppMessages.Messages.Errors.EmployeesNotFound);
                    _logger.Error(AppConfig.AppMessages.Messages.Errors.EmployeesNotFound);
                    return;
                }

                //Create new text file
                TextFileDto txtFileDto = TextExporter.ExportEmployeesToTextFile(employees);

                //Put new text file into folder
                ZipFileDto zipFileDto = ZipExporter.ExportFilesToZipFolder(new List<TextFileDto>() { txtFileDto });

                MessageBox.Show($"{AppConfig.AppMessages.Messages.Info.TextFileExported}{zipFileDto.ZipFilePath}");
                _logger.Info($"{AppConfig.AppMessages.Messages.Info.TextFileExported}{zipFileDto.ZipFilePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{AppConfig.AppMessages.Messages.Errors.ErrorExportingTextFile}{ex.Message}");
                _logger.Error($"{AppConfig.AppMessages.Messages.Errors.ErrorExportingTextFile}{ex.Message}");
            }
        }

        private async void createXmlFileBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var employees = await _employeeRepository.GetAllAsync();

                if (employees == null)
                {
                    MessageBox.Show(AppConfig.AppMessages.Messages.Errors.EmployeesNotFound);
                    _logger.Error(AppConfig.AppMessages.Messages.Errors.EmployeesNotFound);
                    return;
                }

                string xmlPath = XmlExporter.ExportEmployeesToXml(new List<Employee>(employees));

                MessageBox.Show($"{AppConfig.AppMessages.Messages.Info.XMLFileCreated}{xmlPath}");
                _logger.Info($"{AppConfig.AppMessages.Messages.Info.XMLFileCreated}{xmlPath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{AppConfig.AppMessages.Messages.Errors.ErrorExportingTextFile}{ex.Message}");
                _logger.Error($"{AppConfig.AppMessages.Messages.Errors.ErrorExportingTextFile}{ex.Message}");
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
                MessageBox.Show($"{AppConfig.AppMessages.Messages.Errors.InvalidDateFormat}");
                _logger.Error($"{AppConfig.AppMessages.Messages.Errors.InvalidDateFormat}");
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

        private async void naturalLanguageSearchBtn_Click(object sender, EventArgs e)
        {
            var nlp = new NlpClient();

            var filters = await nlp.ParseQuery(txtSrchPrmpt.Text);

            var results = await _employeeRepository.SearchByNlp(filters);

            dgvResults.DataSource = results;
        }
    }
}
