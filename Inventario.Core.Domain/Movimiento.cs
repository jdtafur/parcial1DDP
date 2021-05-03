namespace Inventario.Core.Domain
{
    public class Movimiento
    {
        

        public int Id { get; private set; }
        public decimal CostoProducto { get; private set; }
        public decimal PrecioVenta { get; private set; }
        public int Cantidad { get; private set; }
        public string Tipo { get; private set; }
        
        public string Nombre { get; private set; }
        
        public Movimiento(decimal costoProducto, decimal precioVenta, int cantidad, string tipo, string nombre)
        {
            CostoProducto = costoProducto;
            PrecioVenta = precioVenta;
            Cantidad = cantidad;
            Tipo = tipo;
            Nombre = nombre;
        }
    }
}