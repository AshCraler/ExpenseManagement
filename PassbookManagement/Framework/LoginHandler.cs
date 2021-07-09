using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

/* When we click Login button, the controller (Home Controller) has to POST
 * the data, which includes Username and Password. 
 * 
 * This LoginModel is created for encapsulating the Username and Password
 * so that, the data will be secured.
 * 
 * What makes LoginModel different from LoginAccount? Well, first of all, 
 * LoginAccount is expected to be a Data Transfer Object, which is used as 
 * items in a DataSet in a Data Context (LoginAccountContext.Accounts). On 
 * the other hand, LoginModel is created to encapsulate login infor that end - 
 * user provides, its logging process can be success or failure depending on the 
 * result of Login() function of itselve. 
 * 
 * We will use LoginModel instead of Data Transfer Object as a Parameter 
 * for View function in HomeController
 */

namespace PassbookManagement.Framework
{
    public class LoginHandler
    {
        [Required]
        public string usrName { get; set; }
        public string pasWord { get; set; }
        
        private bool checkEmployeeLogin(string usrName, string pasWord)
        {
            if (usrName == "admin" && pasWord == "12345")
                return true;
            return false;
        }

        private bool checkCustomerLogin(string usrName, string pasWord)
        {
            if (usrName == "customer" && pasWord == "123456")
                return true;
            return false;
        }

        public bool EmployeeLogin()
        {
            return checkEmployeeLogin(this.usrName, this.pasWord);
        }

        public bool CustomerLogin()
        {
            return checkCustomerLogin(this.usrName, this.pasWord);
        }

        //password handler
        private static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        public string GetUserName()
        {
            return usrName;
        }
    }
}
