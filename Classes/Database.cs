using System.Net.Http;
using System.Net;
using System.Text;
using System.IO;
using System;

namespace PayrollManagement.Classes
{
    public static class Database
    {
        public static string login(string username, string passwordHash)
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
