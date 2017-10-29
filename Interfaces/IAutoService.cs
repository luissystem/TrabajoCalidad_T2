using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
   public interface IAutoService
    {
        IEnumerable<Auto> getAuto(String Marca, String Color, int? Anio, String Estado, double? PrecioMinimo, double? PrecioMaximo);
        IEnumerable<Auto> getAuto();
        void add(Auto auto);

    }
}
