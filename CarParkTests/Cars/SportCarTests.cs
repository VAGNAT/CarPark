using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarPark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Tests
{
    [TestClass()]
    public class SportCarTests
    {
        /// <summary>
        /// Get data for tests
        /// </summary>
        /// <returns>{averageFuel, FuelTankVolume, FuelQuantityInTank, Speed, expected Power reserve, expected travel time}</returns>
        private static IEnumerable<object[]> GetData()
        {
            yield return new object[] { 14, 80, 50, 140, 357 };
            yield return new object[] { 10, 60, 40, 120, 400 };
            yield return new object[] { 18, 75, 30, 200, 167 };
        }
        private static IEnumerable<object[]> GetDataForTravelTime()
        {
            yield return new object[] { 14, 80, 50, 140, 0.7142857142857143 };
            yield return new object[] { 10, 60, 40, 120, 0.8333333333333334 };
            yield return new object[] { 18, 75, 30, 200, 0.5 };
        }

        #region constructorTest

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Exception was not thrown")]
        public void SportCar_Test_Constructor_AverageFuel_less_than_zero()
        {
            new SportCar(-1, 1, 1, 1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Exception was not thrown")]
        public void SportCar_Test_Constructor_FuelQuantityInTank_greater_than_FuelTankVolume()
        {
            new SportCar(1, 1, 2, 1);
        }

        [TestMethod()]
        public void SportCar_Test_Constructor()
        {
            //arange
            double averageFuel = 1;
            uint fuelQuantityInTank = 2;
            uint fuelTankVolume = 3;
            uint speed = 4;

            //act
            Car sportCar = new SportCar(averageFuel, fuelTankVolume, fuelQuantityInTank, speed);

            //assert
            Assert.AreEqual(TypeCar.Sport, sportCar.TypeCar);
            Assert.AreEqual(averageFuel, sportCar.AverageFuel);
            Assert.AreEqual(fuelTankVolume, sportCar.FuelTankVolume);
            Assert.AreEqual(fuelQuantityInTank, sportCar.FuelQuantityInTank);
            Assert.AreEqual(speed, sportCar.Speed);
        }

        #endregion

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void GetPowerReserve_Test(double averageFuel, int fuelTankVolume, int fuelQuantityInTank, int speed,
            int expectedPowerReserve)
        {
            //arange
            Car sportCar = new SportCar(averageFuel, (uint)fuelTankVolume, (uint)fuelQuantityInTank, (uint)speed);

            //act
            double actualPowerReserve = sportCar.GetPowerReserve();

            //assert
            Assert.AreEqual(expectedPowerReserve, actualPowerReserve);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void GetPowerReserveDependingOnTheLoad_Test(double averageFuel, int fuelTankVolume, int fuelQuantityInTank, int speed,
            int expectedPowerReserve)
        {
            //arange
            Car sportCar = new SportCar(averageFuel, (uint)fuelTankVolume, (uint)fuelQuantityInTank, (uint)speed);

            //act
            double actualPowerReserve = sportCar.GetPowerReserveDependingOnTheLoad();

            //assert
            Assert.AreEqual(expectedPowerReserve, actualPowerReserve);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetDataForTravelTime), DynamicDataSourceType.Method)]
        public void GetTravelTime_Test_powerReserve_less_than_distance(double averageFuel, int fuelTankVolume, int fuelQuantityInTank, int speed,
             double expectedTravelTime)
        {
            //arange
            Car sportCar = new SportCar(averageFuel, (uint)fuelTankVolume, (uint)fuelQuantityInTank, (uint)speed);
            expectedTravelTime = -1;
            //act
            double actualTravelTime = sportCar.GetTravelTime(1, 100);

            //assert
            Assert.AreEqual(expectedTravelTime, actualTravelTime);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetDataForTravelTime), DynamicDataSourceType.Method)]
        public void GetTravelTime_Test(double averageFuel, int fuelTankVolume, int fuelQuantityInTank, int speed,
             double expectedTravelTime)
        {
            //arange
            Car sportCar = new SportCar(averageFuel, (uint)fuelTankVolume, (uint)fuelQuantityInTank, (uint)speed);

            //act
            double actualTravelTime = sportCar.GetTravelTime(20, 100);

            //assert
            Assert.AreEqual(expectedTravelTime, actualTravelTime);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Exception was not thrown")]
        public void GetTravelTime_Test_distance_less_than_zero()
        {
            //arange
            Car sportCar = new SportCar(1, 1, 1, 1);

            //act
            sportCar.GetTravelTime(20, -1);
        }
    }
}