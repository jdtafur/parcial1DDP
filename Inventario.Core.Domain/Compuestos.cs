using System;
using System.Collections.Generic;

namespace Inventario.Core.Domain
{
    public class Compuestos : Productos
    {
        protected List<Simples> Ingredientes;
        protected List<Movimiento> _movimientos;
        public Compuestos(string codigo, string nombre, decimal precio) : base(codigo, nombre, precio)
        {
            Ingredientes = new List<Simples>();
            _movimientos = new List<Movimiento>();
        }

        public void RegistroIngredientes(List<Simples> ingredientes)
        {
            Ingredientes = ingredientes;
        }

        public string Retiro(int cantidad)
        {
            if (cantidad <= 0)
            {
                return "la cantidad a retirar debe ser mayor a cero";
            }

            Costo = CalcularCosto();

            try
            {
                _movimientos.Add(new Movimiento(Costo, Precio, cantidad, "producto preparado", Nombre));

                return $"Se realizó el retiro de {cantidad} producto(s) de tipo compuesto {Nombre} con un costo de {Costo} y un precio de {Precio}";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        //el costo de los productos compuestos corresponden al costo de sus ingredientes por 
        public decimal CalcularCosto()
        {
            ProductService productService = new ProductService();
            
            return  productService.CalcularCostoCompuesto(Ingredientes);
            
        }
    }
}