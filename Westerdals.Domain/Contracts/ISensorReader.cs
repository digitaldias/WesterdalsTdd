﻿using Westerdals.Domain.Entities;

namespace Westerdals.Domain.Contracts
{
    public interface ISensorReader
    {
        PlantReading GetSensorData();
    }
}
