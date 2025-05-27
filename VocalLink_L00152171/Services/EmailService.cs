// <copyright file="EmailService.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171.Services
{
    using System.Threading.Tasks;
    using SendGrid;
    using SendGrid.Helpers.Mail;

    /// <summary>
    /// Create EmaiL service using SendGrid.
    /// </summary>
    public class EmailService
    {
        /// <summary>
        /// Method to send an email asynchronously using SendGrid.
        /// </summary>
        /// <param name="toEmail">Email to send to. </param>
        /// <param name="subject">Email Subject. </param>
        /// <param name="message">Email Message. </param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var apiKey = await SecureStorage.GetAsync("sendgrid_api_key");
            if (string.IsNullOrEmpty(apiKey))
            {
                await Shell.Current.DisplayAlert("Error", "SendGrid API key is not set. Email notifications are disabled until set. Go to Developer Settings.", "OK");
                return;
            }

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("l00152171@atu.ie", "VocalLink");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message, message);
            var response = await client.SendEmailAsync(msg);

            if ((int)response.StatusCode >= 400)
            {
                var body = await response.Body.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine($"SendGrid failed: {body}");
            }
        }
    }
}