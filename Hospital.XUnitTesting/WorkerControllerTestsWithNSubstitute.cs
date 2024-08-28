using Hospital.Api.Controllers;
using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace Hospital.XUnitTesting;

public class WorkerControllerTestsWithNSubstitute
{
    private IGenericService<WorkerRequest, WorkerUpdateRequest, WorkerResponse> _mockService;
    private WorkerController _controller;

    public WorkerControllerTestsWithNSubstitute()
    {
        _mockService = Substitute.For<IGenericService<WorkerRequest, WorkerUpdateRequest, WorkerResponse>>();
        _controller = new WorkerController(_mockService);
    }
    [Fact]
    public void GetAll_ReturnsOk_WithValidData()
    {
        // Arrange
        var testData = new List<WorkerResponse> { /* Populate with test data */ };
        _mockService.GetAll().Returns(testData);

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
        _mockService.GetAll().Returns((List<WorkerResponse>)null);

        // Act
        var result = _controller.GetAll();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result.Result);

        var okResult = result.Result as OkObjectResult;
        Assert.Equal("You have not data", okResult.Value);
    }
}
