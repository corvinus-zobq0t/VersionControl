using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using UnitTestExample.Controllers;

namespace UnitTestExample.Test
{
    public class AccountControllerTestFixture
    {
        [
            Test,
            TestCase("abcd1234", false),
            TestCase("irf@uni-corvinus", false),
            TestCase("irf.uni-corvinus.hu", false),
            TestCase("irf@uni-corvinus.hu", true)
         ]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            var accountController = new AccountController();
            var actualResult = accountController.ValidateEmail(email);
            Assert.AreEqual(expectedResult, actualResult);

        }
        [
            Test,
            TestCase("aBcDefg", false),
            TestCase("ABC1DEFG", false),
            TestCase("abc1dfgh", false),
            TestCase("aBc1Dfg", false),
            TestCase("aBc1DfgH", true)
         ]
        public void TestValidatePassword(string password, bool expectedResult)
        {
            var accountController = new AccountController();
            var actualResult = accountController.ValidatePassword(password);
            Assert.AreEqual(expectedResult, actualResult);

        }

        public bool PasswordValidate(string password)
        {
            var LowerCase = new Regex(@"[a-z]+");
            var UpperCase = new Regex(@"[A-Z]+");
            var Number = new Regex(@"[0-9]+");
            var EightChar = new Regex(@".{8,}");
            return LowerCase.IsMatch(password)&&UpperCase.IsMatch(password)&&Number.IsMatch(password)&&EightChar.IsMatch(password);

        }
        [
            Test,
            TestCase("irf@uni-corvinus.hu", "Abcd1234"),
            TestCase("irf@uni-corvinus.hu", "Abcd1234567"),
        ]
        public void TestRegisterHappyPath(string email, string password)
        {
            
            var accountController = new AccountController();

            
            var actualResult = accountController.Register(email, password);

            
            Assert.AreEqual(email, actualResult.Email);
            Assert.AreEqual(password, actualResult.Password);
            Assert.AreNotEqual(Guid.Empty, actualResult.ID);
        }


    }
}
