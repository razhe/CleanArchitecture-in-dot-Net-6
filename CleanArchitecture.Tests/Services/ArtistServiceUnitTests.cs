using Bogus;
using CleanArchitecture.Application.Contracts;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CleanArchitecture.UnitTests.Services
{
    [TestClass]
    public class ArtistServiceUnitTests
    {
        private IArtistService _artistService;
        private Faker<Artist> _artistMock;

        [TestInitialize()]
        public void Initialize()
        {
            // Asignar todas las ids como 0 para que la libreria bogus se encargue de generar registros auto incrementales
            int artistId = 0;
            this._artistMock = new Faker<Artist>();

            //Inicializar la clase maqueta y probar el objeto de clase
            var artistRepositoryMock = new Mock<ArtistDAO>();
            Mock <ILogger<ArtistService>> logger = new Mock<ILogger<ArtistService>>();

            //This contains the rules for generating the fake data.            
            _artistMock
                .RuleFor(x => x.ArtistId, ++artistId)
                .RuleFor(x => x.Name, f => f.Lorem.Text());

            //esto establecerá el método mock con la respuesta generada desde la librería Bogus
            var mockArtistData = _artistMock.Generate(20).AsEnumerable<Artist>();

            // métodos simulados del repositorio db
            artistRepositoryMock.Setup(c => c.GetAllArtistsAsync()).ReturnsAsync(mockArtistData);

            //Esto asignará el objeto de acceso a datos simulado al constructor de lógica de negocio
            _artistService = new ArtistService(artistRepositoryMock.Object, logger.Object);
        }

        [TestCleanup()]
        public void Cleanup() { }

        [TestMethod]
        public void GetAllArtistsAsync_ListOfArtistReturned()
        {
            //Act
            var actual = _artistService.GetAllArtistsAsync();

            //Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Result.AsEnumerable().Count() > 0);
        }
    }
}
