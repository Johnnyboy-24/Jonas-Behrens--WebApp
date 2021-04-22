using System;

using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace MontiniInk.Misc
{
    public static class SMTP
    {
		public enum MailType //Declares whats Type of EMail the Customer shall recieve
		{
			Declared,
			Cancelled,
			Rescheduled	
		}
        public static void send (string Email, string Name, DateTime Termin, MailType mailType)
		{
			var message = new MimeMessage ();
			message.From.Add (new MailboxAddress ("MontiniInk", "montini.ink@gmail.com"));
			message.To.Add (new MailboxAddress (Name, Email));
			message.Subject = "Dein Termin bei Montini";
			switch(mailType){
				case MailType.Declared: message.Body = new TextPart ("plain") {
				Text = @"Hey " + Name + @" ,
Gute Neuigkeiten! Wir haben soeben einen Termin für dich gefunden! Komm bitte am " + Termin.ToString() + @" zu uns. 
Falls du noch weitere Fragen hast, kannst du gerne auf diese Mail antworten. 

-- Dein Montini Ink Team" 
			}; break;
				case MailType.Cancelled: message.Body = new TextPart ("plain") {
				Text = @"Hey " + Name + @" ,
Schlechte Neuigkeiten! Leider können wir uns nicht weiter um deinen Wunsch kümmern.
Falls du noch weitere Fragen hast, kannst du gerne auf diese Mail antworten.  

--Dein Montini Ink Team" 
			}; break;
				case MailType.Rescheduled: message.Body = new TextPart ("plain") {
				Text = @"Hey " + Name + @" ,

Schlechte Neuigkeiten! Leider können wir uns vorerst nicht mehr um deinen Wunsch kümmern.
Wir werden uns jedoch bemühen frühestmöglich einen neuen Termin für Dich zu finden und dich dann per Mail zu Informieren.
Falls du noch weitere Fragen hast, kannst du gerne auf diese Mail antworten.  

-- Dein Montini Ink Team" 
			}; break;

			};
			

			using (var client = new SmtpClient ()) {
				client.Connect ("smtp.gmail.com", 587, false);

				// Note: only needed if the SMTP server requires authentication
				client.Authenticate ("montini.ink@gmail.com", "Dein.Tattoostudio2020");

				client.Send (message);
				client.Disconnect (true);
			}
		}
    }
}