using Westerdals.Domain.Contracts;
using Westerdals.Domain.Entities;

namespace Westerdals.Data.Sensors
{
    public class SensorReader : ISensorReader
    {
        public PlantReading GetSensorData()
        {
            return new PlantReading();
        }
    }
}
