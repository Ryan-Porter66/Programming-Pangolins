using System.Net.Http;
using System.Net;
using System.Text;
using System.IO;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PayrollManagement.Classes
{
    public static class Database
    {
        /*public static Employee GetEmployee(string username, string passwordHash, int empID)
        {
            string enc = "yHdeGH1Dl56vt28/Rdi+PvnWWqz62EEB/dBA2aMLOWw8PRtHzGk1VUcsSjX/Y9Q6jtQT8SYykjQof6/6Wrid2dcjWAr2ZSwjBSPKLC6OctU=";
            string url = Encryption.AESDecryption(enc);

            var request = (HttpWebRequest)WebRequest.Create(url);

            var postData = "username=" + Uri.EscapeDataString(username);
            postData += "&password=" + Uri.EscapeDataString(passwordHash);
            postData += "&empid=" + Uri.EscapeDataString(empID.ToString());

            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseText = reader.ReadToEnd();

            var Jobj = (JObject)JsonConvert.DeserializeObject(responseText);
            string empid = Jobj["emp_id"].ToString();


        }*/

        public static string AddEmployee(string username, string passwordHash, Employee emp)
        {
            string enc = "yHdeGH1Dl56vt28/Rdi+PvnWWqz62EEB/dBA2aMLOWw8PRtHzGk1VUcsSjX/Y9Q6jtQT8SYykjQof6/6Wrid2dcjWAr2ZSwjBSPKLC6OctU=";
            string url = Encryption.AESDecryption(enc);

            var request = (HttpWebRequest)WebRequest.Create(url);

            var postData = "username=" + Uri.EscapeDataString(username);
            postData += "&password=" + Uri.EscapeDataString(passwordHash);
            postData += "&firstName=" + Uri.EscapeDataString(emp.FirstName);
            postData += "&lastName=" + Uri.EscapeDataString(emp.LastName);
            postData += "&ssn=" + Uri.EscapeDataString(emp.Ssn);
            postData += "&dob=" + Uri.EscapeDataString(emp.Dob.ToString("yyyy-mm-dd"));
            postData += "&phonenumber=" + Uri.EscapeDataString(emp.PhoneNumber);
            postData += "&hiredate=" + Uri.EscapeDataString(emp.HireDate.ToString("yyyy-mm-dd"));

            if (emp is HourlyEmployee hourlyEmployee)
            {
                postData += "&hourlyrate=" + Uri.EscapeDataString(hourlyEmployee.PayPerHour.ToString());
                postData += "&salary=" + Uri.EscapeDataString("0");
                postData += "&exempt=" + Uri.EscapeDataString("0");
            }
            else if(emp is SalaryEmployee salaryEmployee)
            {
                postData += "&salary=" + Uri.EscapeDataString(salaryEmployee.SalaryPerPayPeriod.ToString());
                postData += "&hourlyrate=" + Uri.EscapeDataString("0");
                postData += "&exempt=" + Uri.EscapeDataString("1");
            }
            postData += "&fedtax=" + Uri.EscapeDataString(emp.FederalTaxRate.ToString());
            string pwordHash = Encryption.SHA256Encryption(emp.Ssn.Substring(Math.Max(emp.Ssn.Length - 4, 0)));
            postData += "&passwordhash=" + Uri.EscapeDataString(pwordHash);
            postData += "&permissionlevel=" + Uri.EscapeDataString(emp.Permissions);
            postData += "&street=" + Uri.EscapeDataString(emp.Address);
            postData += "&city=" + Uri.EscapeDataString(emp.City);
            postData += "&state=" + Uri.EscapeDataString(emp.State);
            postData += "&postalcode=" + Uri.EscapeDataString(emp.PostalCode);
            postData += "&bankname=" + Uri.EscapeDataString(emp.Bank.BankName);
            postData += "&routingnum=" + Uri.EscapeDataString(emp.Bank.BankRoutingNumber);
            postData += "&accountnum=" + Uri.EscapeDataString(emp.Bank.BankAccountNumber);
            postData += "&department=" + Uri.EscapeDataString(emp.Department);
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseText = reader.ReadToEnd();

            var Jobj = (JObject)JsonConvert.DeserializeObject(responseText);
            string empid = Jobj["emp_id"].ToString();

            return empid;
        }
        public static string Login(string username, string passwordHash)
        {
            string enc = "yHdeGH1Dl56vt28/Rdi+PvnWWqz62EEB/dBA2aMLOWw8PRtHzGk1VUcsSjX/Y9Q6i3OiUOCQ0y/r2UPf0MRlhAokL+J37IkP3jUs3f1lZig=";
            string url = Encryption.AESDecryption(enc);

            var request = (HttpWebRequest)WebRequest.Create(url);

            var postData = "username=" + Uri.EscapeDataString(username);
            postData += "&password=" + Uri.EscapeDataString(passwordHash);
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseText = reader.ReadToEnd();
            //reader.Close();
                
            return responseText;
            // Returns "Error" or an error message if something went wrong
            // Returns "Denied" if password wasn't correct
            // Returns "Admin"/"Employee" if password was correct. This is the user's privilege level
        }
    }
}
