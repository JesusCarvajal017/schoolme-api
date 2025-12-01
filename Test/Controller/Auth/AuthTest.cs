using Business.Implements.Querys.Especific;
using Entity.Dtos.Security.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Web.Controllers.Implements.Auth;

namespace Test.Controller.Auth
{
    [TestClass]
    public class AuthController_AAA_Tests
    {
        private Mock<IAuth> _authMock = default!;
        private Mock<ILogger<AuthController>> _loggerMock = default!;
        private AuthController _controller = default!;

        [TestInitialize]
        public void Setup()
        {
            _authMock = new Mock<IAuth>(MockBehavior.Strict);
            _loggerMock = new Mock<ILogger<AuthController>>();
            //_controller = new AuthController(_authMock.Object, _loggerMock.Object);
        }

        [TestMethod]
        public async Task ValidationUser_CasoFeliz_JwtYExpiracion_AAA()
        {
            // =========================
            // PREPARAR (Arrange)
            // =========================
            var login = new CredencialesDto
            {
                Email = "user@test.com",
                Password = "P@ssw0rd"
            };

            // AuthDto es el que recibes desde Data (GenerateToken).
            // Ajusta nombres de propiedades si en tu proyecto difieren.
            var esperado = new AuthDto
            {
                Token = "jwt-123",
                Expiracion = DateTime.UtcNow.AddMinutes(60)
            };

            _authMock
                .Setup(a => a.AuthApp(
                    It.Is<CredencialesDto>(c => c.Email == login.Email && c.Password == login.Password)))
                .ReturnsAsync(esperado);

            // =========================
            // PROBAR (Act)
            // =========================
            var actionResult = await _controller.ValidationUser(login);

            // =========================
            // VERIFICAR (Assert)
            // =========================
            var ok = actionResult as OkObjectResult;
            Assert.IsNotNull(ok, "Debe responder 200 OK");
            Assert.AreEqual(200, ok!.StatusCode);

            var payload = ok.Value as AuthDto;
            Assert.IsNotNull(payload, "El payload debe ser AuthDto");
            Assert.AreEqual(esperado.Token, payload!.Token, "Token incorrecto");

            // Comparación con tolerancia por diferencias de reloj
            var delta = Math.Abs((payload.Expiracion - esperado.Expiracion).TotalSeconds);
            Assert.IsTrue(delta < 3, $"ExpiresAt distinto (delta {delta:N2}s)");

            _authMock.Verify(a => a.AuthApp(It.IsAny<CredencialesDto>()), Times.Once);
            _authMock.VerifyNoOtherCalls();
        }

        [TestMethod]
        public async Task ValidationUser_CredencialesInvalidas_MensajeAccesoDenegado_AAA()
        {
            // =========================
            // PREPARAR (Arrange)
            // =========================
            var login = new CredencialesDto { Email = "bad@test.com", Password = "wrong" };

            // Tu AuthBusiness cuando no valida devuelve un objeto anónimo { message = "..." }.
            // Simulamos eso desde la interfaz.
            var denegado = new { message = "Acceso denegado, crendenciales incorrectas" };

            _authMock
                .Setup(a => a.AuthApp(
                    It.Is<CredencialesDto>(c => c.Email == login.Email && c.Password == login.Password)))
                .ReturnsAsync(denegado);

            // =========================
            // PROBAR (Act)
            // =========================
            var actionResult = await _controller.ValidationUser(login);

            // =========================
            // VERIFICAR (Assert)
            // =========================
            var ok = actionResult as OkObjectResult;
            Assert.IsNotNull(ok, "El controlador devuelve 200 OK con el mensaje de negocio");
            Assert.AreEqual(200, ok!.StatusCode);

            // Como es un anónimo, lo verificamos por reflexión/dinámico.
            dynamic payload = ok.Value!;
            Assert.AreEqual("Acceso denegado, crendenciales incorrectas", (string)payload.message);

            _authMock.Verify(a => a.AuthApp(It.IsAny<CredencialesDto>()), Times.Once);
            _authMock.VerifyNoOtherCalls();
        }
    }
}
