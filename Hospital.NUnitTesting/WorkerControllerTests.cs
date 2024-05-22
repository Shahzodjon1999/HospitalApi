using Hospital.Api.Controllers;
using Hospital.Application.Entity;
using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Hospital.NUnitTesting;
[TestFixture]
public class WorkerControllerTests
{
    private Mock<IGenericService<EntityBaseRequest, EntityBaseUpdateRequest, EntityBaseResponse>> _serviceCommonMock;
    private Mock<IGenericService<WorkerRequest, WorkerUpdateRequest, WorkerResponse>> _workerserviceMock;
    private WorkerController _workercontroller;

    [SetUp]
    public void Setup()
    {
        _serviceCommonMock = new Mock<IGenericService<EntityBaseRequest, EntityBaseUpdateRequest, EntityBaseResponse>>();
        _workerserviceMock = new Mock<IGenericService<WorkerRequest, WorkerUpdateRequest, WorkerResponse>>();
        _workercontroller = new WorkerController(_workerserviceMock.Object);
    }

    [Test]
    public void GetAll_ReturnsOk_WhenServiceReturnsData()
    {
        // Arrange
        var testData = new List<WorkerResponse> { new WorkerResponse { /* Initialize properties */ } };
        _workerserviceMock.Setup(s => s.GetAll()).Returns(testData);

        // Act
        var result = _workercontroller.GetAll();

        // Assert
        Assert.That(result, Is.TypeOf<ActionResult<IEnumerable<WorkerResponse>>>());
        var okResult = result as ActionResult<IEnumerable<WorkerResponse>>;
        Assert.That(okResult.Result, Is.TypeOf<OkObjectResult>());
        Assert.That((okResult.Result as OkObjectResult).Value, Is.EqualTo(testData));
    }

    [Test]
    public void GetAll_ReturnsOkWithMessage_WhenServiceReturnsNull()
    {
        // Arrange
        _workerserviceMock.Setup(s => s.GetAll()).Returns((List<WorkerResponse>)null);

        // Act
        var result = _workercontroller.GetAll();

        // Assert
        Assert.That(result, Is.TypeOf<ActionResult<IEnumerable<WorkerResponse>>>());
        var okResult = result as ActionResult<IEnumerable<WorkerResponse>>;
        Assert.That(okResult.Result, Is.TypeOf<OkObjectResult>());
        Assert.That((okResult.Result as OkObjectResult).Value, Is.EqualTo("You have not data"));
    }

    [Test]
    public void Create_WithValidRequest_ReturnsActionResult()
    {
        //Arrange
           var request = new WorkerRequest { FirstName = "Shahzodjon", LastName = "Jonizooqov"};
        _workerserviceMock.Setup(x => x.Create(request)).Returns("Created new item with this ID");

        // Act
        var result = _workercontroller.Create(request);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<Microsoft.AspNetCore.Mvc.ActionResult<string>>(result);
        Assert.AreEqual("Created new item with this ID", result.Value);
    }

    [Test]
    public void Create_EmptyRequest_ReturnsBadRequest()
    {
        // Arrange
        var workerRequest = new WorkerRequest();
        _workerserviceMock.Setup(x => x.Create(workerRequest)).Returns("The name cannot be empty");
        // Act
        var result = _workercontroller.Create(workerRequest);

        // Assert
        Assert.AreEqual("The name cannot be empty", result.Value);
    }
}