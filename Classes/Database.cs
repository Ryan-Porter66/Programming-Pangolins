using System.Net.Http;
using System.Net;
using System.Text;
using System.IO;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using iText.Layout.Element;
using System.Collections.Generic;
using Org.BouncyCastle.Utilities.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Globalization;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Ocsp;
using static System.Windows.Forms.AxHost;

namespace PayrollManagement.Classes
{
    public static class Database
    {
        // yHdeGH1Dl56vt28/Rdi+PvnWWqz62EEB/dBA2aMLOWw8PRtHzGk1VUcsSjX/Y9Q6R2i3qOIaLnIx6RDNq13SWoGztr5VZA5saaPx3/caUDw= updateemp
        // yHdeGH1Dl56vt28/Rdi+PvnWWqz62EEB/dBA2aMLOWw8PRtHzGk1VUcsSjX/Y9Q6nnQGw1KLknpAFskuuJ5Og/UHpmwedS9XYv9cQmi5XYc= getemp

        public static void UpdateComany(string username, string passwordHash, Company company)
        {
            string enc = "yHdeGH1Dl56vt28/Rdi+PvnWWqz62EEB/dBA2aMLOWw8PRtHzGk1VUcsSjX/Y9Q6R2i3qOIaLnIx6RDNq13SWgbJ1lK1+IMwCEhpBgcPjKA=";
            string url = Encryption.AESDecryption(enc);

            var request = (HttpWebRequest)WebRequest.Create(url);

            var postData = "username=" + Uri.EscapeDataString(username);
            postData += "&password=" + Uri.EscapeDataString(passwordHash);
            postData += "&companyname=" + Uri.EscapeDataString(company.Name);
            postData += "&phonenumber=" + Uri.EscapeDataString(company.PhoneNumber);
            postData += "&federalid=" + Uri.EscapeDataString(company.FederalID);
            postData += "&address=" + Uri.EscapeDataString(company.Address);
            postData += "&city=" + Uri.EscapeDataString(company.City);
            postData += "&state=" + Uri.EscapeDataString(company.State);
            postData += "&postalcode=" + Uri.EscapeDataString(company.PostalCode);
            postData += "&bankname=" + Uri.EscapeDataString(company.Bank.BankName);
            postData += "&routingnum=" + Uri.EscapeDataString(company.Bank.BankRoutingNumber);
            postData += "&accountnum=" + Uri.EscapeDataString(company.Bank.BankAccountNumber);

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
        }

        public static Company GetCompany(string username, string passwordHash)
        {
            string enc = "yHdeGH1Dl56vt28/Rdi+PvnWWqz62EEB/dBA2aMLOWw8PRtHzGk1VUcsSjX/Y9Q6nnQGw1KLknpAFskuuJ5Ogwjku+IAilV1MwVoYGp5l8c=";
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
            
            var Jobj = (JObject)JsonConvert.DeserializeObject(responseText);
            string BankName = Jobj["bank_name"].ToString();
            string RoutingNumber = Jobj["routing_num"].ToString();
            string AccountNumber = Jobj["account_num"].ToString();
            BankAccount Bank = new BankAccount(RoutingNumber, AccountNumber, BankName);
            string FederalID = Jobj["federal_id"].ToString(); ;
            string Address = Jobj["street_address"].ToString();
            string City = Jobj["city"].ToString();
            string State = Jobj["state"].ToString();
            string PostalCode = Jobj["postal_code"].ToString();
            string PhoneNumber = Jobj["phone_number"].ToString();
            string Name = Jobj["company_name"].ToString();

            Company company = new Company(Name, Bank, FederalID, Address, City, State, PostalCode, PhoneNumber);
            return company;
        }

