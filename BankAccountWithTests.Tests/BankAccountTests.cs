using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountWithTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountWithTests.Tests
{
    [TestClass()]
    public class BankAccountTests
    {
        [TestMethod()]
        public void Deposit_PositiveValue_AddsToBalance_Test()
        {
            // test coverage, % of code covered by tests
            // depost 0, -1, 100, 4500, 90000
            
            // Arrange, create objects & variables
            BankAccount acc = new BankAccount("Test123");
            double depositAmount = 100.0;
            double expectedBalance = 100.0;

            // Act, Call methond under test
            acc.Deposit(depositAmount);

            // Assert
            Assert.AreEqual(expectedBalance, acc.Balance);
            
            // Assert.Fail(); // Default code in test method, similar to not implemented exception for testing
        }
    }
}