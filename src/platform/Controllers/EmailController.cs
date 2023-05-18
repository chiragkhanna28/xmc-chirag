using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using XmCloudSXAStarter.Helpers;
using XmCloudSXAStarter.Models;

namespace XmCloudSXAStarter.Controllers
{
    public class EmailController : Controller
    {
        [HttpPost]
        public ContentResult SendEmail(EventModel eventModel)
        {
            Sitecore.Diagnostics.Log.Info("Sending EMail", "");
            Sitecore.Diagnostics.Log.Info(JsonConvert.SerializeObject(eventModel), "");
            if (eventModel != null)
            {
                try
                {
                    Sitecore.Diagnostics.Log.Info("Send Email Started", "");
                    MailMessage message = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    message.From = new MailAddress("chirag.khanna28@gmail.com");
                    message.To.Add(new MailAddress("chirag.khanna28@gmail.com"));
                    message.Subject = "WebHook Notification";
                    message.IsBodyHtml = true; 
                    message.Body = EmailHelper.GenerateEmailContent(eventModel);
                    smtp.Port = 587;
                    smtp.Host = "smtp.gmail.com"; 
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("chirag.khanna28@gmail.com", "jzbayhrqixdcmzhs");
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(message);
                    Sitecore.Diagnostics.Log.Info("Send Email Ended", "");
                }
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Log.Error("Mail Exception is" + ex.StackTrace.ToString(), ex, ex);
                }
            }
            var resultSet = "Web Hook Called Successfully";
            return Content(resultSet, "application/json");
        }
    }
}