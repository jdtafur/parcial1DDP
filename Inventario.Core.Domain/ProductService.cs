using System.Collections.Generic;

namespace Inventario.Core.Domain
{
    public class ProductService
    {
        public ProductService()
        {
        }

        public decimal CalcularCostoCompuesto(List<Simples> Ingredientes)
        {
            decimal costo = 0;
            
            foreach (var ingrediente in Ingredientes)
            {
                costo += ingrediente.calcularCosto();
            }
            
            return costo;
        }
    }
}