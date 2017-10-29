using Moq;
using NUnit.Framework;
using Repositorio.configuraciones;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Datos;

namespace Test.Services
{
    [TestFixture]
    public class AutoServiceTests
    {
        [Test]
        public void TodoslosAutos()
        {

            var mockDb = new Mock<ExamenContext>();
            mockDb.Setup(o => o.Autos).Returns(Autos.GetDbSet());

            var service = new AutoService(mockDb.Object);

            var result = service.getAuto() ;

            Assert.AreEqual(18, result.LongCount());

        }
        [Test]
        public void AutosMarcaFerrari()
        {

            var mockDb = new Mock<ExamenContext>();
            mockDb.Setup(o => o.Autos).Returns(Autos.GetDbSet());

            var service = new AutoService(mockDb.Object);

            var result = service.getAuto("Ferrari", null, null, null, null, null);

            Assert.AreEqual(2, result.LongCount());



        }
        [Test]
        public void AutosMarcaAudi()
        {

            var mockDb = new Mock<ExamenContext>();
            mockDb.Setup(o => o.Autos).Returns(Autos.GetDbSet());

            var service = new AutoService(mockDb.Object);

            var result = service.getAuto("Audi", null, null, null, null, null);

            Assert.AreEqual(4, result.LongCount());
        }
        [Test]
        public void AutosPorColor()
        {

            var mockDb = new Mock<ExamenContext>();
            mockDb.Setup(o => o.Autos).Returns(Autos.GetDbSet());

            var service = new AutoService(mockDb.Object);

            var result = service.getAuto(null, "amarillo", null, null, null, null);

            Assert.AreEqual(3, result.LongCount());
        }
        [Test]
        public void AutosPorAño()
        {

            var mockDb = new Mock<ExamenContext>();
            mockDb.Setup(o => o.Autos).Returns(Autos.GetDbSet());

            var service = new AutoService(mockDb.Object);

            var result = service.getAuto(null, null, 2017, null, null, null);

            Assert.AreEqual(4, result.LongCount());
        }
        [Test]
        public void AutosPorEstado()
        {

            var mockDb = new Mock<ExamenContext>();
            mockDb.Setup(o => o.Autos).Returns(Autos.GetDbSet());

            var service = new AutoService(mockDb.Object);

            var result = service.getAuto(null, null, null, "nuevo", null, null);

            Assert.AreEqual(12, result.LongCount());
        }
        [Test]
        public void AutosPorPrecioMinimo()
        {

            var mockDb = new Mock<ExamenContext>();
            mockDb.Setup(o => o.Autos).Returns(Autos.GetDbSet());

            var service = new AutoService(mockDb.Object);

            var result = service.getAuto(null, null, null, null, 40000, null);

            Assert.AreEqual(16, result.LongCount());
        }
        [Test]
        public void AutosPorPrecioMaximo()
        {

            var mockDb = new Mock<ExamenContext>();
            mockDb.Setup(o => o.Autos).Returns(Autos.GetDbSet());

            var service = new AutoService(mockDb.Object);

            var result = service.getAuto(null, null, null, null, null, 50000);

            Assert.AreEqual(11, result.LongCount());
        }
    }
}
