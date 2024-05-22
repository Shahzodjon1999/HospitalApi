using Hospital.Api.Controllers;
using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NSubstitute;

namespace Hospital.XUnitTesting;

public class WorkerControllerTests
{
    private readonly Mock<IGenericService<WorkerRequest, WorkerUpdateRequest, WorkerResponse>> _mockService;
    private readonly WorkerController _controller;

    public WorkerControllerTests()
    {
        _mockService = new Mock<IGenericService<WorkerRequest, WorkerUpdateRequest, WorkerResponse>>();
        _controller = new WorkerController(_mockService.Object);
    }

    [Fact]
    public void GetAll_ReturnsOk_WithValidData()
    {
        // Arrange
        var testData = new List<WorkerResponse> { /* Populate with test data */ };
        _mockService.Setup(x => x.GetAll()).Returns(testData);

        // Act
        var result = _controller.GetAll();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result.Result);

        var okResult = result.Result as OkObjectResult;
        Assert.Equal(testData, okResult.Value);
    }

    [Fact]
    public void GetAll_ReturnsOk_WithNoData()
    {
        // Arrange
        _mockService.Setup(x => x.GetAll()).Returns((List<WorkerResponse>)null);

        // Act
        var result = _controller.GetAll();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result.Result);

        var okResult = result.Result as OkObjectResult;
        Assert.Equal("You have not data", okResult.Value);
    }
    [Fact]
    public void GetById_ReturnsOk_WithValidId()
    {
        // Arrange
        var testData = new WorkerResponse(); // Populate with test data
        var testId = Guid.NewGuid();
        _mockService.Setup(x => x.GetById(testId)).Returns(testData);

        // Act
        var result = _controller.GetById(testId);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result.Result);

        var okResult = result.Result as OkObjectResult;
        Assert.Equal(testData, okResult.Value);
    }

    [Fact]
    public void GetById_ReturnsOk_WithInvalidId()
    {
        // Arrange
        var testId = Guid.NewGuid();
        _mockService.Setup(x => x.GetById(testId)).Returns((WorkerResponse)null);

        // Act
        var result = _controller.GetById(testId);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result.Result);

        var okResult = result.Result as OkObjectResult;
        Assert.Equal("You have not data", okResult.Value);
    }

    [Fact]
    public void Create_ReturnsOk_WithValidRequest()
    {
        // Arrange
        var request = new WorkerRequest() {FirstName="Shahzodjon",LastName="Jonizoqov" }; // Populate with test data
        _mockService.Setup(x => x.Create(request)).Returns("Created new item with this ID");
        // Act
        var result = _controller.Create(request);

        // Assert
        Assert.NotNull(result);
        //Assert.IsType<OkObjectResult>(result.Result);

        var okResult = result.Result as OkObjectResult;
        Assert.Equal("Created new item with this ID", result.Value); // Adjust as per your implementation
    }

    // Similar tests for Update, and Delete actions
}