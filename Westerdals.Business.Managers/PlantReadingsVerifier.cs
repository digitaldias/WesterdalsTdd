using Westerdals.Domain.Contracts;
using Westerdals.Domain.Entities;

namespace Westerdals.Business.Managers
{
    public class PlantReadingsVerifier : IPlantReadingsVerifier
    {
        public bool IsValid(PlantReading entity)
        {
            if (entity == null)
                return false;

            // Allow plant-friendly temperatures only
            if (entity.Temperature < -40 || entity.Temperature > 45)
                return false;

            // Air moisture: 0 = completely void of moisture, 100 = under water
            if (entity.AirMoisture <= 0 || entity.AirMoisture > 100)
                return false;

            // Absolute moisture, 0 = dry, 100 = submerged
            if (entity.SoilMoisture <= 0 || entity.SoilMoisture > 100)
                return false;

            // It must be valid
            return true;
        }
    }
}
