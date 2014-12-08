using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Configuration;
using System.Net.Mail;
using LF.Generics.Config;

namespace LF.Emails
{
    public class Sender
    {
        private readonly MailAddress from;
        private MailAddress to;
        public String Subject { get; private set; }
        public String Body { get; private set; }
        

        public Sender()
        {
            var mailSettings = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");

            if (mailSettings != null && mailSettings.From != null)
                from = new MailAddress(mailSettings.From, "[Metro Agora]");
        }


        public Sender To(String email, String name)
        {
            to = new MailAddress(email, name);
            return this;
        }


        public Sender To(String email)
        {
            to = new MailAddress(email);
            return this;
        }


        public Sender Content(String subject, String body)
        {
            Subject = subject;
            Body = body;

            return this;
        }

        public Sender Format(FormatType formatType, IDictionary<String, String> keywords)
        {
            if (!canSend)
                return this;

            keywords.Add("URL", ConfigHelper.Url);

            var format = new Format(formatType, keywords);

            Subject = format.Subject;
            Body = format.Body;

            return this;
        }



        public void Send()
        {
            if (!canSend)
                return;

            if (String.IsNullOrEmpty(Subject))
                throw new LFEmailException(EmailStatus.InvalidSubject);

            if (String.IsNullOrEmpty(Body))
                throw new LFEmailException(EmailStatus.InvalidBody);

            if (to == null)
                throw new LFEmailException(EmailStatus.InvalidAddress);

            var net = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            var host = net.Network.Host;

            using (var smtp = new SmtpClient(host) { Timeout = 10000 })
            {
                var message =
                    new MailMessage(from, to)
                    {
                        Subject = Subject,
                        Body = Body,
                        IsBodyHtml = true,
                    };

                try
                {
                    smtp.Send(message);
                }
                catch (Exception e)
                {
                    throw new LFEmailException(e);
                }
            }

        }



        private static bool canSend
        {
            get { return ConfigurationManager.AppSettings["EmailSender"] != "DontSend"; }
        }

    }
}
