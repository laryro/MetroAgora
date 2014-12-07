using System;

namespace LF.Emails
{
    public class LFEmailException : Exception
    {
        public static Int32 ErrorCounter { get; private set; }
        public EmailStatus Type { get; private set; }

        public LFEmailException(EmailStatus type)
            : base(type.ToString())
        {
            ErrorCounter++;
            Type = type;
        }

        public LFEmailException(Exception e)
            : base("Exception on sending e-mail", e)
        {
            ErrorCounter++;
            Type = EmailStatus.EmailNotSent;
        }
    }



}
