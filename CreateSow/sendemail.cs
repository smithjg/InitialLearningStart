/* 
 * Description :
 *  Abstraction opf a set of functionality that sends a fixed 
 * format message to a set of fixed addresses to inform the 
 * Participants of thecreation of a Statement of work Directory
 * 
 * Author : JGS 
 * 
 */
namespace CreateSowNamespace
{
    using System;
    using System.Net.Mail;
    using System.Windows.Forms;
    using System.IO;
    using System.Text;

    public class sendemail
    {
        string textFromGmail = Properties.Resources.emailSource;
        string localFromPassword = Properties.Resources.emailPassword;
        string localSMTPServer = Properties.Resources.emailServer; 

        /// <summary>
        /// Initiate an object 
        /// </summary>
        /// <param name="fromAddress"></param>
        /// <param name="fromPassword"></param>
        /// <param name="fromSMTPServer"></param>
        public sendemail(string fromAddress, string fromPassword, string fromSMTPServer)
        {
            // Default to the defaults if any input is not filled out
            if ((string.Empty != fromAddress)
                && (string.Empty != fromPassword)
                && (string.Empty != fromSMTPServer))
            {
                this.textFromGmail = fromAddress;
                this.localFromPassword = fromPassword;
                this.localSMTPServer = fromSMTPServer;
            }
        }

        /// <summary>
        /// Send the Email itself 
        /// 1. Create the Mail Message and add a body in HTML
        /// Then Send it 
        /// </summary>
        /// <param name="Customer"></param>
        /// <param name="Title"></param>
        void SendEmail(string htmlBody, string fsNumber)
        {
            try
            {
                var mail = new MailMessage();
                mail.From = new MailAddress(textFromGmail);
                mail.To.Add("darius_jedburg@hotmail.com"); /// << get from the config 
                mail.Subject = "A New Statement of work Template number "+ fsNumber+" has been created";
                mail.IsBodyHtml = true;
                mail.Body = htmlBody;
                SendMail(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Send the Email itself 
        /// 1. Create the Mail Message and add a body in HTML
        /// Then Send it 
        /// </summary>
        /// <param name="Customer"></param>
        /// <param name="Title"></param>
        public void SendEmail(string customer, string title, string dueDate, string description,string fsNumber)
        {
            this.SendEmail(createHTMLpage(customer, title, dueDate, description, fsNumber), fsNumber);
        }

        /// <summary>
        /// Send the Mail 
        /// </summary>
        /// <param name="mail"></param>
        void SendMail(MailMessage mail)
        {
            SmtpClient SmtpServer = new SmtpClient(localSMTPServer);
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential(this.textFromGmail, this.localFromPassword);
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }

        /// <summary>
        /// Knock  up a simple HTML page 
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="title"></param>
        /// <param name="dueDate"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        string createHTMLpage(string customer, string title, string dueDate, string description,string fsNumber)
        {
            // Initialize StringWriter instance.
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
            stringBuilder.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\" >");
            stringBuilder.AppendFormat("<head><title>   A new Statement of work number- {0}  has been created </title></head>", fsNumber);
            stringBuilder.AppendFormat("<body style=\"background-color:lightgrey\">");
            stringBuilder.AppendFormat("<h1 style=\"font-size:300%\">Due Date is {0}</h1><hr>", dueDate);
            stringBuilder.AppendFormat("<h2 style=\"font-size:300%\">Customer is {0}</h2><P></P><hr>", customer);
            stringBuilder.AppendFormat("<h3 style=\"font-size:300%\">Title is    {0}</h3><P></P><hr>", title);
            stringBuilder.AppendFormat("<p style=\"font-size:300%\">Description is {0}</p><hr>", description);
            stringBuilder.AppendFormat("<h5 style=\"color:blue\">Functional Specification Number is <p style=\"color:red\">{0}</p>", fsNumber);
            stringBuilder.Append("</body></html>");
            return stringBuilder.ToString();
        }
    }
}
