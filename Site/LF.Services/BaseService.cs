using System;
using System.Data.SqlTypes;
using LF.DBManager;

namespace LF.Services
{
    public class BaseService
    {
        protected AllServices Parent { get; private set; }

        public BaseService(AllServices parent)
        {
            Parent = parent;
        }

        private readonly TransactionController transactionController = new TransactionController();

        protected T InTransaction<T>(Func<T> action)
        {
            transactionController.Begin();

            try
            {
                var result = action();

                transactionController.Commit();

                return result;
            }
            catch (Exception)
            {
                transactionController.Rollback();
                throw;
            }
        }

        protected void InTransaction(Action action)
        {
            transactionController.Begin();

            try
            {
                action();

                transactionController.Commit();
            }
            catch (SqlTypeException e)
            {
                transactionController.Rollback();
                throw;
            }
            catch (Exception e)
            {
                transactionController.Rollback();
                throw;
            }
        }


    }
}