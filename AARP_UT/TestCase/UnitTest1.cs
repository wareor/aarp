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
            // mock o simulacion de la información devuelta por la BD
        }

        [Test]
        public void Test1()
        {
            //llamar servicio y método en donde se utiliza la simulación configurada en Setup()
            Assert.Pass();
        }
    }
}