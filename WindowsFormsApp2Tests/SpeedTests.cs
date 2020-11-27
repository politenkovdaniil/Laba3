using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WindowsFormsApp2.Tests
{
    [TestClass()]
    public class SpeedTests
    {

        [TestMethod()]
        public void VerboseTest()//тесты на вывод
        {
            var Speed = new Speed(38, MeasureType.m);
            Assert.AreEqual("38 м/с", Speed.Verbose());

            Speed = new Speed(38, MeasureType.km);
            Assert.AreEqual("38 км/ч", Speed.Verbose());

            Speed = new Speed(38, MeasureType.u);
            Assert.AreEqual("38 узел", Speed.Verbose());

            Speed = new Speed(38, MeasureType.max);
            Assert.AreEqual("38 мах", Speed.Verbose());
        }

        [TestMethod()]
        public void ToTest()//тесты на перевод из меров
        {
            Speed Speed;

            Speed = new Speed(1, MeasureType.m);
            Assert.AreEqual("3,6 км/ч", Speed.To(MeasureType.km).Verbose());

            Speed = new Speed(1, MeasureType.m);
            Assert.AreEqual("1,944 узел", Speed.To(MeasureType.u).Verbose());

            Speed = new Speed(1, MeasureType.m);
            Assert.AreEqual("0,00293866995797702 мах", Speed.To(MeasureType.max).Verbose());
        }

        [TestMethod()]
        public void ToTest1()//функция на перевод в метры
        {
            Speed Speed;

            Speed = new Speed(1, MeasureType.km);
            Assert.AreEqual("0,277777777777778 м/с", Speed.To(MeasureType.m).Verbose());

            Speed = new Speed(1, MeasureType.u);
            Assert.AreEqual("0,51440329218107 м/с", Speed.To(MeasureType.m).Verbose());

            Speed = new Speed(1, MeasureType.max);
            Assert.AreEqual("340,29 м/с", Speed.To(MeasureType.m).Verbose());
        }

        [TestMethod()]
        public void AddNumberTest()//сумма
        {
            var Speed = new Speed(1, MeasureType.m);
            Speed = Speed + 4.25;
            Assert.AreEqual("5,25 м/с", Speed.Verbose());
        }

        [TestMethod()]
        public void SubNumberTest()//вычитание
        {
            var Speed = new Speed(3, MeasureType.m);
            Speed = Speed - 1.75;
            Assert.AreEqual("1,25 м/с", Speed.Verbose());
        }

        [TestMethod()]
        public void MulByNumberTest()//умножение 
        {
            var Speed = new Speed(3, MeasureType.m);
            Speed = Speed * 3;
            Assert.AreEqual("9 м/с", Speed.Verbose());
        }

        [TestMethod()]
        public void MoreNumberTest()//больше
        {
            var Speed = new Speed(3, MeasureType.m);
            Speed = Speed > 2;
            Assert.AreEqual("3 м/с", Speed.Verbose());

            Speed = new Speed(1, MeasureType.m);
            Speed = Speed > 2;
            Assert.AreEqual("2 м/с", Speed.Verbose());
        }

        [TestMethod()]
        public void LessNumberTest1()//меньше
        {
            var Speed = new Speed(1, MeasureType.m);
            Speed = Speed < 2;
            Assert.AreEqual("1 м/с", Speed.Verbose());

            Speed = new Speed(3, MeasureType.m);
            Speed = Speed < 2;
            Assert.AreEqual("2 м/с", Speed.Verbose());
        }



        [TestMethod()]
        public void AddSubKmMetersTest()//все операции с разными типами (выводиться будет в типе первого значения)
        {
            var m = new Speed(100, MeasureType.m);
            var km = new Speed(1, MeasureType.km);

            Assert.AreEqual("100,277777777778 м/с", (m + km).Verbose());
            Assert.AreEqual("361 км/ч", (km + m).Verbose());

            Assert.AreEqual("-359 км/ч", (km - m).Verbose());
            Assert.AreEqual("99,7222222222222 м/с", (m - km).Verbose());

            Assert.AreEqual("360 км/ч", (km * m).Verbose());
            Assert.AreEqual("27,7777777777778 м/с", (m * km).Verbose());

            Assert.AreEqual("360 км/ч", (km > m).Verbose());
            Assert.AreEqual("100 м/с", (m > km).Verbose());

            Assert.AreEqual("1 км/ч", (km < m).Verbose());
            Assert.AreEqual("0,277777777777778 м/с", (m < km).Verbose());
        }
    }
}