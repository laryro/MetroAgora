using System;

namespace LF.DBManager
{
    public class LFRepositoryException : Exception
    {
        public LFRepositoryException(String message)
            : base(message) { }
    }
}
