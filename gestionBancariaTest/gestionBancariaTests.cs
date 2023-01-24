using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GestionBancariaAppNS;

namespace gestionBancariaTest
{
    [TestClass]
    public class gestionBancariaTests
    {
        // unit test code 
        [TestMethod]
        public void validarReintegro()
        {
            // preparación del caso de prueba
            double saldoInicial = 1000;
            double reintegro = 250;
            double saldoEsperado = 750;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            // Método a probar
            miApp.realizarReintegro(reintegro);
            Assert.AreEqual(saldoEsperado, miApp.obtenerSaldo(), 0.001, "Se produjo un error al realizar el reintegro, saldo incorrecto.");
        }

        [TestMethod]
        public void validarReintegroLimite()
        {
            // preparación del caso de prueba
            double saldoInicial = 1000;
            double reintegro = 1000;
            double saldoEsperado = 0;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            // Método a probar
            miApp.realizarReintegro(reintegro);
            Assert.AreEqual(saldoEsperado, miApp.obtenerSaldo(), 0.001, "Se produjo un error al realizar el reintegro, saldo incorrecto.");
        }

        [TestMethod]
        public void validarIngreso()
        {
            // preparación del caso de prueba
            double saldoInicial = 1000;
            double ingreso = 1000;
            double saldoEsperado = 2000;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            // Método a probar
            miApp.realizarIngreso(ingreso);
            Assert.AreEqual(saldoEsperado, miApp.obtenerSaldo(), 0.001, "Se produjo un error al realizar el ingreso, saldo incorrecto.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void validarReintegroCantidadNoValida()
        {
            double saldoInicial = 1000;
            double reintegro = -250;
            double saldoFinal = saldoInicial - reintegro;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            miApp.realizarReintegro(reintegro);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void validarReintegroSaldoInsuficiente()
        {
            double saldoInicial = 1000;
            double reintegro = 1500;
            double saldoFinal = saldoInicial - reintegro;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            miApp.realizarReintegro(reintegro);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void validarIngresoCantidadNoValida()
        {
            double saldoInicial = 1000;
            double ingreso = -100;
            double saldoFinal = saldoInicial + ingreso;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            miApp.realizarIngreso(ingreso);
        }
            
    }


}


