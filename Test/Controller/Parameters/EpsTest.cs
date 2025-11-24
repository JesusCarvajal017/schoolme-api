using Business.Interfaces.Commands;                   // ICommandService
using Business.Interfaces.Querys;                     // IQueryServices
using Entity.Dtos.Parameters.Eps;                     // EpsDto
using Entity.Model.Paramters;                         // Eps  (ajusta si tu ns es Parameters)
using Microsoft.AspNetCore.Mvc;
using Moq;
using Web.Controllers.Implements.Parameters;          // EpsController (ajusta si usas otro ns)

namespace Test.Controller.Parameters
{
    [TestClass]
    public class EpsControllerTests
    {
        private Mock<IQueryServices<Eps, EpsDto>> _qMock = default!;
        private Mock<ICommandService<Eps, EpsDto>> _cMock = default!;
        private EpsController _controller = default!;

        [TestInitialize]
        public void Setup()
        {
            _qMock = new Mock<IQueryServices<Eps, EpsDto>>(MockBehavior.Strict);
            _cMock = new Mock<ICommandService<Eps, EpsDto>>(MockBehavior.Strict);
            _controller = new EpsController(_qMock.Object, _cMock.Object);
        }

        [TestMethod]
        public async Task GetAll_OK_AAA()
        {
            // PREPARAR
            int? status = 1;
            var esperado = new List<EpsDto>
            {
                new EpsDto { Id = 10, Name = "Sura" },
                new EpsDto { Id = 11, Name = "Sanitas" }
            };
            _qMock.Setup(q => q.GetAllServices(status)).ReturnsAsync(esperado);

            // PROBAR
            var action = await _controller.GetAll(status);

            // VERIFICAR
            var ok = action as OkObjectResult;
            Assert.IsNotNull(ok);
            Assert.AreEqual(200, ok!.StatusCode);
            CollectionAssert.AreEquivalent(esperado, (System.Collections.ICollection)ok.Value!);

            _qMock.Verify(q => q.GetAllServices(status), Times.Once);
            _qMock.VerifyNoOtherCalls();
            _cMock.VerifyNoOtherCalls();
        }

        [TestMethod]
        public async Task GetById_OK_AAA()
        {
            // PREPARAR
            var id = 42;
            var dto = new EpsDto { Id = id, Name = "Coomeva" };
            _qMock.Setup(q => q.GetByIdServices(id)).ReturnsAsync(dto);

            // PROBAR
            var action = await _controller.GetById(id);

            // VERIFICAR
            var ok = action as OkObjectResult;
            Assert.IsNotNull(ok);
            Assert.AreEqual(200, ok!.StatusCode);
            Assert.AreEqual(dto, ok.Value);

            _qMock.Verify(q => q.GetByIdServices(id), Times.Once);
            _qMock.VerifyNoOtherCalls();
            _cMock.VerifyNoOtherCalls();
        }

        [TestMethod]
        public async Task Create_CreatedAtAction_AAA()
        {
            // PREPARAR
            var input = new EpsDto { Name = "Nueva EPS" };
            var created = new EpsDto { Id = 77, Name = "Nueva EPS" };
            _cMock.Setup(c => c.CreateServices(input)).ReturnsAsync(created);

            // PROBAR
            var action = await _controller.Create(input);

            // VERIFICAR
            var createdAt = action as CreatedAtActionResult;
            Assert.IsNotNull(createdAt, "Debe devolver CreatedAtAction");
            Assert.AreEqual(nameof(_controller.GetById), createdAt!.ActionName);
            Assert.IsNotNull(createdAt.RouteValues);
            Assert.AreEqual(77, createdAt.RouteValues!["id"]);
            Assert.AreEqual(created, createdAt.Value);

            _cMock.Verify(c => c.CreateServices(input), Times.Once);
            _cMock.VerifyNoOtherCalls();
            _qMock.VerifyNoOtherCalls();
        }

        [TestMethod]
        public async Task Update_OK_True_AAA()
        {
            // PREPARAR
            var dto = new EpsDto { Id = 5, Name = "Actualizada EPS" };
            _cMock.Setup(c => c.UpdateServices(dto)).ReturnsAsync(true);

            // PROBAR
            var action = await _controller.Update(dto);

            // VERIFICAR
            var ok = action as OkObjectResult;
            Assert.IsNotNull(ok);
            Assert.AreEqual(200, ok!.StatusCode);
            Assert.AreEqual(true, ok.Value);

            _cMock.Verify(c => c.UpdateServices(dto), Times.Once);
            _cMock.VerifyNoOtherCalls();
            _qMock.VerifyNoOtherCalls();
        }

        [TestMethod]
        public async Task Delete_OK_True_AAA()
        {
            // PREPARAR
            var id = 9;
            _cMock.Setup(c => c.DeleteServices(id)).ReturnsAsync(true);

            // PROBAR
            var action = await _controller.Delete(id);

            // VERIFICAR
            var ok = action as OkObjectResult;
            Assert.IsNotNull(ok);
            Assert.AreEqual(200, ok!.StatusCode);
            Assert.AreEqual(true, ok.Value);

            _cMock.Verify(c => c.DeleteServices(id), Times.Once);
            _cMock.VerifyNoOtherCalls();
            _qMock.VerifyNoOtherCalls();
        }

        [TestMethod]
        public async Task DeleteLogica_OK_True_AAA()
        {
            // PREPARAR
            var id = 9;
            var status = 0;
            _cMock.Setup(c => c.DeleteLogicalServices(id, status)).ReturnsAsync(true);

            // PROBAR
            var action = await _controller.DeleteLogica(id, status);

            // VERIFICAR
            var ok = action as OkObjectResult;
            Assert.IsNotNull(ok);
            Assert.AreEqual(200, ok!.StatusCode);
            Assert.AreEqual(true, ok.Value);

            _cMock.Verify(c => c.DeleteLogicalServices(id, status), Times.Once);
            _cMock.VerifyNoOtherCalls();
            _qMock.VerifyNoOtherCalls();
        }
    }
}
