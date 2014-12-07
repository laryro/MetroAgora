using System;
using NHibernate;

namespace LF.DBManager
{
    public class TransactionController
    {
        protected static ISession Session
        {
            get { return NHManager.Session; }
        }

        public void Begin()
        {
            if (Session.Transaction != null
                    && Session.Transaction.IsActive)
                throw new LFRepositoryException("There's a Transaction opened already.");

            Session.BeginTransaction();

            if (Session.Transaction == null
                    || !Session.Transaction.IsActive)
                throw new LFRepositoryException("Transaction not opened.");

        }

        public void Commit()
        {
            testTransaction();

            Session.Transaction.Commit();

            Session.Flush();
        }

        public void Rollback()
        {
            if (Session.Transaction.IsActive)
            {
                testTransaction();
                Session.Transaction.Rollback();
            }

            Session.Clear();
        }

        private static void testTransaction()
        {
            if (Session.Transaction.WasCommitted || Session.Transaction.WasRolledBack)
                throw new AccessViolationException("There's a Transaction opened already.");
        }


    }
}
