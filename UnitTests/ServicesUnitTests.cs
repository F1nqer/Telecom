using Application.Localization;
using Application.Services;
using Application.ViewModels;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace UnitTests
{
    public class ServicesUnitTests
    {
        [Fact]
        public void ActivServiceTest()
        {
            //Arrange
            var db = new TelecomDbContext(new DbContextOptionsBuilder<TelecomDbContext>()
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Telecom;Trusted_Connection=True;").Options);
            var mockLocalizer = new Mock<IStringLocalizer<SharedResource>>();
            string key = "Ok";
            string value = "Bari zhaksy";
            var localizedString = new LocalizedString(key, value);
            mockLocalizer.Setup(_ => _[key]).Returns(localizedString);
            var logger = new LoggerFactory().CreateLogger<ActivProviderService>();
            var localizer = mockLocalizer.Object;

            var service = new ActivProviderService(db, localizer, logger);
            Payment paymentOk = new Payment() { Number = "+77011522352", Sum = 1000 };

            //Act
            var resultOk = service.AddBalanceAsync(paymentOk).Result;

            //Assert
            Assert.Equal("Bari zhaksy Bill with Activ Provider is created", resultOk);
        }

        [Fact]
        public void NumberServiceTest()
        {
            //Arrange
            var db = new TelecomDbContext(new DbContextOptionsBuilder<TelecomDbContext>()
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Telecom;Trusted_Connection=True;").Options);
            var mockLocalizer = new Mock<IStringLocalizer<SharedResource>>();
            mockLocalizer.Setup(_ => _["PrefixNotFound"]).Returns(new LocalizedString("PrefixNotFound", "Prefix zhok"));
            mockLocalizer.Setup(_ => _["IncorrectNumber"]).Returns(new LocalizedString("IncorrectNumber", "Некорректный номер"));
            var logger = new LoggerFactory().CreateLogger<NumberService>();
            var localizer = mockLocalizer.Object;

            var service = new NumberService(db, localizer, logger);

            var expectedNumber = "+77011834722";
            var actual = "+7 (701)- 183-47-22";
            var expectedProvider = "Activ";

            //Act
            var resultValidate = service.ValidateNumber(actual);
            var resultDetermine = service.DetermineProviderName(expectedNumber);

            //Assert
            Assert.Equal(expectedNumber, resultValidate);
            Assert.Equal(expectedProvider, resultDetermine);
        }

        [Fact]
        public void Tele2ServiceTest()
        {
            //Arrange
            var db = new TelecomDbContext(new DbContextOptionsBuilder<TelecomDbContext>()
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Telecom;Trusted_Connection=True;").Options);
            var mockLocalizer = new Mock<IStringLocalizer<SharedResource>>();
            string key = "Ok";
            string value = "Bari zhaksy";
            var localizedString = new LocalizedString(key, value);
            mockLocalizer.Setup(_ => _[key]).Returns(localizedString);
            var logger = new LoggerFactory().CreateLogger<Tele2ProviderService>();
            var localizer = mockLocalizer.Object;

            var service = new Tele2ProviderService(db, localizer, logger);
            Payment paymentOk = new Payment() { Number = "+77071522352", Sum = 1000 };

            //Act
            var resultOk = service.AddBalanceAsync(paymentOk).Result;

            //Assert
            Assert.Equal("Bari zhaksy Bill with Tele2 Provider is created", resultOk);
        }

        [Fact]
        public void BeelineServiceTest()
        {
            //Arrange
            var db = new TelecomDbContext(new DbContextOptionsBuilder<TelecomDbContext>()
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Telecom;Trusted_Connection=True;").Options);
            var mockLocalizer = new Mock<IStringLocalizer<SharedResource>>();
            string key = "Ok";
            string value = "Bari zhaksy";
            var localizedString = new LocalizedString(key, value);
            mockLocalizer.Setup(_ => _[key]).Returns(localizedString);
            var logger = new LoggerFactory().CreateLogger<BeelineProviderService>();
            var localizer = mockLocalizer.Object;

            var service = new BeelineProviderService(db, localizer, logger);
            Payment paymentOk = new Payment() { Number = "+77051522352", Sum = 1000 };

            //Act
            var resultOk = service.AddBalanceAsync(paymentOk).Result;

            //Assert
            Assert.Equal("Bari zhaksy Bill with Beeline Provider is created", resultOk);
        }

        [Fact]
        public void AltelServiceTest()
        {
            //Arrange
            var db = new TelecomDbContext(new DbContextOptionsBuilder<TelecomDbContext>()
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Telecom;Trusted_Connection=True;").Options);
            var mockLocalizer = new Mock<IStringLocalizer<SharedResource>>();
            string key = "Ok";
            string value = "Bari zhaksy";
            var localizedString = new LocalizedString(key, value);
            mockLocalizer.Setup(_ => _[key]).Returns(localizedString);
            var logger = new LoggerFactory().CreateLogger<AltelProviderService>();
            var localizer = mockLocalizer.Object;

            var service = new AltelProviderService(db, localizer, logger);
            Payment paymentOk = new Payment() { Number = "+77081522352", Sum = 1000 };
            Payment paymentBad = new Payment() { Number = "+70003332342", Sum = 10000 };

            //Act
            var resultOk = service.AddBalanceAsync(paymentOk).Result;

            //Assert
            Assert.Equal("Bari zhaksy Bill with Altel Provider is created", resultOk);
        }
    }
}