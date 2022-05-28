using Aeronave.Domain.Model.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Domain.Factories
{
    public class ModeloAeronaveFactory : IModeloAeronaveFactory
    {
        public ModeloAeronave Crear(string modelo, string marca, decimal capacidadCarga, decimal capacidadCargaCombustible)
        {
            return new ModeloAeronave(modelo,marca,capacidadCarga,capacidadCargaCombustible);
        }
    }
}
