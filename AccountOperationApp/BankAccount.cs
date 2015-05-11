using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountOperationApp
{
    class BankAccount
    {
        public string accountNumber;
        public string accountName;
        public double balance;

        public string GetInfo()
        {
            return (accountName + ", Your account number : " + accountNumber + " and it's balance : " + balance + " Taka");
        }

        public double GetDeposit(double deposit)
        {
            return (balance + deposit);
        }
        public double GetWithdraw(double withdraw)
        {
            return (balance - withdraw);
        }
    }
}
