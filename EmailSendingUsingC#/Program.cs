using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmailSendingUsingC_
{
    internal class Program
    {

        public void Send_Gmail_Email(string to, string subject, string body)
        {
            var fromAddress = new MailAddress("yuvraj.gadadare@gmail.com", "CIIT Training Institute");
            var toAddress = new MailAddress(to, to);
            // const string fromPassword = ac.accountPassword;
            MailMessage message = new MailMessage(fromAddress, toAddress);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;
            message.Attachments.Add(new Attachment("C:\\Users\\CIIT\\Desktop\\images\\1.jpg"));
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                Timeout = 2000000,

                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("yuvraj.gadadare@gmail.com", "xdhcftwykvsorxdk")
            };
            smtp.Send(message);
            Console.WriteLine("Sent Successfully");




        }

        public string GeneratePassword(int size)
        {
            string password = "";
            string data = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz09123456789@#$";
            Random r = new Random();

            for (int i = 1; i <= size; i++)
            {
                int index = r.Next(0, data.Length - 1);
                password = password + data[index];

            }
            return password;
        }
        public string GenerateOTP(int size)
        {
            string otp = "";
            string data = "0123456789";
            Random r = new Random();

            for (int i = 1; i <= size; i++)
            {
                int index = r.Next(0, data.Length - 1);
                otp = otp + data[index];

            }
            return otp;
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            string pass = p.GeneratePassword(10);
            string email = "poojasutar2109@gmail.com";
            string message = "<h2>Dear Pooja,</h2><p>Your account has been created successfully, you can login by following credentials</p><p>User Name=<b>"+email+"</b> and password=<b>"+pass+ "</b></p><br/><br/>Thanks & Regards,<h4>CIIT Training Institute</h4>";
            p.Send_Gmail_Email(email,"Test Email",message);
            //     Random r = new Random();

            //   Console.WriteLine(r.Next(1, 10));
           // Console.WriteLine(p.GeneratePassword(10));
            //Console.WriteLine(p.GenerateOTP(4));
            Console.ReadLine();
        }
    }
}
