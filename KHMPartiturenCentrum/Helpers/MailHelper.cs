using System.Net;
using System.Net.Mail;

namespace KHM.Helpers;
public static class MailHelper
{
	public static void SendResetCodeEmail( string emailAddress, string fullName, string resetCode )
	{
		try
		{
			// SMTP-server instellingen voor Gmail
			string smtpServer = "smtp.gmail.com";
			int port = 587;
			string username = "knzvDPC@gmail.com";
			string password = "jxru zwjb fgwn lqyd";

			string htmlBody = @"
            <!DOCTYPE html>
            <html lang=""nl"">
            <head>
                <meta charset=""UTF-8"">
                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                <title>Wachtwoord herstellen</title>
                <style>
					body { text-align: center; } 
					.container { width: 100%; max-width: 600px; margin: 0 auto; padding: 0 20px;}
                    .title { font-size: 22px; font-weight: bold; margin-bottom: 10px; text-align: center;}
                    .subtitle { font-size: 20px; font-weight: bold; margin-bottom: 20px; text-align: center;}
                    .code { font-family: 'Courier New', Courier, monospace; font-size: 28px; font-weight: bold; margin-bottom: 10px; color: #00BFFF; text-align: center;}
					.logo { display: block; margin: 0 auto; margin-bottom: 5px;}
					.centered-text { text-align: center; }
                </style>
            </head>
            <body>
                <!-- e-mail content -->
                <img src=""cid:logo"" alt=""Logo"" class=""logo"" />
                <br><br>
                <div class=""title"">Partituren Centrum</div>
                <br>
                <div class=""subtitle"">Koninklijk Hengelo's Mannenkoor</div>
                <br>
                <div class=""centered-text"">Er is zojuist een nieuw wachtwoord aangevraagd, voor het KHM partituren centrum.</div>
                <br>
                <div class=""centered-text"">Geef onderstaande code in om een nieuw wachtwoord aan te kunnen maken.</div>
                <br><br>
                <div class=""code"">" + resetCode + @"</div>
                <br>
                <div class=""centered-text"">Indien u dit niet zelf bent geweest, hoeft u <u>geen</u> actie te ondernemen.</div>
				<br>
				<div class=""centered-text"">Zonder bovenstaande code is het <u>niet</u> mogelijk uw wachtwoord te wijzigen.</div>
				<br>
            </body>
            </html>";

			// Create E-mail message
			MailMessage mail = new()
			{
				From = new MailAddress( username, "KHM Partituren Centrum" )
			};
			mail.To.Add( new MailAddress( emailAddress, fullName ) );
			mail.Subject = "Wachtwoord Reset Code " + resetCode;
			mail.Body = htmlBody;
			mail.IsBodyHtml = true;

			// Add Logo as inline-image
			AlternateView avHtml = AlternateView.CreateAlternateViewFromString(htmlBody, null, "text/html");
			LinkedResource logo = new(@"./Resources/Config/logo.png", "image/png");
			logo.ContentId = "logo";
			avHtml.LinkedResources.Add( logo );
			mail.AlternateViews.Add( avHtml );

			// initialize SMTP-client and send e-mail
			SmtpClient smtpClient = new(smtpServer, port);
			smtpClient.UseDefaultCredentials = false;
			smtpClient.Credentials = new NetworkCredential( username, password );
			smtpClient.EnableSsl = true;
			smtpClient.Send( mail );
		}
		catch ( Exception ex )
		{
			System.Windows.MessageBox.Show( "Er is een fout opgetreden bij het versturen van de e-mail: " + ex.Message );
		}
	}
}
