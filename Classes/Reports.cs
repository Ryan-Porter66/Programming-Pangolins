using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout;
using System.Windows.Forms;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout.Borders;
using iText.Kernel.Geom;

namespace PayrollManagement.Classes
{
    public class Reports
    {
        //https://www.codeguru.com/dotnet/generating-a-pdf-document-using-c-net-and-itext-7/
        //https://stackoverflow.com/questions/46928562/itext-7-set-width-of-cells
        //https://kb.itextpdf.com/home/it7kb/faq/how-to-add-a-table-to-the-bottom-of-the-last-page
        //this function will create the PDF paystubs
        public static void createPayStubsPDF()
        {
            // Must have write permissions to the path folder

            try
            {
                string filePath = getSaveLocation("PDF");

                PdfWriter writer = new PdfWriter(filePath);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);

                Paragraph newline = new Paragraph(new Text("\n"));
                LineSeparator lineSeparator = new LineSeparator(new SolidLine());

                //display date on top right
                DateTime todayDate = DateTime.Today;
                Paragraph timeParagraph = new Paragraph(todayDate.ToString("MM/dd/yyyy")).SetTextAlignment(TextAlignment.RIGHT);
                document.Add(timeParagraph);
                document.Add(newline);

                //replace later
                //prints Employee Name and ID
                Paragraph employeeNameParagraph = new Paragraph(String.Format("{0} {1} {2} {3}", "999", "Ryan", "D", "Porter"));
                document.Add(employeeNameParagraph);

                //replace later
                //Print Employee Address
                Paragraph employeeAddressParagraph = new Paragraph("515 Jones Street").SetFixedLeading(1);
                document.Add(employeeAddressParagraph);

                //replace later
                //Print Employee City
                Paragraph employeeCityParagraph = new Paragraph(String.Format("{0}, {1} {2}", "Aberdeen", "SD", "57401"));
                document.Add(employeeCityParagraph);

                document.Add(newline);

                //change later
                //Add Company Name
                Paragraph companyNameParagraph = new Paragraph("Hello There Co.").SetFixedLeading(1);
                document.Add(companyNameParagraph);

                //change later
                //Add Company Address
                Paragraph companyAddressParagraph = new Paragraph("515 Jones Street");
                document.Add(companyAddressParagraph);

                //change later
                //Add Company City
                Paragraph companyCityParagraph = new Paragraph(String.Format("{0}, {1} {2}", "Aberdeen", "SD", "57401")).SetFixedLeading(1);
                document.Add(companyCityParagraph);

                //change later
                //Add Company Phone Number
                Paragraph companyPhoneParagraph = new Paragraph("999-999-9999");
                document.Add(companyPhoneParagraph);

                document.Add(lineSeparator);

                //Add Table for Pay Information
                float[] colWidthsPayrollTable = { 40, 20, 20, 20 };
                Table payrollTable = new Table(UnitValue.CreatePercentArray(colWidthsPayrollTable));
                payrollTable.SetWidth(UnitValue.CreatePercentValue(75f));

                printCellToTable("Compensation", payrollTable);
                printCellToTable("Hrs.", payrollTable);
                printCellToTable("Rate", payrollTable);
                printCellToTable("Current", payrollTable);

                printCellToTable("Reg. Hours", payrollTable);
                printCellToTable("99.99", payrollTable);
                printCellToTable("99.99", payrollTable);
                printCellToTable("10000.00", payrollTable);

                printCellToTable("Gross Pay", payrollTable);
                printCellToTable("99.99", payrollTable);
                printCellToTable("99.99", payrollTable);
                printCellToTable("10000.00", payrollTable);

                printCellToTable("Net Adj. Gross", payrollTable);
                printCellToTable("99.99", payrollTable);
                printCellToTable("99.99", payrollTable);
                printCellToTable("10000.00", payrollTable);

                document.Add(payrollTable);
                document.Add(lineSeparator);

                //Add Table for Deduction Information
                float[] colWidthsDeductionTable = { 40, 60 };
                Table deductionTable = new Table(UnitValue.CreatePercentArray(colWidthsDeductionTable));
                deductionTable.SetWidth(UnitValue.CreatePercentValue(75f));

                printCellToTable("Deductions", deductionTable);
                printCellToTable("Current", deductionTable);

                printCellToTable("FICA", deductionTable);
                printCellToTable("99.99", deductionTable);

                printCellToTable("Medical", deductionTable);
                printCellToTable("99.99", deductionTable);

                printCellToTable("State Tax", deductionTable);
                printCellToTable("99.99", deductionTable);

                printCellToTable("Federal W/H", deductionTable);
                printCellToTable("99.99", deductionTable);

                printCellToTable("Other W/H", deductionTable);
                printCellToTable("99.99", deductionTable);

                document.Add(deductionTable);

                //add bank info and amount of desposited to bottom of page
                Paragraph header = new Paragraph(String.Format("{0}:    XXXX{1}   {2}", "Bank of America", "9999", "9999.99")).SetTextAlignment(TextAlignment.RIGHT);
                PageSize pageSize = pdf.GetDefaultPageSize();
                header.SetFixedPosition(document.GetLeftMargin(), document.GetBottomMargin(), pageSize.GetWidth() - document.GetLeftMargin() - document.GetRightMargin());
                document.Add(header);

                document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                document.Close();
                pdf.Close();
                writer.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void createNachaFile()
        {

        }
        
        //this retrives the location of where to save a file
        private static string getSaveLocation(string fileType)
        {
            
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Title = "Save file as...";
            dialog.Filter = String.Format("{0} files (*.{0})|*.{0}", fileType);
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if(dialog.FileName == "")
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
        private static void printCellToTable(string cellText, Table table)
        {
            Cell cellToAdd = new Cell(1, 1)
                    .SetBorder(Border.NO_BORDER)
                    .Add(new Paragraph(cellText));

            table.AddCell(cellToAdd);
        }
    }
}
