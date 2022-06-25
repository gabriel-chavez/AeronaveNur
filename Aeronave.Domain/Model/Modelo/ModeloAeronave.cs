using Aeronave.Domain.Event;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeronave.Domain.Model.Modelo
{
    public class ModeloAeronave : AggregateRoot<Guid>
    {
        public string Modelo { get; private set; }
        public string Marca { get; private set; }
        public decimal CapacidadCarga { get; private set; }
        public decimal CapacidadCargaCombustible { get; private set; }
        public List<Asiento> Asientos { get; private set; }
        public ModeloAeronave(string modelo, string marca, decimal capacidadCarga, decimal capacidadCargaCombustible)
        {
            Id = Guid.NewGuid();
            Modelo = modelo;
            Marca = marca;
            CapacidadCarga = capacidadCarga;
            CapacidadCargaCombustible = capacidadCargaCombustible;
            Asientos = new List<Asiento>();
        }
        public ModeloAeronave()
        {

        }
        public void AgregarAsientos(int fila, int columna, string area)
        {
            var asiento = new Asiento(fila, columna, area);
            //Asientos.Add(asiento);
            //AddDomainEvent(new AsientoAgregado(fila, columna, area));
        }
    }
}