        public static List<Deduction> GetDeductions(string username, string passwordHash, string empID)
        {
            string enc = "yHdeGH1Dl56vt28/Rdi+PvnWWqz62EEB/dBA2aMLOWw8PRtHzGk1VUcsSjX/Y9Q6nnQGw1KLknpAFskuuJ5Og8XchcJ3PfjL23zEdih9kgM=";
            string url = Encryption.AESDecryption(enc);

            var request = (HttpWebRequest)WebRequest.Create(url);

            var postData = "username=" + Uri.EscapeDataString(username);
            postData += "&password=" + Uri.EscapeDataString(passwordHash);
            postData += "&empid=" + Uri.EscapeDataString(empID);

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

            List<Deduction> deductions = new List<Deduction>();
            var Jarr = (JArray)JsonConvert.DeserializeObject(responseText);
            foreach (JObject item in Jarr)
            {
                string name = item["deduction_name"].ToString();
                int isflat = Int32.Parse(item["isflat"].ToString());
                decimal flat = Decimal.Parse(item["flat_amount"].ToString());
                decimal percentage = Decimal.Parse(item["percent"].ToString());

                if(isflat == 1)
                {
                    FlatDeduction tempFlat = new FlatDeduction(name, flat);
                    deductions.Add(tempFlat);
                }
                else if(isflat == 0)
                {
                    PercentageDeduction tempPercent = new PercentageDeduction(name, percentage);
                    deductions.Add(tempPercent);
                }
            }

            return deductions;
        }
        public static void DeleteDeduction(string username, string passwordHash, string empID, Deduction deduction)
        {
            string enc = "yHdeGH1Dl56vt28/Rdi+PvnWWqz62EEB/dBA2aMLOWw8PRtHzGk1VUcsSjX/Y9Q6H/DSP2X8RUmRIWTmhDDfjR1zD2hMDCkdNVjhaYDI3qk=";
            string url = Encryption.AESDecryption(enc);

            var request = (HttpWebRequest)WebRequest.Create(url);

            var postData = "username=" + Uri.EscapeDataString(username);
            postData += "&password=" + Uri.EscapeDataString(passwordHash);
            postData += "&empid=" + Uri.EscapeDataString(empID);
            postData += "&name=" + Uri.EscapeDataString(deduction.Name);

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
        }
        public static void AddDeductions(string username, string passwordHash, string empID, List<Deduction> deductions)
        {
            foreach (Deduction deduction in deductions)
            {
                string enc = "yHdeGH1Dl56vt28/Rdi+PvnWWqz62EEB/dBA2aMLOWw8PRtHzGk1VUcsSjX/Y9Q6jtQT8SYykjQof6/6Wrid2RW8Lhlv86Ow6HHE1+N4cxs=";
                string url = Encryption.AESDecryption(enc);

                var postData = "username=" + Uri.EscapeDataString(username);
                postData += "&password=" + Uri.EscapeDataString(passwordHash);
                postData += "&empid=" + Uri.EscapeDataString(empID);
                if (deduction is FlatDeduction flatDeduction)
                {
                    var request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    postData += "&name=" + Uri.EscapeDataString(flatDeduction.Name);
                    postData += "&flat=" + Uri.EscapeDataString(flatDeduction.Flat.ToString());
                    postData += "&percent=" + Uri.EscapeDataString("0");
                    postData += "&isflat=" + Uri.EscapeDataString("1");

                    var data = Encoding.ASCII.GetBytes(postData);
                    request.ContentLength = data.Length;
                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                    var response = (HttpWebResponse)request.GetResponse();
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string responseText = reader.ReadToEnd();
                }
                else if(deduction is PercentageDeduction percentageDeduction)
                {
                    var request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    postData += "&name=" + Uri.EscapeDataString(percentageDeduction.Name);
                    postData += "&percent=" + Uri.EscapeDataString(percentageDeduction.Percentage.ToString());
                    postData += "&flat=" + Uri.EscapeDataString("0");
                    postData += "&isflat=" + Uri.EscapeDataString("0");

                    var data = Encoding.ASCII.GetBytes(postData);
                    request.ContentLength = data.Length;
                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                    var response = (HttpWebResponse)request.GetResponse();
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string responseText = reader.ReadToEnd();
                }
                postData = string.Empty;
            }
        }

