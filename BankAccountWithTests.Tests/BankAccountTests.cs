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
        #region TestMethod
        [TestMethod]
        [DataRow("test123")]
        [DataRow("a")]
        [DataRow("1234567890")]
        [DataRow("a1b2v3d4e5")]
        [DataRow("test123!@#")]
        [DataRow("273°")]
        [DataRow("test123")]
        [DataRow("😊")]
        #endregion
        public void Constructor_ValidAccNum_SetsAccNum(string accNum)
        {
            // Arrange => Act
            BankAccount acc = new BankAccount(accNum);

            // Assert
            Assert.AreEqual(accNum, acc.AccountNumber);
        }

        #region TestMethod
        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        #endregion
        public void Constructor_InvalidAccNum_ThrowsArgumentException(string accNum)
        {
            // Arrange, Act, & Assert
            Assert.ThrowsException<ArgumentException>(() => new BankAccount(accNum));
        }

        [TestMethod]
        public void Deposit_PositiveValue_AddsToBalance_Test()
        {
            // test coverage, % of code covered by tests
            // deposit 0, -1, 100, 4500, 90000
            
            // Arrange, create objects & variables
            BankAccount acc = new BankAccount("test123");
            double depAmt = 100.0;
            double expBal = 100.0;

            // Act, Call method under test
            acc.Deposit(depAmt);

            // Assert; it is possible to have multiple asserts
            Assert.AreEqual(expBal, acc.Balance);
            
            // Assert.Fail(); // Default code in test method, similar to not implemented exception for testing
        }

        [TestMethod]
        public void Deposit_PositiveAmountWithCents_AddsToBalance()
        {
            // Arrange
            BankAccount acc = new BankAccount("test123");
            double depAmt = 10.55;
            double expBal = 10.55;

            // Act
            acc.Deposit(depAmt);

            // Assert
            Assert.AreEqual(expBal, acc.Balance);
        }

        #region TestMethod
        [TestMethod]
        [DataRow(0.00001)] // should fail, basically depositing zero cents.
        [DataRow(0.01)]
        [DataRow(10.00)]
        [DataRow(100.01)]
        [DataRow(9999999999.99)]
        #endregion
        public void Deposit_PositiveAmount_ReturnsUpdatedBalance(double depAmt)
        {
            // Arrange
            BankAccount acc = new BankAccount("test123");
            double initialBalance = 0;
            double expectedBalance = initialBalance + depAmt;

            // Act
            double returnedBalance = acc.Deposit(depAmt);

            // Assert
            Assert.AreEqual(expectedBalance, returnedBalance);
        }

        #region TestMethod
        [TestMethod]
        [TestCategory("Deposit")]
        [Priority(10)]
        [DataRow(-9999999999.99)]
        [DataRow(-99.99)]
        [DataRow(-10.00)]
        [DataRow(-0.01)]
        [DataRow(-0.00001)]
        [DataRow(0.00)]
        #endregion
        public void Deposit_NegativeAmount_ThrowsArgumentException(double depAmt)
        {
            // Arrange
            BankAccount acc = new BankAccount("test123");

            // Act => Assert
            Assert.ThrowsException<ArgumentException>(() => acc.Deposit(depAmt));
        }

        #region TestMethod
        [TestMethod]
        [TestCategory("Deposit")]
        [Priority(20)]
        #endregion
        public void Deposit_MultiplePositiveDeposits_AddsToBalance()
        {
            // Arrange
            BankAccount acc = new BankAccount("abc123");
            double amt1 = 100;
            double amt2 = 50;

            // Act/Assert
            acc.Deposit(amt1);
            Assert.AreEqual(amt1, acc.Balance);

            acc.Deposit(amt2);
            Assert.AreEqual(amt1 + amt2, acc.Balance);
        }

        #region TestMethod
        [TestMethod]
        [TestCategory("Withdrawal")]
        [Priority(10)]
        #endregion
        public void Withdraw_PositiveAmount_ReducesBalance()
        {
            // Arrange
            string accNum = "abc123";
            double initialBal = 100.0;
            double withdrawAmt = 25.5;
            double expectedBal = initialBal - withdrawAmt;

            BankAccount acc = new BankAccount(accNum, initialBal);

            // Act
            acc.Withdraw(withdrawAmt);

            // Assert
            Assert.AreEqual(expectedBal, acc.Balance);
        }
    }
}