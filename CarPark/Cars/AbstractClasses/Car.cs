namespace CarPark
{
    public abstract class Car : IOperationCar
    {
        public TypeCar TypeCar { get; init; }
        public double AverageFuel { get; init; }
        public uint FuelTankVolume { get; init; }
        public uint FuelQuantityInTank { get; init; }
        public uint Speed { get; init; }
        public uint PowerReserveReductionPercentage { get; init; }

        public Car(double averageFuel, uint fuelTankVolume, uint fuelQuantityInTank, uint speed)
        {
            if (fuelQuantityInTank > fuelTankVolume)
            {
                throw new ArgumentOutOfRangeException(nameof(fuelQuantityInTank), "The amount of fuel in the tank cannot be greater than the volume of the fuel tank");
            }
            if (averageFuel < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(averageFuel), "The average fuel cann't be less than zero");
            }

            AverageFuel = averageFuel;
            FuelTankVolume = fuelTankVolume;
            FuelQuantityInTank = fuelQuantityInTank;
            Speed = speed;
        }

        public virtual int GetPowerReserve()
        {
            return CalculatePowerReserve(FuelQuantityInTank);
        }

        public abstract int GetPowerReserveDependingOnTheLoad();

        public virtual double GetTravelTime(uint fuelQuantity, double distance)
        {
            if (distance < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(distance), "The distance cannot be less than zero");
            }

            if (CalculatePowerReserve(fuelQuantity) < distance)
            {
                return -1;
            }
            return distance / Speed;
        }

        private int CalculatePowerReserve(uint fuelQuantity)
        {
            return Convert.ToInt32(fuelQuantity * 100 / AverageFuel);
        }

        protected int CalculatePowerReserveWithTheLoad(double quantityLoad)
        {
            double maxPowerReserve = CalculatePowerReserve(FuelQuantityInTank);
            return Convert.ToInt32(maxPowerReserve - (maxPowerReserve / 100 * PowerReserveReductionPercentage * quantityLoad));
        }
    }
}