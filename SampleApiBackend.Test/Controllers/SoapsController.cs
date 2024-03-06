using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleApiBackend.Controllers;
using SampleApiBackend.Models.Dtos;
using SampleApiBackend.Services;
using Moq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SampleApiBackend.Test.Controllers
{
    [TestClass]
    public class SoapsControllerTests
    {
        private SoapsController _soapsController;

        [TestInitialize]
        public void Setup()
        {
            var mockSoapService = new Mock<ISoapService>();
            mockSoapService.Setup(service => service.CreateSoapAsync(It.IsAny<CreateSoapDto>()))
                           .ReturnsAsync(new SoapDetailsDto
                           {
                               Name = "Levendula",
                               Description = "Lila mint a levendula",
                               Price = 420
                           });

            _soapsController = new SoapsController(mockSoapService.Object);
        }

        [TestMethod]
        public async Task CreateSoapAsyncControllerEndpointTest()
        {
            // Arrange
            CreateSoapDto createSoapDto = new CreateSoapDto
            {
                Name = "Levendula",
                Description = "Lila mint a levendula",
                Price = 420,
            };

            // Act
            var result = await _soapsController.CreateSoapAsync(createSoapDto);

            // Assert
            var createdAtActionResult = result.Result as CreatedAtActionResult;
            Assert.IsNotNull(createdAtActionResult);
            var soapDetailsDto = createdAtActionResult.Value as SoapDetailsDto;
            Assert.IsNotNull(soapDetailsDto);

            Assert.AreEqual(createSoapDto.Name, soapDetailsDto.Name);
            Assert.AreEqual(createSoapDto.Description, soapDetailsDto.Description);
            Assert.AreEqual(createSoapDto.Price, soapDetailsDto.Price);
        }
    }
}
