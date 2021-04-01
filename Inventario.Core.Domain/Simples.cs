using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Inventario.Core.Domain
{
    public class Simples : Productos
    {
        //puedo crear un producto, pero al registrarlo en inventario es donde debo hacer la validacion sobre la cantidad
        public Simples(string codigo, string nombre, decimal precio, decimal costo, string tipo) : base(codigo, nombre, precio, costo)
        {
            Tipo = tipo;
        }
        
        public Simples(string nombre, decimal costo, int cantidad) : base( nombre, costo, cantidad)
        {
        }

        public string Tipo { get; protected set; }

        public string Registro(int cantidad, List<Simples> inventarioSimples)
        {
            if (cantidad <= 0)
            {
                return $"la cantidad a registrar debe ser mayor a 0 y usted intentó registrar {cantidad} unidades";
            }

            Cantidad += cantidad;
            
            inventarioSimples.Add(this);
            return $"Producto agregado, ahora hay {Cantidad} unidad(es) del producto " + Nombre + " en inventario";

        }

        public decimal calcularCosto()
        {
            return (Costo * Cantidad);
        }

        public string Retiro(int cantidad, List<Simples> productosList, List<Movimiento> movimientos)
        {
            if (cantidad <= 0)
            {
                return $"la cantidad a retirar debe ser mayor a 0 y usted intentó retirar {cantidad} unidades";
            }

            if (cantidad > Cantidad)
            {
                return $"lo sentimos, solo hay {Cantidad} unidad(es) disponible(s) en inventario";
            }

            Cantidad -= cantidad;

            try
            {
                productosList.Find(p => p.Codigo == Codigo).Cantidad = Cantidad;
                var movimiento = new Movimiento(Costo, Precio, cantidad, Tipo, Nombre);
                movimientos.Add(movimiento);
                
                return $"Cantidad de producto actualizado, ahora hay {Cantidad} unidades del producto {Nombre} en inventario";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}