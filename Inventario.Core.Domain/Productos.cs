using System.Collections.Generic;

namespace Inventario.Core.Domain
{
    public abstract class Productos
    {
        protected Productos(string codigo, string nombre, decimal precio, decimal costo)
        {
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
            Costo = costo;
            Cantidad = 0;
            ProductosCompuestosPreparados = new List<Compuestos>();
        }
        
        protected Productos(string codigo, string nombre, decimal costo, int cantidad)
        {
            Codigo = codigo;
            Nombre = nombre;
            Costo = costo;
            Cantidad = cantidad;
            ProductosCompuestosPreparados = new List<Compuestos>();
        }
        
        protected Productos(string codigo, string nombre, decimal precio)
        {
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
            ProductosCompuestosPreparados = new List<Compuestos>();
        }
        
        protected Productos(string nombre, decimal costo, int cantidad)
        {
            Nombre = nombre;
            Costo = costo;
            Cantidad = cantidad;
        }
        
        public string Id { get; private set; }
        public string Codigo { get; private set;}
        public string Nombre { get; private set;}
        public decimal Precio { get; protected set; }
        public decimal Costo { get; protected set; }
        public int Cantidad { get; set; }
        
        protected List<Compuestos> ProductosCompuestosPreparados;
    }
}