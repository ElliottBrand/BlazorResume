using System;
using System.Collections.Generic;
using System.Linq;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;
using BlazorResume.Server.Interfaces;
using BlazorResume.Shared.Models;

namespace BlazorResume.Server.Services
{
    public class EmailSender
    {
        private readonly IManageSettings _settings;
        private SettingsModel settingsModel;

        public EmailSender(IManageSettings settings)
        {
            _settings = settings;
        }

        public Task SendContactFormEmailAsync(string senderName, string senderEmail, string senderPhone, string senderMessage, string subject = "Website Inquiry")
        {
            var message = FormattedBody(senderName, senderEmail, senderPhone, senderMessage);
            settingsModel = _settings.GetSettingsAsync().Result;

            return Execute(settingsModel.SendGridKey, subject, message, senderEmail, settingsModel.EmailAddress);
        }

        public Task Execute(string apiKey, string subject, string message, string senderEmail, string ownerEmail)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(senderEmail),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(ownerEmail));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }

        private string FormattedBody(string name, string email, string phone, string message)
        {
            var senderInfo = String.Format("<b>From</b>: {0}<br/><b>Email</b>: {1}<br/><b>Phone</b>: {2}<br/><br/>", name, email, phone);
            return senderInfo + message;
        }
    }
}
