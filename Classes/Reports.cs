using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PayrollManagement.Classes
{
    public static class Reports
    {
        #region Main Methods
        //compiles all the employee data and calls the file creation functions (PDF and NACHA)
        public static void CompilePayrollData(EmployeeList empList)
        {
            try
            {
                foreach(var emp in empList.Employees)
                {
                    if(emp is HourlyEmployee hourlyEmp)
                    {
                        hourlyEmp.GetPayrollHours();
                    }
                }
                CreatePayStubsPDF(empList);
                CreateNachaFile(empList);
                MessageBox.Show(@"Payroll Successfully Completed!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + @" Cancelling Payroll");
            }

        }
        
        //https://www.codeguru.com/dotnet/generating-a-pdf-document-using-c-net-and-itext-7/
        //https://stackoverflow.com/questions/46928562/itext-7-set-width-of-cells
        //https://kb.itextpdf.com/home/it7kb/faq/how-to-add-a-table-to-the-bottom-of-the-last-page
        //this function will create the PDF pay stubs
        private static void CreatePayStubsPDF(EmployeeList empList)
        {
            //ensure the list is bigger than 0
            if (empList == null || empList.GetSizeOfList() < 1)
            {
                throw new ArgumentNullException(nameof(empList));
            }

            string filePath = GetSaveLocation("PDF");

            PdfWriter writer = new PdfWriter(filePath);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            Paragraph newline = new Paragraph(new Text("\n"));
            LineSeparator lineSeparator = new LineSeparator(new SolidLine());

            int loopCounter = 0, numberOfEmployees = empList.GetSizeOfList();
            foreach (Employee emp in empList.Employees)
            {
                loopCounter++;  //used to keep track of last employee so do not add extra page
                    
                //display date on top right
                DateTime todayDate = DateTime.Today;
                Paragraph timeParagraph = new Paragraph(todayDate.ToString("MM/dd/yyyy")).SetTextAlignment(TextAlignment.RIGHT);
                document.Add(timeParagraph);
                document.Add(newline);

                //prints Employee Name and ID
                Paragraph employeeNameParagraph = new Paragraph(
                    $"{emp.EmployeeID.ToString()} - {emp.FirstName} {emp.LastName}");
                document.Add(employeeNameParagraph);

                //Print Employee Address
                Paragraph employeeAddressParagraph = new Paragraph(emp.Address).SetFixedLeading(1);
                document.Add(employeeAddressParagraph);

                //Print Employee City
                Paragraph employeeCityParagraph = new Paragraph($"{emp.City}, {emp.State} {emp.PostalCode}");
                document.Add(employeeCityParagraph);

                document.Add(newline);

                //Add Company Name
                Paragraph companyNameParagraph = new Paragraph(empList.Company.Name).SetFixedLeading(1);
                document.Add(companyNameParagraph);

                //Add Company Address
                Paragraph companyAddressParagraph = new Paragraph(empList.Company.Address);
                document.Add(companyAddressParagraph);

                //Add Company City
                Paragraph companyCityParagraph = new Paragraph(
                    $"{empList.Company.City}, {empList.Company.State} {empList.Company.PostalCode}").SetFixedLeading(1);
                document.Add(companyCityParagraph);

                //Add Company Phone Number
                Paragraph companyPhoneParagraph = new Paragraph(empList.Company.PhoneNumber);
                document.Add(companyPhoneParagraph);

                document.Add(lineSeparator);

                //Add Table for Pay Information
                float[] colWidthsPayrollTable = { 110f, 40f, 60f, 70f };
                float totalColWidthPayrollTable = colWidthsPayrollTable.Sum();
                Table payrollTable = new Table(UnitValue.CreatePointArray(colWidthsPayrollTable));
                payrollTable.SetWidth(totalColWidthPayrollTable);

                PrintCellToTable("Compensation", payrollTable, "left");
                PrintCellToTable("Hrs.", payrollTable, "right");
                PrintCellToTable("Rate", payrollTable, "right");
                PrintCellToTable("Current", payrollTable, "right");


                PrintCellToTable("Reg. Hours", payrollTable, "left");
                switch (emp)
                {
                    case SalaryEmployee salaryEmployee:
                        PrintCellToTable("1.00", payrollTable, "right");
                        PrintCellToTable(salaryEmployee.SalaryPerPayPeriod.ToString("0.00"), payrollTable, "right");
                        break;
                    case HourlyEmployee hourlyEmployee:
                        PrintCellToTable(hourlyEmployee.HoursWorked.ToString("0.00"), payrollTable, "right");
                        PrintCellToTable(hourlyEmployee.PayPerHour.ToString("0.00"), payrollTable, "right");
                        break;
                }
                PrintCellToTable(emp.CalculateGrossPay().ToString("0.00"), payrollTable, "right");

                PrintCellToTable("Gross Pay", payrollTable, "left");
                PrintCellToTable(" ", payrollTable, "right");
                PrintCellToTable(" ", payrollTable, "right");
                PrintCellToTable(emp.CalculateGrossPay().ToString("0.00"), payrollTable, "right");

                PrintCellToTable("Net Adj. Gross", payrollTable, "left");
                PrintCellToTable(" ", payrollTable, "right");
                PrintCellToTable(" ", payrollTable, "right");
                PrintCellToTable(emp.CalculateNetPay(emp.CalculateGrossPay()).ToString("0.00"), payrollTable, "right");

                document.Add(payrollTable);
                document.Add(lineSeparator);

                //Add Table for Deduction Information
                float[] colWidthsDeductionTable = { 110f, 40f };
                float totalColWidthDeductionTable = colWidthsDeductionTable.Sum();
                Table deductionTable = new Table(UnitValue.CreatePointArray(colWidthsDeductionTable));
                deductionTable.SetWidth(totalColWidthDeductionTable);

                PrintCellToTable("Deductions", deductionTable, "left");
                PrintCellToTable("Current", deductionTable, "center");

                PrintCellToTable("FICA", deductionTable, "left");
                PrintCellToTable(Math.Round(emp.CalculateFICATax(), 2).ToString("0.00"), deductionTable, "right");

                PrintCellToTable("Medical", deductionTable, "left");
                PrintCellToTable(Math.Round(emp.CalculateMedTax(), 2).ToString("0.00"), deductionTable, "right");

                PrintCellToTable("State Tax", deductionTable, "left");
                PrintCellToTable(Math.Round(emp.CalculateStateTax(), 2).ToString("0.00"), deductionTable, "right");

                PrintCellToTable("Federal W/H", deductionTable, "left");
                PrintCellToTable(Math.Round(emp.CalculateFederalTax(), 2).ToString("0.00"), deductionTable, "right");

                PrintCellToTable("Other W/H", deductionTable, "left");
                PrintCellToTable(Math.Round(emp.CalculateTotalNonTaxDeductionAmount(), 2).ToString("0.00"), deductionTable, "right");

                document.Add(deductionTable);

                //add bank info and amount of deposited to bottom of page
                Paragraph header = new Paragraph(
                    $"{emp.Bank.BankName}:    XXXX{GetLastSubString(emp.Bank.BankAccountNumber, 4)}   {emp.CalculateNetPay(emp.CalculateGrossPay()):0.00}").SetTextAlignment(TextAlignment.RIGHT);
                PageSize pageSize = pdf.GetDefaultPageSize();
                header.SetFixedPosition(document.GetLeftMargin(), document.GetBottomMargin(), pageSize.GetWidth() - document.GetLeftMargin() - document.GetRightMargin());
                document.Add(header);

                if(loopCounter != numberOfEmployees)
                {
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                }
            }
                
            document.Close();
            pdf.Close();
            writer.Close();
        }

        //this method creates the NACHA file
        private static void CreateNachaFile(EmployeeList empList)
        {
            string filePath = GetSaveLocation("NACHA");
            DateTime todayDate = DateTime.Now;

            Company comp = empList.Company;
            BankAccount compBank = comp.Bank;

            using (StreamWriter streamWriter = new StreamWriter(filePath, false))
            {
                //file header
                streamWriter.WriteLine(
                    $"101 {GetSubString(compBank.BankRoutingNumber, 9),9} 1{GetSubString(comp.FederalID, 9),9}" +
                    $"{todayDate:yyMMdd}{todayDate:HHmm}A094101{GetSubString(compBank.BankName, 23),-23}" +
                    $"{GetSubString(comp.Name, 23),-23}{"",-8}");

                //batch header
                streamWriter.WriteLine("5220{0}{1}1{2}PPDPayroll{3}{4:yyMMdd}{4:yyMMdd}{3}1{5}0000001", GetSubString(comp.Name, 16).PadRight(16), "".PadRight(20), 
                    GetSubString(comp.FederalID, 9), "".PadRight(3), todayDate, GetSubString(compBank.BankRoutingNumber, 8).PadLeft(8));

                int detailSequenceNumber = 0;
                foreach(Employee emp in empList.Employees)
                {
                    BankAccount empBank = emp.Bank;
                    detailSequenceNumber++;

                    //entry detail/transaction
                    streamWriter.WriteLine(
                        $"622{GetSubString(empBank.BankRoutingNumber, 8),-8}{empBank.BankRoutingNumber.Substring(empBank.BankRoutingNumber.Length - 1)}" +
                        $"{GetSubString(empBank.BankAccountNumber, 17),-17}{emp.CalculateNetPay(emp.CalculateGrossPay()).ToString(CultureInfo.InvariantCulture).Replace(".", string.Empty).PadLeft(10, '0')}" +
                        $"{"",-15}{GetSubString($"{emp.FirstName} {emp.LastName}", 22),-22}{"",-2}" +
                        $"0{GetSubString(empBank.BankRoutingNumber, 8)}{detailSequenceNumber.ToString().PadLeft(7, '0')}");
                        
                }


                //batch footer
                streamWriter.WriteLine(
                    $"8220{detailSequenceNumber.ToString().PadLeft(6, '0')}{GetLastSubString(empList.GetSumOfFirst8DigitsRoute(), 10).PadLeft(10, '0')}" +
                    $"{"".PadRight(12, '0')}{empList.GetNetPayAllEmployeesInList().ToString(CultureInfo.InvariantCulture).Replace(".", string.Empty).PadLeft(12, '0')}" +
                    $"1{GetSubString(comp.FederalID, 9)}{"",-25}{GetSubString(compBank.BankRoutingNumber, 8)}0000001");

                //file footer
                //+4 since we have 4 more records (headers and footers)
                int numBlocks = (int)Math.Ceiling((detailSequenceNumber+4) / 10.0);
                streamWriter.WriteLine(
                    $"9{"1".PadLeft(6, '0')}{numBlocks.ToString().PadLeft(6, '0')}{detailSequenceNumber.ToString().PadLeft(8, '0')}" +
                    $"{GetLastSubString(empList.GetSumOfFirst8DigitsRoute(), 10).PadLeft(10, '0')}" +
                    $"{"".PadRight(12, '0')}{empList.GetNetPayAllEmployeesInList().ToString(CultureInfo.InvariantCulture).Replace(".", string.Empty).PadLeft(12, '0')}");
            }
        }
        #endregion
        #region Helper Functions
        //this retrieves the location of where to save a file
        private static string GetSaveLocation(string fileType)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Title = @"Save file as...",
                Filter = string.Format(@"{0} files (*.{0})|*.{0}", fileType),
                RestoreDirectory = true
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.FileName == "")
                {
                    throw new Exception("Need a valid file name.");
                }
            }
            else
            {
                throw new Exception("Need a save location.");
            }

            return dialog.FileName;
        }

        //this prints a cell to the table
        private static void PrintCellToTable(string cellText, Table table, string alignment)
        {
            if (string.IsNullOrEmpty(cellText))
            {
                throw new ArgumentNullException(nameof(cellText));
            }

            Cell cellToAdd = new Cell(1, 1)
                    .SetBorder(Border.NO_BORDER)
                    .Add(new Paragraph(cellText));

            switch (alignment.ToLower())
            {
                case "right":
                    cellToAdd.SetTextAlignment(TextAlignment.RIGHT);
                    break;
                case "left":
                    cellToAdd.SetTextAlignment(TextAlignment.LEFT);
                    break;
                default:
                    cellToAdd.SetTextAlignment(TextAlignment.CENTER);
                    break;
            }
            
            table.AddCell(cellToAdd);
        }

        //this function will get the first digits of a string
        //https://stackoverflow.com/questions/15941985/how-to-get-the-first-five-character-of-a-string
        private static string GetSubString(string stringToTruncate, int digits)
        {
            if (string.IsNullOrEmpty(stringToTruncate))
            {
                throw new ArgumentNullException(stringToTruncate);
            }

            return !String.IsNullOrWhiteSpace(stringToTruncate) && stringToTruncate.Length >= digits
                    ? stringToTruncate.Substring(0, digits)
                    : stringToTruncate;
        }

        //this function will return the last number (digits) of characters from the string
        private static string GetLastSubString(string stringToTruncate, int digits)
        {
            if (string.IsNullOrEmpty(stringToTruncate))
            {
                throw new ArgumentNullException(stringToTruncate);
            }
            if(digits < 0)
            {
                throw new ArgumentException(digits.ToString());
            }

            return !String.IsNullOrWhiteSpace(stringToTruncate) && stringToTruncate.Length >= digits
                    ? stringToTruncate.Substring(stringToTruncate.Length - digits)
                    : stringToTruncate;
        }
        #endregion
    }
}
