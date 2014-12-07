using System;

namespace LF.Authentication
{
    class LFAuthException : Exception
    {
        private LFAuthException(String message) : base(message) { }

        public static LFAuthException NotWeb()
        {
            throw new LFAuthException("Not web!");
        }

        public static LFAuthException IsWeb()
        {
            throw new LFAuthException("It's web!");
        }

    }
}
