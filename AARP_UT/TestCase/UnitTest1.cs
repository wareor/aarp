namespace AARP_UT.TestCase
{
    using System;
    using NUnit;
    using Moq;

    [TestFixture]
    public class Tests
    {
        //se importa el servicio
        [SetUp]
        public void Setup()
        {
            // mock o simulacion de la informaci�n devuelta por la BD
        }

        [Test]
        public void Test1()
        {
            //llamar servicio y m�todo en donde se utiliza la simulaci�n configurada en Setup()
            Assert.Pass();
        }
    }
}