using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountWithTests
{
    public class BankAccount
    {
        private string accountNumber;

        public BankAccount(string accNum)
            : this(accNum, 0.00)
        {
        }

        public BankAccount(string accNum, double initialBal)
        {
            AccountNumber = accNum;
            Balance = initialBal;
        }

        public string AccountNumber
        {
            //get => accountNumber; // I'm not used to lamba expressions (=>) yet
            get
            { 
                return accountNumber;
            }

            //set => accountNumber = value;  // I'm not used to lamba expressions (=>) yet
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Account Number cannot be null or whitespace");
                }
                accountNumber = value;
            }
        }

        public string Owner { get; set; }

        public double Balance { get; private set; }

        /// <summary>
        ///  Deposits a postive sum of money into a bank account,
        ///  increases account balance,
        ///  returns new account balance.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when amt is less than, or equal to, 0</exception>
        /// <param name="amt">The sum of money deposited</param>
        public double Deposit(double amt)
        {
            // Exception Handling
            if (amt <= 0)
            {
                throw new ArgumentException("You must deposit a positive amount!");
            }

            Balance += amt;

            return Balance;
        }

        /// <summary>
        /// Withdraw a specified amount money from a bank account,
        /// decreases account balance,
        /// returns new account balance.
        /// </summary>
        public double Withdraw(double amt)
        {
            if (amt <= 0)
            {
                throw new ArgumentException("You must withdraw a positive amount!");
            }

            Balance -= amt;

            return Balance;
        }
    }
}
