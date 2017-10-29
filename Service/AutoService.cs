using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Repositorio.configuraciones;

namespace Service
{
    public class AutoService : IAutoService
    {
        private ExamenContext entities;
        public AutoService(ExamenContext entities)
        {
            this.entities = entities;
        }

        public void add(Auto auto)
        {
            entities.Autos.Add(auto);
            entities.SaveChanges();
        }

        public IEnumerable<Auto> getAuto()
        {
            return entities.Autos.ToList();
        }

        public IEnumerable<Auto> getAuto(String Marca, String Color, int? Anio, String Estado, double? PrecioMinimo, double? PrecioMaximo)
        {
            var query = from o in entities.Autos
                        select o;
            if (!string.IsNullOrEmpty(Marca))
            {
                query = from o in query
                        where o.Marca.ToUpper().Equals(Marca.ToUpper())

                        select o;


            }
            if (!string.IsNullOrEmpty(Marca) && PrecioMinimo.HasValue)
            {
                return entities.Autos.Where(o => o.Marca == Marca).Where(o => o.Precio >= PrecioMinimo).ToList();


            }

            if (!string.IsNullOrEmpty(Marca) && PrecioMaximo.HasValue)
            {
                return entities.Autos.Where(o => o.Marca == Marca).Where(o => o.Precio <= PrecioMaximo).ToList();


            }


            if (!string.IsNullOrEmpty(Color))
            {
                query = from o in query
                        where o.Color.ToUpper().Equals(Color.ToUpper())

                        select o;

            }
            
             if (!string.IsNullOrEmpty(Color) && PrecioMinimo.HasValue)
            {
                return entities.Autos.Where(o => o.Color == Color).Where(o => o.Precio >= PrecioMinimo).ToList();


            }

            if (!string.IsNullOrEmpty(Color) && PrecioMaximo.HasValue)
            {
                return entities.Autos.Where(o => o.Color == Color).Where(o => o.Precio <= PrecioMaximo).ToList();


            }

            if (Anio.HasValue)
            {
                query = from o in query
                        where o.Año == Anio

                        select o;

            }
            if (Anio.HasValue && PrecioMinimo.HasValue)
            {
                return entities.Autos.Where(o => o.Año == Anio).Where(o => o.Precio >= PrecioMinimo).ToList();


            }

            if (Anio.HasValue && PrecioMaximo.HasValue)
            {
                return entities.Autos.Where(o => o.Año == Anio).Where(o => o.Precio <= PrecioMaximo).ToList();


            }



            if (!string.IsNullOrEmpty(Estado))
            {
                query = from o in query
                        where o.Estado.ToUpper().Equals(Estado.ToUpper())

                        select o;

            }

            if (!string.IsNullOrEmpty(Estado) && PrecioMinimo.HasValue)
            {
                return entities.Autos.Where(o => o.Estado == Estado).Where(o => o.Precio >= PrecioMinimo).ToList();


            }

            if (!string.IsNullOrEmpty(Estado) && PrecioMaximo.HasValue)
            {
                return entities.Autos.Where(o => o.Estado == Estado).Where(o => o.Precio <= PrecioMaximo).ToList();


            }

          





            if (PrecioMinimo.HasValue && PrecioMaximo.HasValue)
            {

                return entities.Autos.Where(o => o.Precio >= PrecioMinimo).Where(o => o.Precio <= PrecioMaximo).ToList();


            }
            else
            {

                if (PrecioMinimo.HasValue)
                {

                    return entities.Autos.Where(o => o.Precio >= PrecioMinimo).ToList();


                }


                if (PrecioMaximo.HasValue)
                {

                    return entities.Autos.Where(o => o.Precio <= PrecioMaximo).ToList();


                }


            }
            if (!string.IsNullOrEmpty(Marca) && !string.IsNullOrEmpty(Color) && Anio.HasValue && !string.IsNullOrEmpty(Estado) && PrecioMinimo.HasValue&& PrecioMaximo.HasValue)
            {


                return entities.Autos.Where(o => o.Marca == Marca).Where(o => o.Color == Color).Where(o => o.Año == Anio).Where(o => o.Estado == Estado).Where(o => o.Precio >= PrecioMinimo).Where(o => o.Precio <= PrecioMaximo).ToList();
            }
           
            return query;
        }
    }
}
