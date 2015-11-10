using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Westerdals.Domain.Entities;
using Westerdals.Business.Managers;
using Should;
using Moq;
using Westerdals.Domain.Contracts;

namespace Westerdals.Business.Managers.Tests
{

    [TestClass]
    public class PlantReadingsManagerTests
    {
        private Mock<ISensorReader> _sensorReaderMock;
        private Mock<ILogger> _loggerMock;
        private Mock<IPlantReadingsVerifier> _verifierMock;
        private IExceptionHandler _exceptionHandler;

        private PlantReadingsManager Instance { get; set; }

        [TestInitialize]
        public void Before_Each_Test()
        {
            _sensorReaderMock = new Mock<ISensorReader>();
            _loggerMock = new Mock<ILogger>();
            _exceptionHandler = new ExceptionHandler(_loggerMock.Object);
            _verifierMock = new Mock<IPlantReadingsVerifier>();

            Instance = new PlantReadingsManager(
                _sensorReaderMock.Object,
                _exceptionHandler,
                _verifierMock.Object);
        }


        [TestMethod]
        public void GetPlantReading_ReaderThowsException_ReturnsDefaultReading()
        {
            // Arrange
            var exception = new Exception("I'm bad");
            _sensorReaderMock
                .Setup(o => o.GetSensorData())
                .Throws(exception);

            // Act;
            var plantReading = Instance.GetPlantReading();

            // Assert
            plantReading.Temperature.ShouldEqual(PlantReading.Default.Temperature);
        }


        [TestMethod]
        public void GetPlantReading_ReaderReturnsValidReading_ReturnsThatReading()
        {
            // Arrange
            RigReaderForReturningValidReading();
            RigTheVerifierToPassAnyReading();

            // Act
            var result = Instance.GetPlantReading();

            // Assert
            result.Temperature.ShouldEqual(23.5);
        }

        private void RigTheVerifierToPassAnyReading()
        {
            _verifierMock.Setup(o => o.IsValid(It.IsAny<PlantReading>())).Returns(true);
        }

        [TestMethod]
        public void GetPlantReading_ReaderReturnsValue_ValidatorValidatesIt()
        {
            // Arrange
            RigReaderForReturningValidReading();


            // Act
           Instance.GetPlantReading();

            // Assert
            _verifierMock.Verify(o => o.IsValid(It.IsAny<PlantReading>()), Times.Once());
        }

        private void RigReaderForReturningValidReading()
        {
            var validReading = new PlantReading { AirMoisture = 2.0, SoilMoisture = 40.4, Temperature = 23.5 };
            _sensorReaderMock.Setup(o => o.GetSensorData()).Returns(validReading);
        }

        [TestMethod]
        public void GetPlantReading_ValidatorFailsToValidateReading_ReturnsDefaultReading()
        {
            // Arrange
            _verifierMock.Setup(o => o.IsValid(It.IsAny<PlantReading>())).Returns(false);


            // Act
            var result = Instance.GetPlantReading();

            // Assert
            result.Temperature.ShouldEqual(PlantReading.Default.Temperature);
        }
    }
}