        public static List<Employee> GetEmployeeList(string username, string passwordHash)
        {
            string enc = "yHdeGH1Dl56vt28/Rdi+PvnWWqz62EEB/dBA2aMLOWw8PRtHzGk1VUcsSjX/Y9Q6nnQGw1KLknpAFskuuJ5Og89nKL6R+FmZRbnNsYE8Vyk=";
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

            List<Employee> newEmpList = new List<Employee>();
            var Jarr = (JArray)JsonConvert.DeserializeObject(responseText);
            foreach(JObject item in Jarr)
            {
                string FirstName = item["firstname"].ToString();
                string LastName = item["lastname"].ToString();
                string Address = item["street_address"].ToString();
                string City = item["city"].ToString();
                string PostalCode = item["postal_code"].ToString();
                string State = item["state"].ToString();
                string BankName = item["bank_name"].ToString();
                string AccountNumber = item["account_num"].ToString();
                string RoutingNumber = item["routing_num"].ToString();
                BankAccount Bank = new BankAccount(RoutingNumber, AccountNumber, BankName);
                int EmployeeID = Int32.Parse(item["emp_id"].ToString());
                string dt1 = item["dob"].ToString();
                string dt2 = item["hire_date"].ToString();
                decimal FederalTaxRate = Decimal.Parse(item["federal_tax"].ToString());
                string Permissions = item["permission_level"].ToString();
                string Ssn = item["ssn"].ToString();
                DateTime Dob = DateTime.ParseExact(item["dob"].ToString(),"M/d/yyyy h:m:s tt", CultureInfo.InvariantCulture);
                DateTime HireDate = DateTime.ParseExact(item["hire_date"].ToString(), "M/d/yyyy h:m:s tt", CultureInfo.InvariantCulture);
                string PhoneNumber = item["phone_number"].ToString();
                string Department = item["department_name"].ToString();
                decimal StateTaxRate = Decimal.Parse(item["state_rate"].ToString());
                decimal SalaryPerPayPeriod = Decimal.Parse(item["salary"].ToString());
                decimal PayPerHour = Decimal.Parse(item["hourly_rate"].ToString());
                List<Deduction> tempDeduct = Database.GetDeductions(username, passwordHash, EmployeeID.ToString());

                if (string.Equals(item["exempt"].ToString(), "1" ))
                {
                    SalaryEmployee tempEmp = new SalaryEmployee(FirstName,LastName,Address,City,PostalCode,State,
                        Bank,EmployeeID,FederalTaxRate,Permissions,Ssn,Dob,HireDate,PhoneNumber,Department,tempDeduct,StateTaxRate,SalaryPerPayPeriod);
                    newEmpList.Add(tempEmp);
                }
                else
                {
                    HourlyEmployee tempEmp = new HourlyEmployee(FirstName, LastName, Address, City, PostalCode, State,
                        Bank, EmployeeID, FederalTaxRate, Permissions, Ssn, Dob, HireDate, PhoneNumber, Department, tempDeduct, StateTaxRate, PayPerHour);
                    newEmpList.Add(tempEmp);
                }
                
            }
            
            return newEmpList;
        }

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
            postData += "&dob=" + Uri.EscapeDataString(emp.Dob.ToString("yyyy-MM-dd"));
            postData += "&phonenumber=" + Uri.EscapeDataString(emp.PhoneNumber);
            postData += "&hiredate=" + Uri.EscapeDataString(emp.HireDate.ToString("yyyy-MM-dd"));

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

            if(Int32.Parse(empid) <= 0)
                throw new ArgumentNullException("EmpID");

            Database.AddDeductions(username, passwordHash, empid, emp.DeductionList);

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
