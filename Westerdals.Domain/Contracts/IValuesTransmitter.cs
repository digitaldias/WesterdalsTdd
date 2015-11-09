using Westerdals.Domain.Entities;

namespace Westerdals.Domain.Contracts
{
    public interface IValuesTransmitter
    {
        void Transmit(PlantReading plantReading);
    }
}
