using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web.Http;
using TugasTransaksiAPI.Models;
using TugasTransaksiAPI.Repository;
using BC = BCrypt.Net.BCrypt;

namespace TugasTransaksiAPI.Controllers
{
    public class UserActionsController : ApiController
    {
        readonly EmployeeRepository employeeRepository = new EmployeeRepository();
        readonly AccountRepository accountRepository = new AccountRepository();
        readonly EmployeeAccountRepository employeeAccountRepository = new EmployeeAccountRepository();

        public IHttpActionResult Login(VM_EmployeeAccount vM_EmployeeAccount)
        {
            var employee = employeeAccountRepository.Get().FirstOrDefault(
                            e => e.EmployeeEmail == vM_EmployeeAccount.EmployeeEmail &&
                            e.EmployeeEmail == vM_EmployeeAccount.EmployeeEmail);
            if (employee != null)
                return Ok(employee.EmployeeId);
            return NotFound();
        }

        public IHttpActionResult Register(VM_EmployeeAccount vM_EmployeeAccount)
        {
            //var salt = BC.GenerateSalt();
            //vM_EmployeeAccount.AccountPassword = BC.HashPassword(vM_EmployeeAccount.AccountPassword, salt);
            int result = employeeAccountRepository.Create(vM_EmployeeAccount);
            if (result > 0)
                return Ok();
            return InternalServerError();
        }

        public IHttpActionResult ForgotPassword(Employee emp)
        {
            var employee = employeeRepository.Get()
                .FirstOrDefault(e => e.EmployeeEmail == emp.EmployeeEmail);
            if (employee != null)
            {
                Guid newPassword = Guid.NewGuid();

                Account account = new Account
                {
                    AccountPassword = newPassword.ToString()
                };

                //var salt = BC.GenerateSalt();
                //account.AccountPassword = BC.HashPassword(newPassword.ToString(), salt);

                accountRepository.Put(account, employee.EmployeeId);

                SendEmail(emp.EmployeeEmail, newPassword.ToString());

                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        public void SendEmail(string recipient, string tempPassword)
        {
            string to = recipient; //To address    
            string from = "mekarbunga2021@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = "Login with your new temporary password: \n" + tempPassword;
            message.Subject = "Temporary Password";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("mekarbunga2021@gmail.com", "mekarbunga123");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
