using Entidades;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Datos
{
    public static class Autos
    {
        public static IDbSet<Auto> GetDbSet()
        {
            var mockDbSet = new Mock<IDbSet<Auto>>();
            var data = Get();

            mockDbSet.Setup(m => m.Provider).Returns(data.Provider);
            mockDbSet.Setup(m => m.Expression).Returns(data.Expression);
            mockDbSet.Setup(m => m.ElementType).Returns(data.ElementType);
            mockDbSet.Setup(o => o.GetEnumerator()).Returns(data.GetEnumerator());

            return mockDbSet.Object;
        }
        private static IQueryable<Auto> Get()
        {
            return new List<Auto> {
                new Auto { Id= 1, Marca = "Ferrari", Año = 2010, Estado = "nuevo",Color="Negro",Precio=50000},
                new Auto { Id= 2, Marca = "Lamborghini", Año = 2015, Estado = "segunda",Color="rojo",Precio=3000000},
                new Auto { Id= 3, Marca = "Audi", Año = 2017, Estado = "nuevo",Color="Azul",Precio=40000},
                new Auto { Id= 4, Marca = "Mercedes Benz", Año = 2012, Estado = "segunda",Color="verde",Precio=4000000},
                new Auto { Id= 5, Marca = "BMW", Año = 2011, Estado = "nuevo",Color="gris",Precio=10000},
                new Auto { Id= 6, Marca = "Porsche", Año = 2018, Estado = "nuevo",Color="plateado",Precio=1000000},
                new Auto { Id= 7, Marca = "Kia", Año = 2015, Estado = "segunda",Color="negro",Precio=50000},
                new Auto { Id= 8, Marca = "Toyota", Año = 2000, Estado = "nuevo",Color="rojo",Precio=40000},
                new Auto { Id= 9, Marca = "Honda", Año = 2001, Estado = "nuevo",Color="amarillo",Precio=45000},
                new Auto { Id= 10, Marca = "Bugatti", Año = 2018, Estado = "nuevo",Color="negro",Precio=50000000},
                new Auto { Id= 11, Marca = "Ferrari", Año = 2015, Estado = "segunda",Color="rojo",Precio=25000},
                new Auto { Id= 12, Marca = "Lamborghini", Año = 2017, Estado = "nuevo",Color="azul",Precio=3000000},
                new Auto { Id= 13, Marca = "Audi", Año = 2011, Estado = "segunda",Color="amarillo",Precio=45000 },
                new Auto { Id= 14, Marca = "Mercedes Benz", Año = 2000, Estado = "nuevo",Color="negro",Precio=5000000},
                new Auto { Id= 15, Marca = "Audi", Año = 2017, Estado = "nuevo",Color="Azul",Precio=40000},
                new Auto { Id= 16, Marca = "Audi", Año = 2017, Estado = "nuevo",Color="Azul",Precio=40000},
                new Auto { Id= 17, Marca = "Mercedes Benz", Año = 2012, Estado = "segunda",Color="verde",Precio=4000000},
                new Auto { Id= 18, Marca = "Honda", Año = 2001, Estado = "nuevo",Color="amarillo",Precio=45000},
            }.AsQueryable();
        }
    }
}
