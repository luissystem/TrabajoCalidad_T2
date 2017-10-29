using Entidades;
using Repositorio.configuraciones.Map;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.configuraciones
{
   public class ExamenContext : DbContext
    {
        public virtual IDbSet<Auto> Autos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
          
            modelBuilder.Configurations.Add(new AutoMap());
        }
    }
}
