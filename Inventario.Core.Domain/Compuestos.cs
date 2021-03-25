using System;
using System.Collections.Generic;

namespace Inventario.Core.Domain
{
    public class Compuestos : Productos
    {
         public Compuestos(string codigo, string nombre, decimal precio) : base(codigo, nombre, precio)
        {
            Ingredientes = new List<Simples>();
        }
        
        public void RegistroIngredientes(List<Simples> ingredientes)
        {
            Ingredientes = ingredientes;
        }

        public void retirarIngredientesInventario(List<Simples> productosSimples, List<Movimiento> movimientos, int cantidad)
        {
            foreach (var ingrediente in Ingredientes)
            {
                Simples product = productosSimples.Find(p => p.Nombre == ingrediente.Nombre);
                int cantidadRetirada = (ingrediente.Cantidad * cantidad);
                product.Retiro((product.Cantidad - cantidadRetirada), productosSimples, movimientos);
            }
        }

        public string Retiro(int cantidad,List<Simples> productosSimples, List<Movimiento> movimientos)
        {
            if (cantidad <= 0)
            {
                return "la cantidad a retirar debe ser mayor a cero";
            }

            if (!Disponibilidad(productosSimples))
            {
                return "no hay suficientes productos en inventario para realizar el retiro";
            }
            
            Costo = CalcularCosto();
            
            try
            {
                retirarIngredientesInventario(productosSimples,movimientos, cantidad);
                
                movimientos.Add(new Movimiento(Costo, Precio, cantidad, "producto preparado", Nombre));
                
                return "Retiro realizado satisfactoriamente";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public bool Disponibilidad(List<Simples> productosSimples)
        {
            bool disponible = false;

            // si no hay ingredientes no hay disponibilidad
            if (productosSimples.Count < 1)
            {
                return disponible;
            }
            
            foreach (var ingrediente in Ingredientes)
            {
                if (productosSimples.Find(p => p.Nombre == ingrediente.Nombre) == null)
                {
                    return false;
                }
                else if (productosSimples.Find(p => p.Nombre == ingrediente.Nombre).Cantidad >= (ingrediente.Cantidad*Cantidad))
                {
                    disponible = true;
                }
            }
            
            return disponible;
        }
        
        //el costo de los productos compuestos corresponden al costo de sus ingredientes por 
        public decimal CalcularCosto()
        {
            decimal costo = 0;
            
            foreach (var ingrediente in Ingredientes)
            {
                costo += (ingrediente.Costo * ingrediente.Cantidad);
            }
            
            return costo;
        }
       
        protected List<Simples> Ingredientes;
    }
}