using Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Web.Controllers;

namespace Test.Controllers
{
    [TestFixture]
    class AutoControllerTest
    {
        [Test]
        public void SinFiltrar()
        {

            var mock = new Mock<IAutoService>();
            var controller = new AutoController(mock.Object);

            var resultado = controller.Index();

            Assert.IsInstanceOf<ViewResult>(resultado);
            Assert.IsNotInstanceOf<RedirectToRouteResult>(resultado);
        }
        [Test]
        public void FiltrarporMarca()
        {

            var mock = new Mock<IAutoService>();
            var controller = new AutoController(mock.Object);

            var resultado = controller.Index("Ferrari",null,null,null,null,null);

            Assert.IsInstanceOf<ViewResult>(resultado);
            Assert.IsNotInstanceOf<RedirectToRouteResult>(resultado);
        }
        [Test]
        public void FiltrarporColor()
        {

            var mock = new Mock<IAutoService>();
            var controller = new AutoController(mock.Object);

            var resultado = controller.Index(null, "Negro", null, null, null, null);

            Assert.IsInstanceOf<ViewResult>(resultado);
            Assert.IsNotInstanceOf<RedirectToRouteResult>(resultado);
        }
        [Test]
        public void FiltrarporAño()
        {

            var mock = new Mock<IAutoService>();
            var controller = new AutoController(mock.Object);

            var resultado = controller.Index(null, null, 2011, null, null, null);

            Assert.IsInstanceOf<ViewResult>(resultado);
            Assert.IsNotInstanceOf<RedirectToRouteResult>(resultado);
        }
        [Test]
        public void FiltrarporPrecioMinimo()
        {

            var mock = new Mock<IAutoService>();
            var controller = new AutoController(mock.Object);

            var resultado = controller.Index(null, null, null, null, 50000, null);

            Assert.IsInstanceOf<ViewResult>(resultado);
            Assert.IsNotInstanceOf<RedirectToRouteResult>(resultado);
        }
        [Test]
        public void FiltrarporPrecioMaximo()
        {

            var mock = new Mock<IAutoService>();
            var controller = new AutoController(mock.Object);

            var resultado = controller.Index(null, null, null, null, null, 25000);

            Assert.IsInstanceOf<ViewResult>(resultado);
            Assert.IsNotInstanceOf<RedirectToRouteResult>(resultado);
        }
        [Test]
        public void FiltrarporMarcaYcolor()
        {

            var mock = new Mock<IAutoService>();
            var controller = new AutoController(mock.Object);

            var resultado = controller.Index("Ferrari", "Negro", null, null, null, null);

            Assert.IsInstanceOf<ViewResult>(resultado);
            Assert.IsNotInstanceOf<RedirectToRouteResult>(resultado);
        }
        [Test]
        public void FiltrarporMarcaYanio()
        {

            var mock = new Mock<IAutoService>();
            var controller = new AutoController(mock.Object);

            var resultado = controller.Index("Ferrari",null, 2010, null, null, null);

            Assert.IsInstanceOf<ViewResult>(resultado);
            Assert.IsNotInstanceOf<RedirectToRouteResult>(resultado);
        }
        [Test]
        public void FiltrarporMarcaYestado()
        {

            var mock = new Mock<IAutoService>();
            var controller = new AutoController(mock.Object);

            var resultado = controller.Index("Ferrari", null, null, "nuevo", null, null);

            Assert.IsInstanceOf<ViewResult>(resultado);
            Assert.IsNotInstanceOf<RedirectToRouteResult>(resultado);
        }
        [Test]
        public void FiltrarporMarcaYpreciMinimo()
        {

            var mock = new Mock<IAutoService>();
            var controller = new AutoController(mock.Object);

            var resultado = controller.Index("Ferrari", null, null, null, 50000, null);

            Assert.IsInstanceOf<ViewResult>(resultado);
            Assert.IsNotInstanceOf<RedirectToRouteResult>(resultado);
        }
        [Test]
        public void FiltrarporMarcaYpreciMaximo()
        {

            var mock = new Mock<IAutoService>();
            var controller = new AutoController(mock.Object);

            var resultado = controller.Index("Ferrari", null, null, null, null, 50000 );

            Assert.IsInstanceOf<ViewResult>(resultado);
            Assert.IsNotInstanceOf<RedirectToRouteResult>(resultado);
        }
        [Test]
        public void AplicarTodoslosfiltros()
        {

            var mock = new Mock<IAutoService>();
            var controller = new AutoController(mock.Object);

            var resultado = controller.Index("Mercedes Benz", "negro", 2000, "nuevo", 4000000, 50000);

            Assert.IsInstanceOf<ViewResult>(resultado);
            Assert.IsNotInstanceOf<RedirectToRouteResult>(resultado);
        }
    }
}
