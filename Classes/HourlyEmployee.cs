using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ClassDiagram
{
    public class HourlyEmployee : Employee
    {
        decimal payPerHour;
        decimal hoursWorked;

        public decimal calculateGrossPay()
        {
            throw new NotImplementedException();
        }

        public decimal getPayrollHours()
        {
            throw new NotImplementedException();
        }
    }
}
