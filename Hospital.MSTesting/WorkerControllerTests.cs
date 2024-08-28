using Hospital.Api.Controllers;
using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Hospital.MSTesting
{
    [TestClass]
    public class WorkerControllerTests
    {
        private Mock<IGenericService<WorkerRequest, WorkerUpdateRequest, WorkerResponse>> _mockService;
        private WorkerController _controller;

        [TestInitialize]
        public void Initialize()
        {
            _mockService = new Mock<IGenericService<WorkerRequest, WorkerUpdateRequest, WorkerResponse>>();
            _controller = new WorkerController(_mockService.Object);
        }

        [TestMethod]
        public void GetAll_ReturnsOk_WithValidData()
        {
            // Arrange
            var testData = new List<WorkerResponse> { /* Populate with test data */ };
            _mockService.Setup(x => x.GetAll()).Returns(testData);

            // Act
            var result = _controller.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));

            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(testData, okResult.Value);
        }
        [TestMethod]
        public void GetAll_ReturnsOk_WithNoData()
        {
            // Arrange
            _mockService.Setup(x => x.GetAll()).Returns((List<WorkerResponse>)null);

            // Act
            var result = _controller.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));

            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual("You have not data", okResult.Value);
        }
    }
}