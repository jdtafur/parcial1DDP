using System.Collections.Generic;
using NUnit.Framework;

namespace Inventario.Core.Domain.Test
{
    public class Compuesto_Test
    {
        /*
           Escenario: Retirar cantidad igual a cero 
           H1: COMO USUARIO QUIERO REGISTRAR LA SALIDA PRODUCTOS 

           Criterio de Aceptación:
           La cantidad de la salida de debe ser mayor a 0
           
           Ejemplo
           Dado El cliente crea un producto compuesto
           Código 10001, Nombre “perro sencillo”, precio 5000, costo debe ser 3000 calculado,
           
           ingredientes:
           1 salchicha
           1 lamino de queso
           1 pan perro
           
           Cuando Va a retirar 0 cantidad de dicho producto    

           Entonces El sistema presentará el mensaje. "la cantidad a retirar debe ser mayor a cero"
       */

        [Test]
        public void ExtractCeroProductCompoundFailTest()
        {
            var productosSimplesList = new List<Simples>();
            var movimientos = new List<Movimiento>();
            
            //Preparar
            var perro = new Compuestos("10001", "perro sencillo", 5000);
            
            //Acción
            //se podra ingresar la cantidad que necesita de cada ingrediente
            var salchicha = new Simples( "salchicha", 1000, 1);
            var laminaQueso = new Simples("lamina de queso", 1000, 1000);
            var panPerro = new Simples("pan perro", 1000, 1);
            
            List<Simples> ingredientes = new List<Simples>();
            ingredientes.Add(salchicha);
            ingredientes.Add(laminaQueso);
            ingredientes.Add(panPerro);
            
            perro.RegistroIngredientes(ingredientes);

            var resultado = perro.Retiro(0, productosSimplesList, movimientos);
            
            //Verificación
            Assert.AreEqual("la cantidad a retirar debe ser mayor a cero", resultado);
        }
        
        /*
           Escenario: Retirar cantidad igual A 1
           H1: COMO USUARIO QUIERO REGISTRAR LA SALIDA PRODUCTOS 

           Criterio de Aceptación:
           En caso de un producto compuesto la cantidad de la salida se le disminuirá a la cantidad existente de cada uno de su ingrediente
           
           Ejemplo
           Dado El cliente crea un producto compuesto
           Código 10001, Nombre “perro sencillo”, precio 5000, costo debe ser 3000 calculado,
           
           ingredientes:
           1 salchicha
           1 lamino de queso
           1 pan perro
           
           Cuando Va a retirar 1 cantidad de dicho producto    

           Entonces El sistema presentará el mensaje. "Retiro realizado satisfactoriamente"
       */

        [Test]
        public void ExtractOneProductCompoundSuccesTest()
        {
            var productosSimplesList = new List<Simples>();
            var movimientos = new List<Movimiento>();
            
            //Preparar
            var perro = new Compuestos("10001", "perro sencillo", 5000);
            //agregar inventario
            var salchicha = new Simples("10001", "salchicha", 1000, 1000, "ingrediente");
            var laminaQueso = new Simples("10002", "lamina de queso", 1000, 1000, "ingrediente");
            var panPerro = new Simples("10003", "pan perro", 1000, 1000, "ingrediente");
            
            salchicha.Registro(20, productosSimplesList);
            laminaQueso.Registro(20, productosSimplesList);
            panPerro.Registro(20, productosSimplesList);
            
            //Acción
            //se podra ingresar la cantidad que necesita de cada ingrediente
            var Isalchicha = new Simples( "salchicha", 1000, 1);
            var IlaminaQueso = new Simples("lamina de queso", 1000, 1);
            var IpanPerro = new Simples("pan perro", 1000, 1);

            List<Simples> ingredientes = new List<Simples>();
            ingredientes.Add(Isalchicha);
            ingredientes.Add(IlaminaQueso);
            ingredientes.Add(IpanPerro);
            
            perro.RegistroIngredientes(ingredientes);

            var resultado = perro.Retiro(1, productosSimplesList, movimientos);
            
            //Verificación
            Assert.AreEqual("Retiro realizado satisfactoriamente", resultado);
        }
    }
}