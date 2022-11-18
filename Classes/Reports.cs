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
        public static void compilePayrollData(EmployeeList empList)
        {
            try
            {
                foreach(var emp in empList.Employees)
                {
                    if(emp is HourlyEmployee hourlyEmp)
                    {
                        hourlyEmp.getPayrollHours();
                    }
                }
                createPayStubsPDF(empList);
                createNachaFile(empList);
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
        private static void createPayStubsPDF(EmployeeList empList)
        {
            //ensure the list is bigger than 0
            if (empList == null || empList.getSizeOfList() < 1)
            {
                throw new ArgumentNullException("Payroll Employee List");
            }

            try
            {
                string filePath = getSaveLocation("PDF");

                PdfWriter writer = new PdfWriter(filePath);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);

                Paragraph newline = new Paragraph(new Text("\n"));
                LineSeparator lineSeparator = new LineSeparator(new SolidLine());

                int loopCounter = 0, numberOfEmployees = empList.getSizeOfList();
                foreach (Employee emp in empList.Employees)
                {
                    loopCounter++;  //used to keep track of last employee so do not add extra page
                    
                    //display date on top right
                    DateTime todayDate = DateTime.Today;
                    Paragraph timeParagraph = new Paragraph(todayDate.ToString("MM/dd/yyyy")).SetTextAlignment(TextAlignment.RIGHT);
                    document.Add(timeParagraph);
                    document.Add(newline);

                    //prints Employee Name and ID
                    Paragraph employeeNameParagraph = new Paragraph(String.Format("{0} - {1} {2}", emp.employeeID.ToString(), emp.firstName, emp.lastName));
                    document.Add(employeeNameParagraph);

                    //Print Employee Address
                    Paragraph employeeAddressParagraph = new Paragraph(emp.address).SetFixedLeading(1);
                    document.Add(employeeAddressParagraph);

                    //Print Employee City
                    Paragraph employeeCityParagraph = new Paragraph(String.Format("{0}, {1} {2}", emp.city, emp.state, emp.postalCode));
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

                    printCellToTable("Compensation", payrollTable, "left");
                    printCellToTable("Hrs.", payrollTable, "right");
                    printCellToTable("Rate", payrollTable, "right");
                    printCellToTable("Current", payrollTable, "right");


                    printCellToTable("Reg. Hours", payrollTable, "left");
                    if (emp is SalaryEmployee salaryEmployee)
                    {
                        printCellToTable("1.00", payrollTable, "right");
                        printCellToTable(salaryEmployee.SalaryPerPayPeriod.ToString("0.00"), payrollTable, "right");
                    }
                    else if (emp is HourlyEmployee hourlyEmployee)
                    {
                        printCellToTable(hourlyEmployee.HoursWorked.ToString("0.00"), payrollTable, "right");
                        printCellToTable(hourlyEmployee.PayPerHour.ToString("0.00"), payrollTable, "right");
                    }
                    printCellToTable(emp.calculateGrossPay().ToString("0.00"), payrollTable, "right");

                    printCellToTable("Gross Pay", payrollTable, "left");
                    printCellToTable(" ", payrollTable, "right");
                    printCellToTable(" ", payrollTable, "right");
                    printCellToTable(emp.calculateGrossPay().ToString("0.00"), payrollTable, "right");

                    printCellToTable("Net Adj. Gross", payrollTable, "left");
                    printCellToTable(" ", payrollTable, "right");
                    printCellToTable(" ", payrollTable, "right");
                    printCellToTable(emp.calculateNetPay(emp.calculateGrossPay()).ToString("0.00"), payrollTable, "right");

                    document.Add(payrollTable);
                    document.Add(lineSeparator);

                    //Add Table for Deduction Information
                    float[] colWidthsDeductionTable = { 110f, 40f };
                    float totalColWidthDeductionTable = colWidthsDeductionTable.Sum();
                    Table deductionTable = new Table(UnitValue.CreatePointArray(colWidthsDeductionTable));
                    deductionTable.SetWidth(totalColWidthDeductionTable);

                    printCellToTable("Deductions", deductionTable, "left");
                    printCellToTable("Current", deductionTable, "center");

                    printCellToTable("FICA", deductionTable, "left");
                    printCellToTable(Math.Round(emp.calculateFICATax(), 2).ToString("0.00"), deductionTable, "right");

                    printCellToTable("Medical", deductionTable, "left");
                    printCellToTable(Math.Round(emp.calculateMedTax(), 2).ToString("0.00"), deductionTable, "right");

                    printCellToTable("State Tax", deductionTable, "left");
                    printCellToTable(Math.Round(emp.calculateStateTax(), 2).ToString("0.00"), deductionTable, "right");

                    printCellToTable("Federal W/H", deductionTable, "left");
                    printCellToTable(Math.Round(emp.calculateFederalTax(), 2).ToString("0.00"), deductionTable, "right");

                    printCellToTable("Other W/H", deductionTable, "left");
                    printCellToTable(Math.Round(emp.calculateTotalNonTaxDeductionAmount(), 2).ToString("0.00"), deductionTable, "right");

                    document.Add(deductionTable);

                    //add bank info and amount of desposited to bottom of page
                    Paragraph header = new Paragraph(String.Format("{0}:    XXXX{1}   {2}", emp.bank.bankName, getLastSubString(emp.bank.bankAccountNumber, 4), 
                        emp.calculateNetPay(emp.calculateGrossPay()).ToString("0.00"))).SetTextAlignment(TextAlignment.RIGHT);
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
        private static void createNachaFile(EmployeeList empList)
        {
            try
            {
                string filePath = getSaveLocation("NACHA");
                DateTime todayDate = DateTime.Now;

                Company comp = empList.Company;
                BankAccount compBank = comp.Bank;

                using (StreamWriter streamWriter = new StreamWriter(filePath, false))
                {
                    //file header
                    streamWriter.WriteLine(String.Format("101 {0} 1{1}{2}{3}A094101{4}{5}{6}",
                        getSubString(compBank.bankRoutingNumber, 9).PadLeft(9), getSubString(comp.FederalID, 9).PadLeft(9), todayDate.ToString("yyMMdd"), todayDate.ToString("HHmm"),
                        getSubString(compBank.bankName, 23).PadRight(23), getSubString(comp.Name, 23).PadRight(23), "".PadRight(8)));

                    //batch header
                    streamWriter.WriteLine(String.Format("5220{0}{1}1{2}PPDPayroll{3}{4}{4}{3}1{5}0000001",
                        getSubString(comp.Name, 16).PadRight(16), "".PadRight(20), getSubString(comp.FederalID, 9), "".PadRight(3),
                        todayDate.ToString("yyMMdd"), getSubString(compBank.bankRoutingNumber, 8).PadLeft(8)));

                    int detailSequenceNumber = 0;
                    foreach(Employee emp in empList.Employees)
                    {
                        BankAccount empBank = emp.bank;
                        detailSequenceNumber++;

                        //entry detail/transcation
                        streamWriter.WriteLine(String.Format("622{0}{1}{2}{3}{4}{5}{6}0{7}{8}",
                            getSubString(empBank.bankRoutingNumber, 8).PadRight(8), empBank.bankRoutingNumber.Substring(empBank.bankRoutingNumber.Length - 1), 
                            getSubString(empBank.bankAccountNumber, 17).PadRight(17), emp.calculateNetPay(emp.calculateGrossPay()).ToString().Replace(".", string.Empty).PadLeft(10, '0'), 
                            "".PadRight(15), getSubString(String.Format("{0} {1}", emp.firstName, emp.lastName), 22).PadRight(22),
                            "".PadRight(2), getSubString(empBank.bankRoutingNumber, 8), detailSequenceNumber.ToString().PadLeft(7, '0')));
                        
                    }


                    //batch footer
                    streamWriter.WriteLine(String.Format("8220{0}{1}{2}{3}1{4}{5}{6}0000001",
                        detailSequenceNumber.ToString().PadLeft(6, '0'), getLastSubString(empList.getSumOfFirst8DigitsRoute(), 10).PadLeft(10, '0'), "".PadRight(12, '0'),
                        empList.getNetPayAllEmployeesInList().ToString().Replace(".", string.Empty).PadLeft(12, '0'),
                        getSubString(comp.FederalID, 9), "".PadRight(25), getSubString(compBank.bankRoutingNumber, 8)));

                    //file footer
                    //+4 since we have 4 more records (headers and footers)
                    int numBlocks = (int)Math.Ceiling((detailSequenceNumber+4) / 10.0);
                    streamWriter.WriteLine(String.Format("9{0}{1}{2}{3}{4}{5}",
                        "1".PadLeft(6, '0'), numBlocks.ToString().PadLeft(6, '0'), detailSequenceNumber.ToString().PadLeft(8, '0'), getLastSubString(empList.getSumOfFirst8DigitsRoute(), 10).PadLeft(10, '0'),
                        "".PadRight(12, '0'), empList.getNetPayAllEmployeesInList().ToString().Replace(".", string.Empty).PadLeft(12, '0')));
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
        private static string getSaveLocation(string fileType)
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
        private static void printCellToTable(string cellText, Table table, string alignment)
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
        private static string getSubString(string stringToTruncate, int digits)
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
        private static string getLastSubString(string stringToTruncate, int digits)
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
