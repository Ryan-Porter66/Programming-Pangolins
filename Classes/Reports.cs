using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PayrollManagement.Classes
{
    public class Reports
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "! Cancelling Payroll");
            }

        }
        
        //https://www.codeguru.com/dotnet/generating-a-pdf-document-using-c-net-and-itext-7/
        //https://stackoverflow.com/questions/46928562/itext-7-set-width-of-cells
        //https://kb.itextpdf.com/home/it7kb/faq/how-to-add-a-table-to-the-bottom-of-the-last-page
        //this function will create the PDF paystubs
        private static void CreatePayStubsPDF(EmployeeList empList)
        {
            //ensure the list is bigger than 0
            if (empList == null || empList.GetSizeOfList() < 1)
            {
                throw new ArgumentNullException("Payroll Employee List");
            }

            try
            {
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
                    Paragraph employeeNameParagraph = new Paragraph(String.Format("{0} - {1} {2}", emp.EmployeeID.ToString(), emp.FirstName, emp.LastName));
                    document.Add(employeeNameParagraph);

                    //Print Employee Address
                    Paragraph employeeAddressParagraph = new Paragraph(emp.Address).SetFixedLeading(1);
                    document.Add(employeeAddressParagraph);

                    //Print Employee City
                    Paragraph employeeCityParagraph = new Paragraph(String.Format("{0}, {1} {2}", emp.City, emp.State, emp.PostalCode));
                    document.Add(employeeCityParagraph);

                    document.Add(newline);

                    //Add Company Name
                    Paragraph companyNameParagraph = new Paragraph(empList.Company.Name).SetFixedLeading(1);
                    document.Add(companyNameParagraph);

                    //Add Company Address
                    Paragraph companyAddressParagraph = new Paragraph(empList.Company.Address);
                    document.Add(companyAddressParagraph);

                    //Add Company City
                    Paragraph companyCityParagraph = new Paragraph(String.Format("{0}, {1} {2}", empList.Company.City, empList.Company.State, empList.Company.PostalCode)).SetFixedLeading(1);
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
                    if (emp is SalaryEmployee salaryEmployee)
                    {
                        PrintCellToTable("1.00", payrollTable, "right");
                        PrintCellToTable(salaryEmployee.SalaryPerPayPeriod.ToString("0.00"), payrollTable, "right");
                    }
                    else if (emp is HourlyEmployee hourlyEmployee)
                    {
                        PrintCellToTable(hourlyEmployee.HoursWorked.ToString("0.00"), payrollTable, "right");
                        PrintCellToTable(hourlyEmployee.PayPerHour.ToString("0.00"), payrollTable, "right");
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

                    //add bank info and amount of desposited to bottom of page
                    Paragraph header = new Paragraph(String.Format("{0}:    XXXX{1}   {2}", emp.Bank.BankName, GetLastSubString(emp.Bank.BankAccountNumber, 4), 
                        emp.CalculateNetPay(emp.CalculateGrossPay()).ToString("0.00"))).SetTextAlignment(TextAlignment.RIGHT);
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //this method creates the NACHA file
        private static void CreateNachaFile(EmployeeList empList)
        {
            try
            {
                string filePath = GetSaveLocation("NACHA");
                DateTime todayDate = DateTime.Now;

                Company comp = empList.Company;
                BankAccount compBank = comp.Bank;

                using (StreamWriter streamWriter = new StreamWriter(filePath, false))
                {
                    //file header
                    streamWriter.WriteLine(String.Format("101 {0} 1{1}{2}{3}A094101{4}{5}{6}",
                        GetSubString(compBank.BankRoutingNumber, 9).PadLeft(9), GetSubString(comp.FederalID, 9).PadLeft(9), todayDate.ToString("yyMMdd"), todayDate.ToString("HHmm"),
                        GetSubString(compBank.BankName, 23).PadRight(23), GetSubString(comp.Name, 23).PadRight(23), "".PadRight(8)));

                    //batch header
                    streamWriter.WriteLine(String.Format("5220{0}{1}1{2}PPDPayroll{3}{4}{4}{3}1{5}0000001",
                        GetSubString(comp.Name, 16).PadRight(16), "".PadRight(20), GetSubString(comp.FederalID, 9), "".PadRight(3),
                        todayDate.ToString("yyMMdd"), GetSubString(compBank.BankRoutingNumber, 8).PadLeft(8)));

                    int detailSequenceNumber = 0;
                    foreach(Employee emp in empList.Employees)
                    {
                        BankAccount empBank = emp.Bank;
                        detailSequenceNumber++;

                        //entry detail/transcation
                        streamWriter.WriteLine(String.Format("622{0}{1}{2}{3}{4}{5}{6}0{7}{8}",
                            GetSubString(empBank.BankRoutingNumber, 8).PadRight(8), empBank.BankRoutingNumber.Substring(empBank.BankRoutingNumber.Length - 1), 
                            GetSubString(empBank.BankAccountNumber, 17).PadRight(17), emp.CalculateNetPay(emp.CalculateGrossPay()).ToString().Replace(".", string.Empty).PadLeft(10, '0'), 
                            "".PadRight(15), GetSubString(String.Format("{0} {1}", emp.FirstName, emp.LastName), 22).PadRight(22),
                            "".PadRight(2), GetSubString(empBank.BankRoutingNumber, 8), detailSequenceNumber.ToString().PadLeft(7, '0')));
                        
                    }


                    //batch footer
                    streamWriter.WriteLine(String.Format("8220{0}{1}{2}{3}1{4}{5}{6}0000001",
                        detailSequenceNumber.ToString().PadLeft(6, '0'), GetLastSubString(empList.GetSumOfFirst8DigitsRoute(), 10).PadLeft(10, '0'), "".PadRight(12, '0'),
                        empList.GetNetPayAllEmployeesInList().ToString().Replace(".", string.Empty).PadLeft(12, '0'),
                        GetSubString(comp.FederalID, 9), "".PadRight(25), GetSubString(compBank.BankRoutingNumber, 8)));

                    //file footer
                    //+4 since we have 4 more records (headers and footers)
                    int numBlocks = (int)Math.Ceiling((detailSequenceNumber+4) / 10.0);
                    streamWriter.WriteLine(String.Format("9{0}{1}{2}{3}{4}{5}",
                        "1".PadLeft(6, '0'), numBlocks.ToString().PadLeft(6, '0'), detailSequenceNumber.ToString().PadLeft(8, '0'), GetLastSubString(empList.GetSumOfFirst8DigitsRoute(), 10).PadLeft(10, '0'),
                        "".PadRight(12, '0'), empList.GetNetPayAllEmployeesInList().ToString().Replace(".", string.Empty).PadLeft(12, '0')));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Helper Functions
        //this retrives the location of where to save a file
        private static string GetSaveLocation(string fileType)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Title = "Save file as...",
                Filter = String.Format("{0} files (*.{0})|*.{0}", fileType),
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

        //this prints a cell to the talbe
        private static void PrintCellToTable(string cellText, Table table, string alignment)
        {
            if (cellText == null || cellText.Length < 1)
            {
                throw new ArgumentNullException("cellText");
            }

            Cell cellToAdd = new Cell(1, 1)
                    .SetBorder(Border.NO_BORDER)
                    .Add(new Paragraph(cellText));

            if(alignment.ToLower() == "right")
            {
                cellToAdd.SetTextAlignment(TextAlignment.RIGHT);
            }
            else if(alignment.ToLower() == "left")
            {
                cellToAdd.SetTextAlignment(TextAlignment.LEFT);
            } 
            else
            {
                cellToAdd.SetTextAlignment(TextAlignment.CENTER);
            }
            
            table.AddCell(cellToAdd);
        }

        //this function will get the first digits of a string
        //https://stackoverflow.com/questions/15941985/how-to-get-the-first-five-character-of-a-string
        private static string GetSubString(string stringToTruncate, int digits)
        {
            if (stringToTruncate == null || stringToTruncate.Length < 1)
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
            if (stringToTruncate == null || stringToTruncate.Length < 1)
            {
                throw new ArgumentNullException(stringToTruncate);
            }
            else if(digits < 0)
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
