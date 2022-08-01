using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
    public class PassengerCar : Car
    {
        private const int MAXQUANTITYPASSENGER = 4;
        private const int POWERRESERVEREDUCTIONPERCENTAGE = 6;
        public int QuantityPassenger { get; init; }
        public PassengerCar(double averageFuel, uint fuelTankVolume, uint fuelQuantityInTank, uint speed, int quantityPassenger) :
            base(averageFuel, fuelTankVolume, fuelQuantityInTank, speed)
        {
            if (quantityPassenger > MAXQUANTITYPASSENGER)
            {
                throw new ArgumentOutOfRangeException(nameof(quantityPassenger), "The quantity passenger cannot be greater than maximum quantity passenger");
            }
            if (quantityPassenger < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantityPassenger), "The quantity passenger cannot be less than zero");
            }
            TypeCar = TypeCar.Passenger;
            QuantityPassenger = quantityPassenger;
            PowerReserveReductionPercentage = POWERRESERVEREDUCTIONPERCENTAGE;
        }

        public override int GetPowerReserveDependingOnTheLoad()
        {
            return CalculatePowerReserveWithTheLoad(QuantityPassenger);
        }
    }
}
