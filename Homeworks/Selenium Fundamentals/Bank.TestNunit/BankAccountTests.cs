
namespace Bank.TestNunit
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class BankAccountTests
    {
        // I.	NUnit Tests against Bank Account         

        [Test]
        public void BankAccountInitialization_WithNegativeValue_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new BankAccount(-10m));
        }

        [Test]
        public void WithDrawPositiveSum_FromBankAccount_LessThan1000()
        {
            //Arrange
            BankAccount account = new BankAccount(2000m);

            //Act
            account.Withdraw(100m);

            //Assert
            Assert.AreEqual(1895, account.Amount);
        }
        [Test]
        public void WithDrawPositiveSum_FromBankAccount_MoreThan1000()
        {
            //Arrange
            BankAccount account = new BankAccount(2000m);

            //Act
            account.Withdraw(1000m);

            //Assert
            Assert.AreEqual(980, account.Amount);
        }

        [Test]
        public void InitializeBankAccount_WithPositiveSum()
        {
            BankAccount account = new BankAccount(2000m);

            Assert.IsNotNull(account.Amount);
        }

        [Test]
        public void BankAccountAmount_IsNotEqual_Value()
        {
            BankAccount account = new BankAccount(2000m);

            Assert.True(3000 > account.Amount);
        }

        [Test]
        public void AccountInitialize_WithPositiveValue_ShouldPass()
        {
            BankAccount account = new BankAccount(2000m);

            Assert.That(account.Amount, Is.EqualTo(2000));
        }

        [Test]
        public void BankAccount_GreaterThan_Value()
        {
            BankAccount account = new BankAccount(2000m);

            Assert.That(account.Amount, Is.GreaterThan(1000));
        }

        [Test]
        public void BankAccount_IsNotInstanceOf_DateTime()
        {
            BankAccount account = new BankAccount(0m);

            Assert.That(account, Is.Not.InstanceOf<DateTime>());
        }

        [Test]
        public void BankAccountWithdraw_WithMoreMoney_ShouldThrowException()
        {
            BankAccount account = new BankAccount(200m);

            Assert.Throws<ArgumentException>(() => account.Withdraw(300m));
        }

        [Test]
        public void BankAccountWithdraw_WithNegativeValue_ShouldThrowException()
        {
            BankAccount account = new BankAccount(100m);

            Assert.Throws<ArgumentException>(() => account.Withdraw(-30m));
        }

        [Test]
        public void BankAccountDeposit_WithNegativeValue_ShouldThrowException()
        {
            BankAccount account = new BankAccount(200m);

            Assert.Throws<ArgumentException>(() => account.Deposit(-300m));
        }


    }
}
