using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountWithTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var acc = new BankAccount("a123"); // oops, white space, null, empty strings all work
            // acc.Balance = 1000000; // we want to prevent direct setting of the balance from working
        }
    }
}
