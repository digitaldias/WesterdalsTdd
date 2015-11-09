using Westerdals.Domain.Entities;

namespace Westerdals.Domain.Contracts
{
    public interface IPlantReadingsManager
    {
        PlantReading GetPlantReading();
    }
}
