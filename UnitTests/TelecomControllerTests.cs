/*using Application.Localization;
using Application.Services;
using Application.ViewModels;
using Data;
using Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telecom.Controllers;
using Telecom.Extensions;
using Xunit;

namespace UnitTests
{
    public class TelecomControllerUnitTests
    {
        [Fact]
        public void PaymentTest()
        {
            //Assets
            //Db
            var db = new TelecomDbContext(new DbContextOptionsBuilder<TelecomDbContext>()
               .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Telecom;Trusted_Connection=True;").Options);
            //Localizer
            var mockLocalizer = new Mock<IStringLocalizer<SharedResource>>();
            mockLocalizer.Setup(_ => _["PrefixNotFound"]).Returns(new LocalizedString("PrefixNotFound", "По префиксу не найдено провайдеров"));
            mockLocalizer.Setup(_ => _["IncorrectNumber"]).Returns(new LocalizedString("IncorrectNumber", "Некорректный номер"));
            mockLocalizer.Setup(_ => _["NullError"]).Returns(new LocalizedString("NullError", "Null прилетел"));
            mockLocalizer.Setup(_ => _["Ok"]).Returns(new LocalizedString("Ok", "Всё хорошо"))
            //ServiceProviderMock
           *//* var mockDi = new Mock<IServiceProvider>();*//*
            //Logger
            var loggerTelecom = new LoggerFactory().CreateLogger<TelecomController>();

            var loggerActiv = new LoggerFactory().CreateLogger<ActivProviderService>();

            var loggerNumber = new LoggerFactory().CreateLogger<NumberService>();
            var localizer = mockLocalizer.Object;

            var numberService = new NumberService(db, localizer, loggerNumber);

            *//*mockDi.Setup(a => a.GetService<IProviderService>("Activ")).Returns(new ActivProviderService(db, localizer, loggerActiv));
            mockDi.SetReturnsDefault(new ActivProviderService(db, localizer, loggerActiv));*/
/*            var serviceProvider = mockDi.Object;
*//*
            var controller = new TelecomController(serProv, numberService, localizer, loggerTelecom);

            Payment paymentActiv = new Payment() { Number = "+77011522352", Sum = 1000 };

            //Act
            //Всё хорошо Bill with Activ Provider is created
            var resultActiv = controller.Payment(paymentActiv, "RU-ru");

            //Assert
            Assert.Equal("Всё хорошо Bill with Activ Provider is created", resultActiv.Result.ToString());
        }
    }
}*/