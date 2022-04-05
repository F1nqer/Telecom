/*using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Localization;
using Application.Localization;
using Microsoft.Extensions.Logging;
using Telecom.Controllers;
using Application.Services;
using Application.ViewModels;
using Telecom.Extensions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Microsoft.Extensions.Options;

namespace UnitTests
{
    public class TelecomControllerTests
    {
        [Fact]
        public void PaymentTest()
        {
            //Arrange
            var mock = new Mock<IStringLocalizer<IProviderService>>();
            string key = "Hello my dear friend!";
            var localizedString = new LocalizedString(key, key);
            mock.Setup(_ => _[key]).Returns(localizedString);

            var _localizer = mock.Object;
            var _service = new ActivProviderService(_localizer);
            *//*            var controller = new TelecomController(mock.Object, mock4.Object, mock1.Object, mock2.Object);
            *//*
            //Act
            var result = controller.Payment(new Payment {Number = "+77071522352", Sum = 1000 }, "RU-ru");

            //Assert
            Assert.Equal("Всё хорошо Bill with Tele2 Provider is created", result.Result.ToString());
        }

        [Fact]
        public void PaymentLocalizationTest()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public void SetLanguageTest()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}
*/