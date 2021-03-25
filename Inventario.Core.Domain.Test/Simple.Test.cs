using System.Collections.Generic;
using NUnit.Framework;

namespace Inventario.Core.Domain.Test
{
    public class Simple_Test
    {
        [SetUp]
        public void Setup()
        {
        }
        
        /*
           Escenario: registrar cantidad igual a cero 
           H1: COMO USUARIO QUIERO REGISTRAR LA ENTRADA PRODUCTOS 

           Criterio de Aceptación:
           La cantidad de la entrada de debe ser mayor a 0

           Ejemplo
           Dado El cliente crea un producto simple
           Código 10001, Nombre “salchicha”, precio 5000, costo 2000, ingrediente

           Cuando Va a registrar 0 cantidad de dicho producto    

           Entonces El sistema presentará el mensaje. “la cantidad a registrar debe ser mayor a 0 y usted intentó registrar 0 unidades”
       */

        [Test]
        public void RegisterProductSimpleFailTest()
        {
            List<Simples> productosSimplesList = new List<Simples>();
            
            //Preparar
            var salchicha = new Simples("10001", "salchicha", 1000, 1000, "ingrediente");
            
            //Acción
            var resultado = salchicha.Registro(0, productosSimplesList);
            
            //Verificación
            Assert.AreEqual("la cantidad a registrar debe ser mayor a 0 y usted intentó registrar 0 unidades", resultado);
        }
        
        /*
           Escenario: registrar cantidad diferente a cero 
           H1: COMO USUARIO QUIERO REGISTRAR LA ENTRADA PRODUCTOS 

           Criterio de Aceptación:
           La cantidad de la entrada de debe ser mayor a 0

           Ejemplo
           Dado El cliente crea un producto simple
           Código 10001, Nombre “salchicha”, precio 5000, costo 2000, ingrediente

           Cuando Va a registrar 10 cantidad de dicho producto    

           Entonces El sistema presentará el mensaje. “Producto agregado, ahora hay 10 unidad(es) del producto salchicha en inventario”
       */

        [Test]
        public void RegisterProductSimpleSuccesTest()
        {
            List<Simples> productosSimplesList = new List<Simples>();
            
            //Preparar
            var salchicha = new Simples("10001", "salchicha", 1000, 1000, "ingrediente");
            
            //Acción
            var resultado = salchicha.Registro(10, productosSimplesList);
            
            //Verificación
            Assert.AreEqual("Producto agregado, ahora hay 10 unidad(es) del producto salchicha en inventario", resultado);
        }
        
        /*
           Escenario: Retirar cantidad igual a cero 
           H1: COMO USUARIO QUIERO REGISTRAR LA SALIDA PRODUCTOS 

           Criterio de Aceptación:
           La cantidad de la salida de debe ser mayor a 0
           
           Ejemplo
           Dado El cliente crea un producto simple
           Código 10001, Nombre “salchicha”, precio 5000, costo 2000, ingrediente
           registra 10 cantidad del producto 
           
           Cuando Va a retirar 0 cantidad de dicho producto    

           Entonces El sistema presentará el mensaje. "la cantidad a retirar debe ser mayor a 0 y usted intentó retirar 0 unidades"
       */

        [Test]
        public void ExtractCeroProductSimpleFailTest()
        {
            var productosSimplesList = new List<Simples>();
            var movimientos = new List<Movimiento>();
            
            var salchicha = new Simples("10001", "salchicha", 1000, 1000, "ingrediente");
            salchicha.Registro(10, productosSimplesList);
            
            var resultado = salchicha.Retiro(0, productosSimplesList, movimientos);
            
            //Verificación
            Assert.AreEqual("la cantidad a retirar debe ser mayor a 0 y usted intentó retirar 0 unidades", resultado);
        }
        
        /*
           Escenario: Retirar cantidad mayor a la cantidad en inventario
           H1: COMO USUARIO QUIERO REGISTRAR LA SALIDA PRODUCTOS 

           Ejemplo
           Dado El cliente crea un producto simple
           Código 10001, Nombre “salchicha”, precio 5000, costo 2000, ingrediente
           registra 10 cantidad del producto 
           
           Cuando Va a retirar 15 cantidad de dicho producto    

           Entonces El sistema presentará el mensaje. “lo sentimos, solo hay 10 unidades disponibles en inventario”
       */

        [Test]
        public void ExtractBigProductSimpleFailTest()
        {
            var productosSimplesList = new List<Simples>();
            var movimientos = new List<Movimiento>();
            
            var salchicha = new Simples("10001", "salchicha", 1000, 1000, "ingrediente");
            salchicha.Registro(10, productosSimplesList);
            
            var resultado = salchicha.Retiro(15, productosSimplesList, movimientos);
            
            //Verificación
            Assert.AreEqual("lo sentimos, solo hay 10 unidad(es) disponible(s) en inventario", resultado);
        }
        
        /*
           Escenario: Retirar cantidad correcta en inventario
           H1: COMO USUARIO QUIERO REGISTRAR LA SALIDA PRODUCTOS 

           Criterio de Aceptación:
           En caso de un producto sencillo la cantidad de la salida se le disminuirá a la cantidad existente del producto.

           Ejemplo
           Dado El cliente crea un producto simple
           Código 10001, Nombre “salchicha”, precio 5000, costo 2000, ingrediente
           registra 20 cantidad del producto 
           
           Cuando Va a retirar 5 cantidad de dicho producto    

           Entonces El sistema presentará el mensaje. “Cantidad de producto actualizado, ahora hay 15 unidades del producto salchicha en inventario"
       */

        [Test]
        public void ExtractProductSimpleSuccesTest()
        {
            var productosSimplesList = new List<Simples>();
            var movimientos = new List<Movimiento>();
            
            var salchicha = new Simples("10001", "salchicha", 1000, 1000, "ingrediente");
            salchicha.Registro(20, productosSimplesList);
            
            var resultado = salchicha.Retiro(5, productosSimplesList, movimientos);
            
            //Verificación
            Assert.AreEqual("Cantidad de producto actualizado, ahora hay 15 unidades del producto salchicha en inventario", resultado);
        }
        
    }
}